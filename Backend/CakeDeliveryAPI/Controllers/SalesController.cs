using Business_Layer.Cake;
using CakeDeliveryDTO.CakeDTOs;
using CakeDeliveryDTO.SalesDTOs;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace CakeDeliveryAPI.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : BaseController
    {
        // GET: api/Sales/all
        [HttpGet("All", Name = "GetAllSales")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<SalesDTO>> GetAllSales()
            => GetAllEntities(() => SalesData.All());
    }
}
