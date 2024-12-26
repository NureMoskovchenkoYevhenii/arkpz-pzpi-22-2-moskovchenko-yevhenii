using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void AddUser(User user)
    {
        user.PasswordHash = HashPassword(user.PasswordHash);
        _userRepository.Add(user);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAll();
    }

    public User GetUserById(int userId)
    {
        return _userRepository.GetById(userId);
    }

    public void UpdateUser(int userId, User updatedUser)
    {
        var user = _userRepository.GetById(userId);
        if (user != null)
        {
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.PhoneNumber = updatedUser.PhoneNumber;
            user.Role = updatedUser.Role;

            if (!string.IsNullOrEmpty(updatedUser.PasswordHash))
            {
                user.PasswordHash = HashPassword(updatedUser.PasswordHash);
            }

            _userRepository.Update(user);
        }
    }

    public void DeleteUser(int userId)
    {
        _userRepository.Delete(userId);
    }

    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}
