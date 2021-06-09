using NAA.Data.DAO;
using NAA.Data.IDAO;
using NAA.Data.Models.Domain;
using NAA.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Services.IService
{
    public class ApplicationService : IApplicationService
    {
        private IApplicationDAO applicationDAO;
        private IUniversityDAO universityDAO;
        private IUsersDAO usersDAO;

        public ApplicationService()
        {
            applicationDAO = new ApplicationDAO();
            universityDAO = new UniversityDAO();
            usersDAO = new UsersDAO();
        }

        public IList<Application> GetApplications()
        {
            using (var context = new NAAContext())
            {
                return applicationDAO.GetApplications(context);
            }     
        }

        public Application GetApplication(int id)
        {
            using (var context = new NAAContext())
            {
                return applicationDAO.GetApplication(id, context);
            }
        }

        public void DeleteApplication(int applicationId, string userId)
        {
            using (var context = new NAAContext())
            {
                Application application = applicationDAO.GetApplication(applicationId, context);

                University university = universityDAO.GetUniversity(application, context);
                universityDAO.RemoveApplicationFromCollection(application, university, context);
                User user = usersDAO.GetUser(application, context);
                usersDAO.RemoveApplicationFromCollection(application, user, context);
                
                applicationDAO.DeleteApplication(application, context);
                
                context.SaveChanges();

            }
        }

    }
}
