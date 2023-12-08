# Core Flex JS 工具模块

提供系统常用的JS互操作的封装，便于使用。

## 封装Api

### `CookieJsInterop`

提供：

- `GetAllCookiesAsync` 获取所有Cookie
- `AddCookieAsync` 添加Cookie`

### `LocalStorageJsInterop`

提供：

- `SetLocalStorageAsync` 设置LocalStorage的值
- `GetLocalStorageAsync` 获取LocalStorage的值
- `RemoveLocalStorageAsync` 移除LocalStorage的值
- `RemovesLocalStorageAsync` 批量删除Key的LocalStorage
- `ClearLocalStorageAsync` 清空LocalStorage的值
- `IsLocalStorageSupportedAsync` 判断浏览器是否支持LocalStorage
- `GetLocalStorageKeysAsync` 获取LocalStorage的所有Key

### `SessionStorageJsInterop`

提供：

- `SetSessionStorageAsync` 设置SessionStorage的值
- `GetSessionStorageAsync` 获取SessionStorage的值
- `RemoveSessionStorageAsync` 移除SessionStorage的值
- `RemovesSessionStorageAsync` 批量删除Key的SessionStorage
- `ClearSessionStorageAsync` 清空SessionStorage的值
- `GetSessionStorageLengthAsync` 获取 sessionStorage 中值的数量
- `ContainKeyAsync` 判断 sessionStorage 中是否含有某个键名

### `WindowJsInterop`

提供以下功能：

- `CreateBlobURLAsync`: 使用 blob 创建 Blob Url
- `CreateBlobURLFromUint8ArrayAsync`: 使用 byte[] 创建一个 Blob 对象URL
- `CreateBlobURLFromStringAsync`: 使用 Base64 创建一个 Blob 对象的URL
- `RevokeUrlAsync`: 释放 Blob 对象的 URL
- `RevokeUrlsAsync`: 批量释放 Blob 对象的 URL
- `GetScrollPositionAsync`: 获取滚动条位置
- `SetScrollPositionAsync`: 修改滚动条位置
- `GetScrollHeightAsync`: 获取滚动条高度
- `ScrollToBottomAsync` 滚动到底部
- `ScrollToTopAsync` 滚动到顶部
- `CopyToClipboardAsync` 复制到剪贴板
