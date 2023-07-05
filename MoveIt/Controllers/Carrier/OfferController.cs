using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoveIt.Data;
using MoveIt.Models.Carrier;
using MoveIt.Models.Customer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoveIt.Controllers.Carrier
{
    [Authorize]
    [Route("api/[controller]")]
    public class OfferController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public OfferController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<List<Offer>>> GetOffers()
        {
            var offers = await _appDbContext.Offers.ToListAsync();
            return Ok(offers);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Offer>>> GetOfferById(int id, bool isCarrier)
        {
            if(!isCarrier)
            {
                var customerOffers = await _appDbContext.Offers.Where(a => a.CustomerId == id).ToListAsync();
                return Ok(customerOffers);
            }

            var carrierOffers = await _appDbContext.Offers.Where(a => a.CarrierId == id).ToListAsync();

            // var adData = new List<Ad>();

            // carrierOffers.ForEach((offer) => adData.Add((Ad)_appDbContext.Ads.Where(a => a.Id == offer.AdId)));
            
            return Ok(carrierOffers);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<List<Offer>>> AddOffer([FromBody] Offer newOffer)
        {
            if (newOffer != null)
            {
                _appDbContext.Offers.Add(newOffer);
                await _appDbContext.SaveChangesAsync();

                var offers = await _appDbContext.Offers.ToListAsync();
                return Ok(offers);
            }
            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Offer>> UpdateOffer([FromBody] Offer updatedOffer)
        {
            if (updatedOffer != null)
            {
                var offer = await _appDbContext.Offers.FirstOrDefaultAsync(e => e.Id == updatedOffer.Id);

                if (offer != null)
                {
                    offer.isAccepted = !offer.isAccepted;

                    await _appDbContext.SaveChangesAsync();

                    var offers = await _appDbContext.Offers.ToListAsync();

                    return Ok(offers);
                }
                return NotFound();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("confirmDelivery")]
        public async Task<ActionResult<Offer>> ConfirmDelivery(int id)
        {
            var offer = await _appDbContext.Offers.FirstOrDefaultAsync(e => e.Id == id);

            if (offer != null)
            {
                offer.isCarrierConfirmed = true;

                await _appDbContext.SaveChangesAsync();

                var offers = await _appDbContext.Offers.ToListAsync();

                return Ok(offers);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("customerConfirm")]
        public async Task<ActionResult<Offer>> CustomerConfirm(int id)
        {
            var offer = await _appDbContext.Offers.FirstOrDefaultAsync(e => e.Id == id);

            if (offer != null)
            {
                offer.isCustomerConfirmed = true;

                await _appDbContext.SaveChangesAsync();

                var offers = await _appDbContext.Offers.ToListAsync();

                return Ok(offers);
            }

            return BadRequest();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

