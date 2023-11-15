using Hotels.Data;
using Hotels.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotels.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ApplicationDbContext _context;
       public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult CreateNewRecord(Hotel hotel)
        {
            _context.hotel.Add(hotel);
            _context.SaveChanges();
            return RedirectToAction ("Index");
        }
        public IActionResult Update( Hotel hotel )
        {
            _context.hotel.Update(hotel);
            _context.SaveChanges();
            return RedirectToAction ("Index");
        }

        public IActionResult Edit(int  Id)
        {
             var hoteledit=_context.hotel.SingleOrDefault(x => x.Id == Id);
             return View(hoteledit);

        }
        public IActionResult Delete(int  Id)
        {
          var hoteldelete=_context.hotel.SingleOrDefault(x=> x.Id == Id); //search
            _context.hotel.Remove(hoteldelete);//delete
            _context.SaveChanges();
             return RedirectToAction ("Index");
        }
        public IActionResult Index()
        {
            var hotel= _context.hotel.ToList();            
                return View(hotel);
		}
		public IActionResult Rooms()
		{
			
			return View();
		}



		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}