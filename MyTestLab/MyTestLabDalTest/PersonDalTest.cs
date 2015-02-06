using System.Configuration;
using System.Data;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTestLabDalModel;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using Configuration = NHibernate.Cfg.Configuration;

namespace MyTestLabDalTest
{
    [TestClass]
    public class PersonDalTest
    {
        private static Configuration cfg;
        private static ISessionFactory factory;
        protected ISession session;

        [TestInitialize]
        public void SetUp()
        {
            cfg = new Configuration().DataBaseIntegration(db =>
            {
                db.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                db.Dialect<MsSql2008Dialect>();
                db.IsolationLevel = IsolationLevel.ReadCommitted;
            });

            /* Add the mapping we defined: */
            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(Person).Assembly.GetTypes());

            HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            cfg.AddMapping(mapping);

            /* Create a session and execute a query: */
            factory = cfg.BuildSessionFactory();
            session = factory.OpenSession();

        }

        [TestCleanup]
        public void TearDown()
        {
            session.Dispose();
        }

        [TestMethod]
        public void WhenGets_Called_Then_Retrieve_Record()
        {
            var person = session.Get<Person>(1);
            Assert.IsNotNull(person);
            Assert.IsInstanceOfType(person, typeof(Person));
        }

        [TestMethod]
        public void WhenUpdate_Is_Called_Then_Retrieve_Record()
        {
            var person = session.Get<Person>(1);
            person.FirstName = "Test";
            Assert.AreEqual("Test", person.FirstName);
        }
    }
}
