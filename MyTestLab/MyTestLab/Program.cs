using System;
using System.Reflection;
using MyTestLabDalModel;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace MyTestLab
{
    public class Program
    {
        static void Main(string[] args)
        {
            Configuration cfg = new Configuration().DataBaseIntegration(db =>
            {
                db.ConnectionString = "Data Source=.;Initial Catalog=MyTestLab;Integrated Security=SSPI";
                db.Dialect<MsSql2012Dialect>();
            });

            /* Add the mapping we defined: */
            var mapper = new ModelMapper();
            mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
            mapper.AddMappings(typeof(Person).Assembly.GetTypes());
            HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            cfg.AddMapping(mapping);

            /* Create a session and execute a query: */
            using (ISessionFactory factory = cfg.BuildSessionFactory())
            {
                using (ISession session = factory.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        var person = session.Get<Person>(1);
                        person.FirstName = "Nirav";
                        tx.Commit();
                        Console.WriteLine(person.FirstName);
                    }
                }
            }

            Console.ReadLine();
        }
    }
    
}
