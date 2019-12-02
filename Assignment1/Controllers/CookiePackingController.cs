using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment1.Models;
using Assignment1.Repository;

namespace Assignment1.Controllers
{
    //Authorize attribute for cookie packing role
    [Route("api/[controller]")]
    [ApiController]
    public class CookiePackingController : ControllerBase
    {
        private ICookiePackingRepository _cookiePackingRepository;

        public CookiePackingController(ICookiePackingRepository cookiePackingRepository)
        {
            _cookiePackingRepository = cookiePackingRepository;
        }

        [HttpPost]
        public async Task<ActionResult<CookiePacking>> PackCookieForFilling(CookiePacking cookiePacking)
        {
            var cookieBakingid = await _cookiePackingRepository.Add(cookiePacking);
            cookiePacking.IsFillingDone = true;
            await _cookiePackingRepository.Update(cookiePacking);
            return CreatedAtAction("PackCookieForMixing", new { id = cookieBakingid }, cookiePacking);
        }

        [HttpGet]
        public async Task<ActionResult<CookiePacking>> GetBytName(string name)
        {
            return await _cookiePackingRepository.GetByName(name);//this method is just to show custom implementation
        }

        [HttpPut]
        public async Task<ActionResult<CookiePacking>> PackCookieForLaminating(CookiePacking cookiePacking)
        {
            try
            {
                //Note : we can add validation here
                cookiePacking.IsCoolingDone = true;
                await _cookiePackingRepository.Update(cookiePacking);
                return CreatedAtAction("PackCookieForLaminating", cookiePacking);
            }
            catch (System.Exception)
            {
                //Note : plan is to use global error handling as given in below link
                //https://docs.microsoft.com/en-us/aspnet/core/web-api/handle-errors?view=aspnetcore-3.0
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<ActionResult<CookiePacking>> PackCookieForForming(CookiePacking cookiePacking)
        {
            cookiePacking.IsFreezingDone = true;
            await _cookiePackingRepository.Update(cookiePacking);
            return CreatedAtAction("PackCookieForForming", cookiePacking);
        }

        [HttpPut]
        public async Task<ActionResult<CookiePacking>> PackCookieForBaking(CookiePacking cookiePacking)
        {
            cookiePacking.IsPacked = true;
            await _cookiePackingRepository.Update(cookiePacking);
            return CreatedAtAction("PackCookieForForming", cookiePacking);
        }
    }
}