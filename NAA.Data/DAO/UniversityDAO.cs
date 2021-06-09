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
    public class UniversityDAO : IUniversityDAO
    {
        public University GetUniversity(Application application, NAAContext context)
        {
            IList<University> universities = context.Universities.ToList();
            for (int i = 0; i < universities.Count; i++)
            {
                if (universities[i].Applications.Contains(application))
                {
                    return universities[i];
                }
            }
            return null;
        }

        public void RemoveApplicationFromCollection(Application application, University university, NAAContext context)
        {
            context.Universities.Find(university.UniversityId).Applications.Remove(application);
        }
    }
}
 