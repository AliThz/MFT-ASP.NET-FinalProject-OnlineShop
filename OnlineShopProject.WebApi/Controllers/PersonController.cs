using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopProject.WebApi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        #region [ - Ctor - ]
        public PersonController(Application.Abstracts.IPersonApplicationService personApplicationService)
        {
            PersonApplicationService = personApplicationService;
        }
        #endregion

        #region [ - Prop - ]
        public Application.Abstracts.IPersonApplicationService PersonApplicationService { get; set; }
        #endregion

        #region [ - Actions - ]

        #region [ - GetPersonAsync(Guid id) - ]
        [Route("wapi/v1/1")]
        [HttpGet]
        public async Task<Application.DTOs.PersonDTOs.PersonDTO> GetPersonAsync(Guid id)
        {
            return await PersonApplicationService.GetAsync(id);
        }
        #endregion

        #region [ - GetListPersonAsync() - ]
        [Route("wapi/v1/2")]
        [HttpGet]
        public async Task<List<Application.DTOs.PersonDTOs.PersonDTO>> GetListPersonAsync()
        {
            return await PersonApplicationService.GetListAsync();
        }
        #endregion

        #region [ - CreatePersonAsync - ]
        [Route("wapi/v1/3")]
        [HttpPost]
        public async Task<Application.DTOs.PersonDTOs.PersonDTO> CreatePersonAsync(Application.DTOs.PersonDTOs.CreatePersonDTO input)
        {
            return await PersonApplicationService.CreateAsync(input);
        }
        #endregion

        #region [ - UpdatePersonAsync - ]
        [Route("wapi/v1/4")]
        [HttpPut]
        public async Task UpdatePersonAsync(Guid id, Application.DTOs.PersonDTOs.UpdatePersonDTO input)
        {
            await PersonApplicationService.UpdateAsync(id, input);
        }
        #endregion

        #region [- DeletePersonAsync -]
        [Route("wapi/v1/5")]
        [HttpDelete]
        public async Task DeletePersonAsync(Guid id)
        {
            await PersonApplicationService.DeleteAsync(id);
        }
        #endregion 

        #endregion
    }
}
