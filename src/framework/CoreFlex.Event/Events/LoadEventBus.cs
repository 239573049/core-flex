﻿namespace CoreFlex.Event.Events;

public class LoadEventBus<TEntity> : ILoadEventBus<TEntity> where TEntity : class
{
    private readonly EventManager<TEntity> _eventManager;

    public LoadEventBus(EventManager<TEntity> eventManager)
    {
        _eventManager = eventManager;
    }

    public async Task PushAsync(TEntity entity)
    {
        await _eventManager.EnqueueAsync(entity);
    }
}