using Microsoft.AspNetCore.Mvc;
using Skinet.API.RequestHelpers;
using Skinet.Domain.Entities;
using Skinet.Domain.Interfaces;

namespace Skinet.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    protected async Task<ActionResult> CreatePagedResult<T>(IGenericRepository<T> repository, ISpecification<T> specification, int pageIndex, int pageSize) where T : BaseEntity
    {
        var items = await repository.ListAsync(specification);
        var count = await repository.CountAsync(specification);

        var pagination = new Pagination<T>(pageIndex, pageIndex, count, items);

        return Ok(pagination);
    }
}
