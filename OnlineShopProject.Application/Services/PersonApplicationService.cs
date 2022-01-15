using AutoMapper;
using OnlineShopProject.Application.DTOs.PersonDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Application.Services
{
    public class PersonApplicationService : Abstracts.IPersonApplicationService
    {
        #region [ - Ctor - ]
        public PersonApplicationService(Domain.Reporities.IPersonRepository personRepository, Domain.Factories.PersonFactory.PersonFactoryService personFactory, IMapper mapper)
        {
            PersonRepository = personRepository;
            PersonFactory = personFactory;
            Mapper = mapper;
        }
        #endregion

        #region [ - Props - ]
        public Domain.Reporities.IPersonRepository PersonRepository { get; set; }
        public Domain.Factories.PersonFactory.PersonFactoryService PersonFactory { get; set; }
        public IMapper Mapper { get; set; }
        #endregion

        #region [ - Methods - ]

        #region [ - CreateAsync(CreatePersonDTO input) - ]
        public async Task<PersonDTO> CreateAsync(CreatePersonDTO input)
        {
            var person = await PersonFactory.CreateAsync(input.FirstName, input.LastName);
            await PersonRepository.InsertAsync(person);
            return Mapper.Map<Domain.Aggregates.PersonAggregate.Person, PersonDTO>(person);
        }
        #endregion

        #region [ - UpdateAsync(Guid id, UpdatePersonDTO input) - ]
        public async Task UpdateAsync(Guid id, UpdatePersonDTO input)
        {
            var person = await PersonRepository.FindByIdAsync(id);
            if (person != null)
            {
                person.FirstName = input.FirstName;
                person.LastName = input.LastName;
                await PersonRepository.UpdateAsync(person);
            }
        } 
        #endregion

        #region [ - DeleteAsync(Guid id) - ]
        public async Task DeleteAsync(Guid id)
        {
            await PersonRepository.DeleteAsync(id);
        }
        #endregion

        #region [ - GetAsync(Guid id) - ]
        public async Task<PersonDTO> GetAsync(Guid id)
        {
            var person = await PersonRepository.FindByIdAsync(id);
            return Mapper.Map<PersonDTO>(person);
        }
        #endregion

        #region [ - GetListAsync() - ]
        public async Task<List<PersonDTO>> GetListAsync()
        {
            var people = await PersonRepository.Select();
            return Mapper.Map<List<PersonDTO>>(people);
        }
        #endregion

        #endregion
    }
}
