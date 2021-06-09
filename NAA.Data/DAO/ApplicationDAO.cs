using NAA.Data.IDAO;
using NAA.Data.Models.Domain;
using NAA.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.DAO
{
    public class ApplicationDAO : IApplicationDAO
    {
        public IList<Application> GetApplications(NAAContext context)
        {
            return context.Applications.ToList();
        }

        public Application GetApplication(int applicationId, NAAContext context)
        {
            return context.Applications.Find(applicationId);
        }

        public void DeleteApplication(Application application, NAAContext context)
        {
            context.Applications.Remove(application);
        }
    }
}
