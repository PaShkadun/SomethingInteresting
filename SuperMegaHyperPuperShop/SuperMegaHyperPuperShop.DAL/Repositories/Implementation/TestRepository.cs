using SuperMegaHyperPuperShop.DAL.Datas;
using SuperMegaHyperPuperShop.DAL.Entities;
using SuperMegaHyperPuperShop.DAL.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.DAL.Repositories.Implementation
{
    public class TestRepository : ITestRepository
    {
        private readonly DataContext _data;

        public TestRepository(DataContext data)
        {
            _data = data;
        }

        public async Task<PersonEntity> Create(PersonEntity person)
        {
            var result = await _data.Persons.AddAsync(person);
            await _data.SaveChangesAsync();

            return result.Entity;
        }
    }
}
