using TokenGpt.Contract.Services.Dto;

namespace TokenGpt.Contract.Services;

public interface IApplicationService 
{
    /// <summary>
    /// 创建知识库
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task CreateAsync(ApplicationInput input);
    
    /// <summary>
    /// 获取知识库列表
    /// </summary>
    /// <param name="keyword"></param>
    /// <returns></returns>
    Task<List<ApplicationDto>> GetListAsync(string keyword);
}