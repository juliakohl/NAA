using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.IDAO;
using NAA.Data.Models.Domain;
using NAA.Data.Repository;

namespace NAA.Data.DAO
{
    public class UsersDAO : IUsersDAO
    {
        public User GetUser(Application application, NAAContext context)
        {
            IList<User> users = context.Users.ToList();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Applications.Contains(application))
                {
                    return users[i];
                }
            }
            return null;
        }

        public void RemoveApplicationFromCollection(Application application, User user, NAAContext context)
        {
            context.Users.Find(user.UserId).Applications.Remove(application);
        }
    }
}
