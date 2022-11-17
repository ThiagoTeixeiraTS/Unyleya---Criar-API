using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnyleyaAtividade3.Model;

namespace UnyleyaAtividade3.Repositories
{
    public interface ICopaniesRespository
    {
        Task<IEnumerable<Companies>> Get();

        Task<Companies> Get(int Id);

        Task<Companies> Create(Companies companies);
        Task Update(Companies companies);

        Task Delete(int Id);

        Task<List<Companies>> GetByName(string name);
        Task<List<Companies>> GetByAdress(string name);

    }
}
