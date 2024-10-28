using Business_Layer.Cake;
using Business_Layer.User;
using Business_Layer.Order;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Metrics;
using System.Net;
using CakeDeliveryDTO.UserDtos;

namespace CakeDeliveryAPI.Controllers
{

    [Route("api/Users")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly UserValidator _validator = new UserValidator();

        // GET: api/Users/all
        [HttpGet("all", Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<UserDTO>> GetAllUsers()
             => GetAllEntities(() => Users.All());

        
        // GET: api/Users/{id}
        [HttpGet("{id:int}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDTO> GetUserById(int id)
              => GetEntityByIdentifier(id, key => Users.getUserById(id), User => Ok(User));
       

      
        // POST: api/Users
        [HttpPost(Name = "AddUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserDTO> AddUser([FromBody] UserCreateDTO newUserDTO)
        {
            if (newUserDTO == null)
            {
                return BadRequest("Invalid User data.");
            }

            Users UserInstance = new Users(
                new UserDTO(
                    null,
                    newUserDTO.Email,
                    newUserDTO.Password
                ),
                Users.enMode.AddNew
            );

            var validationResult = _validator.Validate(UserInstance);
            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = validationResult.Errors
                });
            }

            if (UserInstance.Save())
            {
                var locationUrl = Url.Link("GetUserById", new { id = UserInstance.UserID });

                return Ok(locationUrl);
            }

            return BadRequest("Unable to create User.");
        }


        // PUT: api/Users/{id}
        [HttpPut("{id}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDTO> UpdateUser(int id, UserDTO updatedUser)
        {
            if (id < 1 || updatedUser == null )
            {
                return BadRequest("Invalid User data.");
            }

            UserDTO? existingUser = Users.getUserById(id);
            if (existingUser == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            Users UserInstance = new Users(updatedUser, Users.enMode.Update);

            // Validate the User instance
            var validationResult = _validator.Validate(UserInstance);
            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = validationResult.Errors
                });
            }

            if (UserInstance.Save())
            {
                return Ok(UserInstance.ToUserDto());
            }

            return StatusCode(500, new { message = "Error updating User." });
        }


        // Get: api/Users/{Email ,password}
        [HttpGet("{Email}/{Password}", Name = "ExsistByPasswordAndEmailassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult ExsistByPasswordAndEmailassword(string Email, string Password)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                return BadRequest("Invalid User data.");
            }

            bool isExsist = Users.ExsistByPasswordAndEmail(Email.Trim(), Password.Trim());
            Console.WriteLine(isExsist);

            return Ok(isExsist);

        }
    }
}
