using Business_Layer.Cake;
using Business_Layer.Order;
using CakeDeliveryAPI.Controllers;
using CakeDeliveryDTO.CakeDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/cakes")]
[ApiController]
public class CakesController : BaseController
{
    private readonly CakeValidator _validator = new CakeValidator();

    // GET: api/cakes/all
    [HttpGet("All", Name = "GetAllCakes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<CakeDTO>> GetAllCakes()
        => GetAllEntities(() => Cake.All());


    // GET: api/cakes/{id}
    [HttpGet("{id}", Name = "GetCakeById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<CakeDTO> GetCakeById(int id)
        => GetEntityByIdentifier(id, Cake.FindCakeById, cake => Ok(cake));


    // GET: api/cakes/name/{cakeName}
    [HttpGet("name/{cakeName}", Name = "GetCakeByName")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<CakeDTO> GetCakeByName(string cakeName)
        => GetEntityByIdentifier(cakeName, Cake.FindCakeByName, cake => Ok(cake));


    // POST: api/cakes
    [HttpPost(Name = "AddCake")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<CakeDTO> AddCake([FromBody] CakeCreateDto newCakeDTO)
    {
        if (newCakeDTO == null || string.IsNullOrEmpty(newCakeDTO.CakeName))
        {
            return BadRequest("Invalid cake data.");
        }

        Cake cakeInstance = new Cake(
            new CakeDTO(null, newCakeDTO.CakeName, newCakeDTO.Description, newCakeDTO.Price, newCakeDTO.StockQuantity, newCakeDTO.CategoryID, newCakeDTO.ImageUrl),
            Cake.enMode.AddNew
        );

        var validationResult = _validator.Validate(cakeInstance);
        if (!validationResult.IsValid)
        {
            return BadRequest(new
            {
                Success = false,
                Errors = validationResult.Errors
            });
        }

        if (cakeInstance.Save())
        {
            return CreatedAtRoute("GetCakeById", new { id = cakeInstance.CakeID }, newCakeDTO);
        }

        return BadRequest("Unable to create cake.");
    }


    // PUT: api/cakes/{id}
    [HttpPut("{id}", Name = "UpdateCake")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<CakeDTO> UpdateCake(int id, CakeDTO updatedCake)
    {
        if (id < 1 || updatedCake == null || string.IsNullOrEmpty(updatedCake.CakeName))
        {
            return BadRequest("Invalid cake data.");
        }

        CakeDTO? existingCake = Cake.FindCakeById(id);
        if (existingCake == null)
        {
            return NotFound($"Cake with ID {id} not found.");
        }

        Cake cakeInstance = new Cake(updatedCake, Cake.enMode.Update);

        var validationResult = _validator.Validate(cakeInstance);
        if (!validationResult.IsValid)
        {
            return BadRequest(new
            {
                Success = false,
                Errors = validationResult.Errors
            });
        }

        if (cakeInstance.Save())
        {
            return Ok(cakeInstance.ToCakeDto());
        }

        return StatusCode(500, new { message = "Error updating cake." });
    }


    // DELETE: api/cakes/{id}
    [HttpDelete("{id}", Name = "DeleteCake")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public ActionResult DeleteCake(int id)
      => DeleteEntity<Cake>(id, Cake.Delete, "Cake");


    // GET: api/cakes/category/{category}
    [HttpGet("category/{category}", Name = "GetCakesByCategory")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<List<CakeDTO>> GetCakesByCategory(int category)
        => GetAllEntitiesBy<int, CakeDTO, int>(category, Cake.AllByCategoryID, "Cake");


    // GET: api/cakes/category/name/{categoryName}
    [HttpGet("category/name/{categoryName}", Name = "GetCakesByCategoryName")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<List<CakeDTO>> GetCakesByCategoryName(string categoryName)
        => GetAllEntitiesBy<string, CakeDTO, string>(categoryName, Cake.AllByCategoryName, "Cake");

   
    // GET: api/cakes/page/number/{pageNumber}?pageSize={pageSize}
    [HttpGet("page/number/{pageNumber}", Name = "GetCakesByPage")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<List<CakeDTO>> GetCakesByPage(int pageNumber, [FromQuery] int pageSize)
    {
        // Validate page number and page size
        if (pageNumber <= 0)
        {
            return BadRequest("Page number must be greater than zero.");
        }

        if (pageSize <= 0)
        {
            return BadRequest("Page size must be greater than zero.");
        }

        // Call to your clsCake method to get cakes
        var cakes = Cake.GetCakesByPage(pageNumber, pageSize);
        if (cakes == null || cakes.Count == 0)
        {
            return NotFound("No cakes found for the given page.");
        }

        return Ok(cakes);
    }


    // GET: api/cakes/TotalPages/number/{categoryId}
    [HttpGet("TotalPages/number/{Id}", Name = "GetTotalPages")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetTotalPages(int Id )
    {
        // Validate the categoryId
        if (Id < -1)
        {
            return BadRequest("Category ID must be -1 or greater.");
        }

        // Variables to hold total rows and pages
        int totalRows;
        int totalPages;

        // Call the method to get total rows and pages
        Cake.GetTotalPagesAndRows(Id, out totalRows, out totalPages);

        return Ok(new
        {
            totalRows,
             totalPages
        });
    }
}
