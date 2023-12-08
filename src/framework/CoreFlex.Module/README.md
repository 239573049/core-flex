# Core Flex模块

Core Flex的核心设计，Core Flex其他模块都是基于Core Flex的核心设计来实现的。
Core Flex模块提供了一些基础的功能，包括：
	- 模块化
	- 自动依赖注入
	
## 简单使用

1. 安装`NuGet`包

```xml
<PackageReference Include="CoreFlex.Module" Version="模块版本" />
```

2. 添加对应模块方法，比如项目名`CoreFlex.Razor.JsInterop`,那么模块名称则是`CoreFlexRazorJsInteropModule`，这样的好处就是可以通过模块名称来查找对应的模块，而不是通过文件夹名称来查找模块，这样可以避免文件夹名称和模块名称不一致的问题。

```csharp
public class CoreFlexRazorJsInteropModule : CoreFlexModule
{
    public override void ConfigureServices(CoreFlexServiceContext services)
    {
    }

    public override void OnApplicationShutdown(CoreFlexBuilder app)
    {
    }
}
```

创建的模块必须继承`CoreFlexModule`，然后实现`ConfigureServices`和`OnApplicationShutdown`方法，这两个方法是模块的生命周期方法，`ConfigureServices`方法在模块加载时调用，`OnApplicationShutdown`方法在模块构建完成调用。
模块中也提供了`Async`结束的异步回调，以便于在模块加载完成后，可以执行一些异步操作，比如加载一些配置文件等。
当然，如果你的模块需要使用其他的模块，你可以在模块类的上面添加特性`[DependsOn(typeof(CoreFlexRazorModule))]`,`CoreFlexRazorModule`则是你要依赖的模块，当然它也支持多个模块的依赖；
这样在加载模块时，会先加载`CoreFlexRazorModule`模块，
但是如果没有设置特定模块执行顺序，依赖模块将在当前模块的后面执行。

```csharp
[DependsOn(typeof(CoreFlexRazorModule))]
public class CoreFlexRazorJsInteropModule : CoreFlexModule
```