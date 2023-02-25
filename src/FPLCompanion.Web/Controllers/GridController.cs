using FPLCompanion.ApplicationServices.Requests.Grid.Commands;
using FPLCompanion.ApplicationServices.Requests.Grid.Queries;
using FPLCompanion.Dto.Grid;
using Microsoft.AspNetCore.Mvc;

namespace FPLCompanion.Controllers
{
    [ApiController]
    public class GridController : BaseController
    {
        [HttpGet]
        [Route("grid/filter/{gridKey}")]
        public async Task<IActionResult> GetGridFilter(string gridKey)
        {
            return this.Ok(await this.Mediator.Send(
                new GetGridFilterQuery
                {
                    GridKey = gridKey
                }
            ));
        }

        [HttpPost]
        [Route("grid/filter")]
        public async Task<IActionResult> SaveGridFilter(FilterDto filterBody)
        {
            return this.Ok(await this.Mediator.Send(
                new CreateGridFilterCommand {
                    GridFilterId = filterBody.GridFilterId,
                    Filter = filterBody.Filter,
                    GridKey = filterBody.GridKey
                }
            ));
        }
    }
}
