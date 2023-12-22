using AutoMapper;
using CoreFlex.Module;
using TokenGpt.Contract.Services;
using TokenGpt.Contract.Services.Dto;
using TokenGpt.Rcl.Model;

namespace TokenGpt.Rcl.Service;

public class ApplicationService : IApplicationService, IScopedDependency
{
    protected readonly IFreeSql _freeSql;
    protected readonly IMapper _mapper;

    public ApplicationService(IFreeSql freeSql, IMapper mapper)
    {
        _freeSql = freeSql;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public Task CreateAsync(ApplicationInput input)
    {
        var application = _mapper.Map<ApplicationEntity>(input);

        return _freeSql.Insert(application).ExecuteAffrowsAsync();
    }

    /// <inheritdoc />
    public async Task<List<ApplicationDto>> GetListAsync(string keyword)
    {
        var query = _freeSql.Select<ApplicationEntity>()
            .WhereIf(!string.IsNullOrWhiteSpace(keyword), x => x.Name.Contains(keyword));

        var result = await query.ToListAsync();
        
        return _mapper.Map<List<ApplicationDto>>(result);
    }
}