using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ThirdSemesterProject.DAL.DAOs;
using ThirdSemesterProject.DAL.Model;
using ThirdSemesterProject.WebAPI.DTOs;
using ThirdSemesterProject.WebAPI.DTOs.DTOConverter;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThirdSemesterProject.WebAPI.Controllers;


/// <summary>
/// APIController for managing saleOrder realted operations. 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SaleOrdersController : ControllerBase
{
    ISaleOrderDAO _saleOrderDAO;



    /// <summary>
    /// Initializes a new instance of the <see cref="SaleOrdersController"/> class
    /// And sets up dependency on a saleOrder data access object.
    /// </summary>
    /// <param name="dao"></param> The data access object saleOrder, and is used for database operations.</param>
    public SaleOrdersController(ISaleOrderDAO saleOrderDAO)
    {
        _saleOrderDAO = saleOrderDAO;
    }

    /// <summary>
    /// This HttpGet is used to retrive all saleOrders.
    /// </summary>
    /// <param name="id"></param>
    /// <returns> All saleOrders from the database</returns>
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

    /// <summary>
    /// This HttpPost adds a new saleOrder to the database.
    /// </summary>
    /// <param name="saleOrderDTO">The saleOrder to add</param>
    /// <returns>
    /// The newly created saleOrder. 
    /// </returns>
    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] SaleOrderDTO saleOrderDTO)
    {
        return Ok(await _saleOrderDAO.CreateAsync(saleOrderDTO.FromDTO()));
    }

    /// <summary>
    /// This HttpGet is used to get a single saleOrder from the database with given id.
    /// </summary>
    /// <param name="id">The identifyer for the saleOrder </param>
    /// <returns> 
    /// Returns a saleOrder from the database, if it does not exsist it will throw a 404 error not found.
    /// </returns>
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
