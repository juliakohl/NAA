using NAA.Data.Models.Domain;
using NAA.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Services.IService
{
    public interface IApplicationService
    {
        IList<Application> GetApplications();

        Application GetApplication(int id);

        void DeleteApplication(int applicationId, string userId);
    }
}
