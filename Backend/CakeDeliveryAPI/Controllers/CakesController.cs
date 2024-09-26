using Business_Layer;
using CakeDeliveryDTO.CakeDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/cakes")]
[ApiController]
public class CakesController : ControllerBase
{
    [HttpGet("All", Name = "GetAllCakes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<CakeDTO>> GetAllCakes()
    {
        List<CakeDTO> cakesList = clsCake.All();
        if (cakesList.Count == 0)
        {
            return NotFound("No Cakes Found!");
        }
        return Ok(cakesList);
    }

 
    [HttpGet("{id}", Name = "GetCakeById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<CakeDTO> GetCakeById(int id)
    {
        if (id < 1)
        {
            return BadRequest($"Not accepted ID {id}");
        }

        CakeDTO? cake = clsCake.FindCakeById(id);
        if (cake == null)
        {
            return NotFound($"Cake with ID {id} not found.");
        }

        return Ok(cake);
    }

   
    [HttpGet("name/{cakeName}", Name = "GetCakeByName")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<CakeDTO> GetCakeByName(string cakeName)
    {
        CakeDTO? cake = clsCake.FindCakeByName(cakeName);
        if (cake == null)
        {
            return NotFound($"Cake with name '{cakeName}' not found.");
        }
        return Ok(cake);
    }

   
    [HttpPost(Name = "AddCake")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<CakeDTO> AddCake([FromBody] CakeCreateDto newCakeDTO)
    {
        if (newCakeDTO == null || string.IsNullOrEmpty(newCakeDTO.CakeName))
        {
            return BadRequest("Invalid cake data.");
        }

        clsCake cakeInstance = new clsCake(
            new CakeDTO(null, newCakeDTO.CakeName, newCakeDTO.Description, newCakeDTO.Price, newCakeDTO.StockQuantity, newCakeDTO.CategoryID, newCakeDTO.ImageUrl),
            clsCake.enMode.AddNew
        );

        if (cakeInstance.Save())
        {
            return CreatedAtRoute("GetCakeById", new { id = cakeInstance.CakeID }, newCakeDTO);
        }
        return BadRequest("Unable to create cake.");
    }

 
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

        CakeDTO? existingCake = clsCake.FindCakeById(id);
        if (existingCake == null)
        {
            return NotFound($"Cake with ID {id} not found.");
        }

        clsCake cakeInstance = new clsCake(updatedCake, clsCake.enMode.Update);
        if (cakeInstance.Save())
        {
            return Ok(cakeInstance.ToCakeDto());
        }

        return StatusCode(500, new { message = "Error updating cake." });
    }

   
    [HttpDelete("{id}", Name = "DeleteCake")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteCake(int id)
    {
        if (id < 1)
        {
            return BadRequest($"Not accepted ID {id}");
        }

        if (clsCake.Delete(id))
        {
            return Ok($"Cake with ID {id} has been deleted.");
        }

        return NotFound($"Cake with ID {id} not found. No rows deleted!");
    }

 
    [HttpGet("category/{category}", Name = "GetCakesByCategory")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<CakeDTO>> GetCakesByCategory(int category)
    {
        List<CakeDTO> cakesList = clsCake.AllByCategoryID(category);
        if (cakesList.Count == 0)
        {
            return NotFound($"No Cakes found in category ID '{category}'!");
        }
        return Ok(cakesList);
    }


    [HttpGet("category/name/{categoryName}", Name = "GetCakesByCategoryName")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<CakeDTO>> GetCakesByCategoryName(string categoryName)
    {
        List<CakeDTO> cakesList = clsCake.AllByCategoryName(categoryName);
        if (cakesList.Count == 0)
        {
            return NotFound($"No Cakes found in category name '{categoryName}'!");
        }
        return Ok(cakesList);
    }
}
