using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Mvc;
using Repo.Data;

namespace API.Controllers
{
    public class BugController: BaseApiController
    {
        private readonly StoreContext _context;
        public BugController(StoreContext context)
        {
            _context = context;
            
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFound()
        {
            var thing = _context.Products.Find(42); //Böyle bi ürün yok. NotFound döneceğini bildiğimiz için bu ürünü sorguluyoruz.
            if(thing == null)
            {
                return NotFound(new ApiResponse(400));
            }
            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(42); //Böyle bi ürün yok. NotFound döneceğini bildiğimiz için bu ürünü sorguluyoruz.
            var thingToReturn = thing.ToString(); // null'ı string'e çeviremeyeceği için server erro hatası döner.
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")] //verilen id yoksa valid hatası verdirelim. örneğin badrequest/five şeklinde istek atalım
        public ActionResult GetNotFound(int id)
        {
            return Ok();
        }
    }
}