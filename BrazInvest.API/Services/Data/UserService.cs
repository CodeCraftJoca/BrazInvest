using Infrastructure.Db.Repository.Interface;
using Infrastructure.Dto;
using models;
using Services.Interface;
using System;
using System.Text.RegularExpressions;

namespace Services.Data
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository _userrepository)
        {
            this.userRepository = _userrepository;
        }

        public UserDto AddUser(string username, string password, string email)
        {
            try
            {
                if (!ValidateEmail(email))
                    throw new ArgumentException("Email does not meet the requirements, please check and try again");

                if (!ValidatePassword(password))
                    throw new ArgumentException("Password does not meet the requirements, please check and try again");

                if (!ValidateUserName(username))
                    throw new ArgumentException("User does not meet the requirements, please check and try again");

                return userRepository.addUser(username, password, email);
            }
            catch (ArgumentException ex)
            {
                
                Console.WriteLine($"Error adding user: {ex.Message}");
                throw; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error adding user: {ex.Message}");
                throw;
            }
        }

        public bool ValidateUserName(string username)
        {
            return !int.TryParse(username, out _);
        }

        public bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        public bool ValidatePassword(string password)
        {
            // Verifica se a senha não é inteiramente numérica
            if (int.TryParse(password, out _))
                return false;

            // Verifica se a senha contém pelo menos uma letra maiúscula
            if (!password.Any(char.IsUpper))
                return false;

            // Verifica se a senha tem pelo menos 6 caracteres
            return password.Length >= 6;
        }
    }
}
