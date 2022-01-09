using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopProject.Application.Abstracts
{
    [ScopedService]
    public interface IPersonApplicationService
    {
        Task<DTOs.PersonDTOs.PersonDTO> CreateAsync(DTOs.PersonDTOs.CreatePersonDTO input);

        Task UpdateAsync(Guid id, DTOs.PersonDTOs.UpdatePersonDTO input);

        Task DeleteAsync(Guid id);

        Task<DTOs.PersonDTOs.PersonDTO> GetAsync(Guid id);

        Task<List<DTOs.PersonDTOs.PersonDTO>> GetListAsync();
    }
}
