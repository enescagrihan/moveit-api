using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoveIt.Data;
using MoveIt.Models;
using MoveIt.Models.Carrier;
using MoveIt.Models.Customer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoveIt.Controllers.Customer
{
    [Authorize]
    [Route("api/[controller]")]
    public class AdController : Controller
    {

        private readonly AppDbContext _appDbContext;

        public AdController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<List<Ad>>> GetAds()
        {
            var ads = await _appDbContext.Ads.ToListAsync();
            return Ok(ads);
        }

        // GET: api/values
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Ad>>> GetLastAdById(int id)
        {
            var ad = await _appDbContext.Ads.Where(a => a.UserId == id).OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            return Ok(ad);
        }

        // GET api/values/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Ad>> GetAd(int id)
        //{
        //    var ad = await _appDbContext.Ads.FirstOrDefaultAsync(e => e.Id == id);
        //    if(ad != null)
        //    {
        //        return Ok(ad);
        //    }
        //    return NotFound();
        //}

        [HttpGet]
        [Route("getById")]
        public async Task<ActionResult<User>> GetAdById(long id)
        {
            var ad = await _appDbContext.Ads.FirstOrDefaultAsync(e => e.Id == id);
            if (ad != null)
            {
                return Ok(ad);
            }
            return NotFound();
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<List<Ad>>> AddAd([FromBody]Ad newAd)
        {
            if (newAd != null)
            {
                _appDbContext.Ads.Add(newAd);
                await _appDbContext.SaveChangesAsync();

                var ads = await _appDbContext.Ads.ToListAsync();
                return Ok(ads);
            }
            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Ad>> UpdateAd([FromBody]Ad updatedAd)
        {
            if (updatedAd != null)
            {
                var ad = await _appDbContext.Ads.FirstOrDefaultAsync(e => e.Id == updatedAd.Id);

                if(ad != null)
                {
                    ad.PhotoURL = updatedAd.PhotoURL;
                    ad.AdTitle = updatedAd.AdTitle;
                    ad.TransportDate = updatedAd.TransportDate;
                    ad.GoodsCategory = updatedAd.GoodsCategory;
                    ad.GoodsName = updatedAd.GoodsName;
                    ad.GoodsVolume = updatedAd.GoodsVolume;
                    ad.GoodsLength = updatedAd.GoodsLength;
                    ad.GoodsWidth = updatedAd.GoodsWidth;
                    ad.GoodsDepth = updatedAd.GoodsDepth;
                    ad.Details = updatedAd.Details;
                    ad.FromWhere = updatedAd.FromWhere;
                    ad.ToWhere = updatedAd.ToWhere;

                    await _appDbContext.SaveChangesAsync();

                    var ads = await _appDbContext.Ads.ToListAsync();

                    return Ok(ads);
                }
                return NotFound();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("doneJob")]
        public async Task<ActionResult<Offer>> doneJob(int id)
        {
            var ad = await _appDbContext.Ads.FirstOrDefaultAsync(e => e.Id == id);


            if (ad != null)
            {
                ad.isDone = true;

                var offers = await _appDbContext.Offers.Where(a => a.AdId == id).ToListAsync();

                foreach(Offer offer in offers)
                {
                    offer.isCarrierConfirmed = true;
                    offer.isCustomerConfirmed = true;
                };

                await _appDbContext.SaveChangesAsync();

                var ads = await _appDbContext.Ads.ToListAsync();

                return Ok(ads);
            }

            return BadRequest();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Ad>>> DeleteAd(int id)
        {
            var ad = await _appDbContext.Ads.FirstOrDefaultAsync(e => e.Id == id);

            if(ad != null)
            {
                _appDbContext.Ads.Remove(ad);
                await _appDbContext.SaveChangesAsync();

                var ads = await _appDbContext.Ads.ToListAsync();
                return Ok(ads);
            }

            return BadRequest();
        }
    }
}

