﻿using Business_Layer.Order;
using Microsoft.AspNetCore.Mvc;
using Validation;

namespace CakeDeliveryAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ActionResult<IEnumerable<TDto>> GetAllEntities<TDto>(
            Func<IEnumerable<TDto>> getAllEntities)
        {
            var entities = getAllEntities();
            if (entities == null || !entities.Any())
            {
                return NotFound("No entities found!");
            }
            return Ok(entities);
        }

      
        protected ActionResult<TDto> GetEntityByIdentifier<TDto, TKey>(
        TKey identifier,
        Func<TKey, TDto?> findEntity,
        Func<TDto, ActionResult<TDto>> createResponse)
        {
            if (identifier == null || (identifier is int id && id < 1))
            {
                return BadRequest($"Not accepted identifier {identifier}");
            }

            TDto? entity = findEntity(identifier);
            if (entity == null)
            {
                return NotFound($"Entity with identifier {identifier} not found.");
            }

            return createResponse(entity);
        }



        protected ActionResult DeleteEntity<T>(int id, Func<int, bool> deleteFunc, string entityName)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID: {id}");
            }

            bool isDeleted = deleteFunc(id);
            if (isDeleted)
            {
                return Ok(new { Message = $"{entityName} with ID {id} has been successfully deleted." });
            }

            return NotFound(new { Error = $"{entityName} with ID {id} not found. No rows deleted." });
        }


        protected ActionResult<List<TDto>> GetAllEntitiesBy<TEntity, TDto, Tvalue>(
            Tvalue value,
            Func<Tvalue, List<TDto>> findEntitiesFunc,
            string entityName)
        {
            if (value == null || (value is string str && string.IsNullOrWhiteSpace(str)))
            {
                return BadRequest($"Invalid {entityName} to search by {value}.");
            }

            var entities = findEntitiesFunc(value);
            if (entities == null || entities.Count == 0)
            {
                return NotFound($"No {entityName}(s) found for the given criteria.");
            }

            return Ok(entities);
        }

        protected ActionResult<List<TDto>> GetAllEntitiesBy<TEntity, TDto, Tvalue>(
            Tvalue value1,
            Tvalue value2,
            Func<Tvalue, Tvalue, List<TDto>> findEntitiesFunc,
            string entityName)
        {
            if (value1 == null || (value1 is string str1 && string.IsNullOrWhiteSpace(str1)))
            {
                return BadRequest($"Invalid {entityName} to search by {value1}.");
            }
            if (value2 == null || (value2 is string str2 && string.IsNullOrWhiteSpace(str2)))
            {
                return BadRequest($"Invalid {entityName} to search by {value2}.");
            }

            var entities = findEntitiesFunc(value1, value2);
            if (entities == null || entities.Count == 0)
            {
                return NotFound($"No {entityName}(s) found for the given criteria.");
            }

            return Ok(entities);
        }
    }
   
    
       /* protected ActionResult<T> AddEntity<TCreateDto, T>(
    TCreateDto createDto,
    Func<TCreateDto, T> createEntityFunc,
    Func<T, bool> saveEntityFunc,
    BaseValidator<T> validator,
    string routeName,
    object routeValues)
     {
         if (createDto == null)
         {
             return BadRequest("Invalid data.");
         }

         // Create the entity from the DTO
         T entity = createEntityFunc(createDto);

         // Validate the entity
         var validationResult = validator.Validate(entity);
         if (!validationResult.IsValid)
         {
             return BadRequest(new
             {
                 Success = false,
                 Errors = validationResult.Errors
             });
         }

         if (saveEntityFunc(entity))
         {
             return CreatedAtRoute(routeName, routeValues, entity); 
         }

         return BadRequest("Unable to create entity.");
     }*/

}

