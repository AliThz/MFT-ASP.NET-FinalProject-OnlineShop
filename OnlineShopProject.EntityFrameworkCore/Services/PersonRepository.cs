using Microsoft.EntityFrameworkCore;
using OnlineShopProject.Domain.Aggregates.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.EntityFrameworkCore.Services
{
    public class PersonRepository : 
        Frameworks.Base.BaseRepository<OnlineShopProjectDbContext, Domain.Aggregates.PersonAggregate.Person, Guid>,
        Domain.Reporities.IPersonRepository
    {
        #region [ - Ctor - ]
        public PersonRepository(OnlineShopProjectDbContext dbContext) : base(dbContext)
        {

        }
        #endregion

        #region [ - Method - ]

        #region [ - GetPersonByNameAsync(string firstName, string lastName) - ]
        public async Task<Person> GetPersonByNameAsync(string firstName, string lastName)
        {
            return await DbSet.FirstOrDefaultAsync(p => p.FirstName == firstName & p.LastName == lastName);
        }
        #endregion

        #endregion
    }
}
