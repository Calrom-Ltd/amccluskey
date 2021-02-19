using GooglesRival.Models;
using System.Collections.Generic;

namespace GooglesRival.Controllers
{
    public interface IDataSource
    {
        List<User> GetUsers();
    }
}