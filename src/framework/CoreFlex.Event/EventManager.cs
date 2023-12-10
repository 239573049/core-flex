using CoreFlex.Event.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Threading.Channels;

namespace CoreFlex.Event;

/// <summary>
/// 事件管理
/// 通过Channel实现本地事件总线
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class EventManager<TEntity> : IDisposable where TEntity : class
{
    private bool _disposable;
    private readonly CancellationToken _cancellation;
    private readonly Channel<TEntity> _queue;
    private readonly IServiceProvider _serviceProvider;
    private readonly EventBusOption _eventBus;
    public EventManager(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _cancellation = CancellationToken.None;
        _eventBus = serviceProvider.GetService<IOptions<EventBusOption>>()?.Value ?? new EventBusOption();
        _queue = Channel.CreateBounded<TEntity>(_eventBus.Capacity);
    }

    private async void Start()
    {
        await Task.Factory.StartNew(async () =>
        {
            while (!_disposable)
            {
                var result = await _queue.Reader.ReadAsync(_cancellation);
                await Dequeue(result);
            }
        }, _cancellation);
    }

    private async Task Dequeue(TEntity entity)
    {
        foreach (var handler in _serviceProvider.GetServices<ILoadEventHandler<TEntity>>())
        {
            try
            {
                await handler.HandleAsync(entity);
            }
            catch (Exception e)
            {
                // 如果全局处理了则不会进入当前的异常处理
                var result = _eventBus?.ExceptionHandling(e, entity);

                if (result == true)
                {
                    continue;
                }

                await handler.ExceptionHandling(e, entity);
            }
        }
    }

    /// <summary>
    /// 添加入队
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task EnqueueAsync(TEntity entity)
    {
        await _queue.Writer.WriteAsync(entity, _cancellation);

        // 当数据入队成功启动消费
        Start();
    }

    public void Dispose()
    {
        _disposable = true;
        _cancellation.ThrowIfCancellationRequested();
    }
}