using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTestLabDalModel
{
    public class PersonMap : ClassMapping<Person>
    {
        public PersonMap()
        {
            this.Table("person");
            this.Id(p => p.Id);
            this.Property(p => p.FirstName);
            this.Property(p => p.LastName);
            this.Property(p => p.BirthDate);

        }
    }
}
