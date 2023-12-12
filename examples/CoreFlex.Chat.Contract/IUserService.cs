/// core-flex-chat © 2023-12-13 by 贺家乐 is licensed under Attribution-NonCommercial-ShareAlike 4.0 International 1
namespace CoreFlex.Chat.Contract
{
    public interface IUserService
    {
        /// <summary>
        /// 获取用户token
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<string> GetTokenAsync(string name);
    }
}
