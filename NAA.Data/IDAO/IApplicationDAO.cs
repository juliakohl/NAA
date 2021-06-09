using NAA.Data.Models.Domain;
using NAA.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.IDAO
{
    public interface IApplicationDAO
    {
        IList<Application> GetApplications(NAAContext context);

        Application GetApplication(int applicationId, NAAContext context);

        void DeleteApplication(Application application, NAAContext context);
    }
}
