using System.Collections.Generic;
using PcPartPickerBackendAPI.Models;

namespace PcPartPickerBackendAPI.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
    }
}
