# Core Flex 本地事件总线

本地事件总线通过Channel实现本地事件总线

添加`CoreFlexEventModule`模块依赖

## 基本使用

添加处理程序

```csharp
public class TestEventHandler : ILoadEventHandler<TestEto>
{
    public Task HandleAsync(TestEto eto)
    {
        throw new NotImplementedException();
    }

    public Task ExceptionHandling(Exception exception, TestEto eto)
    {
        throw new NotImplementedException();
    }
}

public class TestEto
{
    public string Value { get; set; }
}
```

提交事件

```csharp
// 通过构造得到`ILoadEventBus`

await loadEvent.PushAsync(new TestEto(){
    Value="test"
})
```