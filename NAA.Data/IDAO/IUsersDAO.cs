using NAA.Data.Models.Domain;
using NAA.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.IDAO
{
    public interface IUsersDAO
    {
        User GetUser(Application application, NAAContext context);
        void RemoveApplicationFromCollection(Application application, User user, NAAContext context);
    }
}
