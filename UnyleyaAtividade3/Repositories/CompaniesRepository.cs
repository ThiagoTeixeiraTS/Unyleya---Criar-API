using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnyleyaAtividade3.Context;
using UnyleyaAtividade3.Model;

namespace UnyleyaAtividade3.Repositories
{
    public class CompaniesRepository : ICopaniesRespository
    {

        public readonly CompanyContext _context;

        public CompaniesRepository(CompanyContext context)
        {
            _context = context;
        }

        public async Task<Companies> Create(Companies companies)
        {
            _context.Companies.Add(companies);
            await _context.SaveChangesAsync();
            return companies;
        }

        public async Task Delete(int Id)
        {

            var companies = await _context.Companies.FindAsync(Id);
            _context.Remove(companies);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Companies>> Get()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Companies> Get(int Id)
        {

            return await _context.Companies.FindAsync(Id);

        }

        public async Task<List<Companies>> GetByName(string name)
        {
            return await _context.Companies.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<List<Companies>> GetByAdress(string adress)
        {
            return await _context.Companies.Where(x => x.Adress.Contains(adress)).ToListAsync();
        }


        public async Task Update(Companies companies)
        {
            _context.Entry(companies).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
