using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopProject.Domain.Factories.PersonFactory
{
    [ScopedService]
    public class PersonFactory
    {
        #region [ - Ctor - ]
        public PersonFactory(Reporities.IPersonRepository personRepository)
        {
            PersonRepository = personRepository;
        }
        #endregion

        #region [ - Prop - ]
        public Reporities.IPersonRepository PersonRepository { get; set; }
        #endregion

        #region [ - Method - ]

        #region [ - CreateAsync(string firstName, string lastName) - ]
        public async Task<Aggregates.PersonAggregate.Person> CreateAsync(string firstName, string lastName)
        {
            var requestedPerson = await PersonRepository.GetPersonByNameAsync(firstName, lastName);
            if (requestedPerson != null)
            {
                return new Aggregates.PersonAggregate.Person(firstName, lastName);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #endregion
    }
}
