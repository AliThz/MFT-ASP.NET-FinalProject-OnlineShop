using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Domain.Aggregates.PersonAggregate
{
    public class Person : Frameworks.Base.Entity
    {
        #region [ - Ctor - ]
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        #endregion

        public string FirstName { get; set; }
        public string LastName { get; set; } 
    }
}
