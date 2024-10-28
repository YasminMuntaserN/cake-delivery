using CakeDeliveryDTO.UserDtos;
using DataAccessLayer;
using DTOs;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.User
{
    public class Users
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public Users(UserDTO UserDto, enMode mode = enMode.AddNew)
        {
            UserID = UserDto.UserID;
            Email = UserDto.Email;
            Password = UserDto.Password;
            Mode = mode;
        }

        public UserDTO ToUserDto() =>
            new UserDTO(UserID, Email, Password);

        public static UserDTO getUserById(int id)
        {
            return UserData.GetUserById(id);
        }
        private bool _Add()
        {
            UserID = UserData.Add(new UserCreateDTO( Email, Password));
            return UserID.HasValue;
        }

        private bool _Update()
        {
            return UserData.UpdateUser(new UserDTO(UserID, Email, Password));
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_Add())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();
            }

            return false;
        }


        public static List<UserDTO> All()
            => UserData.GetAllUsers();

        public static bool ExsistByPasswordAndEmail(string Email, string Password)
          => UserData.ExsistByPasswordAndEmail(Email, Password);

    }
}

