using GenericLayer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Shops.Controllers
{
    [Controller]
    public class RootController<T> : ControllerBase
    {
        protected void SetHeader(PagedList<T> pageList)
        {
            var metadata = new
            {
                pageList.TotalCount,
                pageList.PageSize,
                pageList.CurrentPage,
                pageList.TotalPages,
                pageList.HasNext,
                pageList.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
        }
    }
}
