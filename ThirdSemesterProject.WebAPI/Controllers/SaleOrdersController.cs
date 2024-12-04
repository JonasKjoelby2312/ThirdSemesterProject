using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ThirdSemesterProject.DAL.DAOs;
using ThirdSemesterProject.DAL.Model;
using ThirdSemesterProject.WebAPI.DTOs;
using ThirdSemesterProject.WebAPI.DTOs.DTOConverter;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThirdSemesterProject.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SaleOrdersController : ControllerBase
{
    ISaleOrderDAO _saleOrderDAO;

    public SaleOrdersController(ISaleOrderDAO saleOrderDAO)
    {
        _saleOrderDAO = saleOrderDAO;
    }


    // GET: api/<SaleOrdersController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SaleOrderDTO>>> Get([FromQuery] int id)
    {
        IEnumerable<SaleOrder> saleOrders;
        if (id != 0)
        {
            saleOrders = await _saleOrderDAO.GetAllSaleOrders(id);
            return Ok(saleOrders.ToDTOs());
        }
        else
        {
            return NotFound();
        }
    }

    // POST api/<SaleOrdersController>
    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] SaleOrderDTO saleOrderDTO)
    {

        return Ok(await _saleOrderDAO.CreateAsync(saleOrderDTO.FromDTO()));

    }

    // PUT api/<SaleOrdersController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<SaleOrdersController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<OrderLineWithProductsDTO>>> GetOrderLinesWithProducts(int id)
    {
        IEnumerable<OrderLineWithProducts> orderLinesWithProducts;

        if (id > 0)
        {
            orderLinesWithProducts = await _saleOrderDAO.GetAllOrderLinesWithProductsBySaleOrderId(id);
            return Ok(orderLinesWithProducts.ToDTOs()); 
        } else 
        { 
            return NotFound();
        }
    }
}
