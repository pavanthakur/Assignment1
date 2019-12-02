using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Repository
{
    //This is just to show how we can extend the base repository and have our own implementation on top of generic repository

    public interface ICookiePackingRepository : IRepository<CookiePacking>
    {

        Task<CookiePacking> GetByName(string name);

    }
    public class CookiePackingRepository : EfCoreRepository<CookiePacking>, ICookiePackingRepository
    {

        public CookiePackingRepository(ApplicationDbContext context) : base(context) { }

        public Task<CookiePacking> GetByName(string name)
            => FirstOrDefault(w => w.Name == name);

    }
}
