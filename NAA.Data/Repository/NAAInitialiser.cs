using NAA.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.Repository
{
    public class NAAInitialiser : System.Data.Entity.DropCreateDatabaseIfModelChanges<NAAContext>
    {
        protected override void Seed(NAAContext context)
        {
            Application a1 = new Application() { Course = "IT-Security" };
            Application a2 = new Application() { Course = "Business Software" };
            Application a3 = new Application() { Course = "Data Science" };
            context.Applications.Add(a1);
            context.Applications.Add(a2);
            context.Applications.Add(a3);
        }
    }
}
