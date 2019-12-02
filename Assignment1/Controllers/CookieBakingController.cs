using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment1.Models;
using Assignment1.Repository;

namespace Assignment1.Controllers
{
    //Authorize attribute for cookie baking role
    [Route("api/[controller]")]
    [ApiController]
    public class CookieBakingController : ControllerBase
    {
        private EfCoreRepository<Order> _orderRepository;
        private EfCoreRepository<CookieBaking> _cookieBakingRepository;

        public CookieBakingController(EfCoreRepository<Order> orderRepository,
            EfCoreRepository<CookieBaking> cookieBakingRepository)
        {
            _orderRepository = orderRepository;
            _cookieBakingRepository = cookieBakingRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            try
            {
                //Note : we can add validation here
                var orderid = await _orderRepository.Add(order);

                return CreatedAtAction("PostOrder", new { id = orderid }, order);

            }
            catch (System.Exception)
            {
                //Note : plan is to use global error handling as given in below link
                //https://docs.microsoft.com/en-us/aspnet/core/web-api/handle-errors?view=aspnetcore-3.0
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<ActionResult<CookieBaking>> BakeCookieForMixing(CookieBaking cookieBaking)
        {
            var cookieBakingid = await _cookieBakingRepository.Add(cookieBaking);
            cookieBaking.IsMixed = true;
            await _cookieBakingRepository.Update(cookieBaking);
            return CreatedAtAction("BakeCookieForMixing", new { id = cookieBakingid }, cookieBaking);
        }

        [HttpPut]
        public async Task<ActionResult<CookieBaking>> BakeCookieForLaminating(CookieBaking cookieBaking)
        {
            cookieBaking.IsLaminated = true;
            await _cookieBakingRepository.Update(cookieBaking);
            return CreatedAtAction("BakeCookieForLaminating", cookieBaking);
        }

        [HttpPut]
        public async Task<ActionResult<CookieBaking>> BakeCookieForForming(CookieBaking cookieBaking)
        {
            cookieBaking.IsFormmingDone = true;
            await _cookieBakingRepository.Update(cookieBaking);
            return CreatedAtAction("BakeCookieForForming", cookieBaking);
        }

        [HttpPut]
        public async Task<ActionResult<CookieBaking>> BakeCookieForBaking(CookieBaking cookieBaking)
        {
            cookieBaking.IsBaked = true;
            await _cookieBakingRepository.Update(cookieBaking);
            return CreatedAtAction("BakeCookieForBaking", cookieBaking);
        }
    }
}
