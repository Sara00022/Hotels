using Hotels.Data;
using Hotels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotels.Controllers
{
    public class DashboardController : Controller
    {
       private readonly ApplicationDbContext _context;
        public DashboardController(ApplicationDbContext context)
		{
			_context = context;
		}

        public IActionResult Edit(int Id)
        {
            var hoteledit = _context.hotel.SingleOrDefault(x => x.Id == Id);
            return View(hoteledit); 

        }
        public IActionResult Update(Hotel hotel)
        {
            
                _context.hotel.Update(hotel);
                _context.SaveChanges();
                

                return RedirectToAction("Index");
            
        }

        


        public IActionResult Delete(int Id)
        {
            var hotelDel =_context.hotel.SingleOrDefault(x=>x.Id == Id);
            if (hotelDel != null)
            {

                _context.hotel.Remove(hotelDel);
                _context.SaveChanges();
                TempData["Del"] = "OK";
            }

            return RedirectToAction("Index");
        }

        public IActionResult CreatNewRomms(Rooms rooms)
        {
            _context.rooms.Add(rooms);
            _context.SaveChanges();
            return RedirectToAction("Rooms");
        }


		[HttpPost]
		public IActionResult Index(string  city)
		{
            var hotel = _context.hotel.Where(x => x.City.Equals(city));

			return View(hotel);
		}
        [Authorize]

		public IActionResult Index()
        {
            var hotel=_context.hotel.ToList();

            return View(hotel);
        }
		public IActionResult RoomDetails()
		{
			var hotel = _context.hotel.ToList();
			ViewBag.hotel = hotel;
            var roomDetails=_context.roomDetails.ToList();
			return View( roomDetails);
		}
		public IActionResult NewRoomDetails(RoomDetails roomDetails)
		{
            
                _context.roomDetails.Add(roomDetails);
                _context.SaveChanges();
                 return RedirectToAction("RoomDetails");
           

		}


		public IActionResult Rooms()
		{
			var hotel=_context.hotel.ToList();
            ViewBag.hotel=hotel;
            var rooms = _context.rooms.ToList();
            
 			return View(rooms);
		}

		public IActionResult CreatNewHotel(Hotel hotels) 

        { 
         _context.hotel.Add(hotels);
         _context.SaveChanges();
         return RedirectToAction("Index");
        }


    }

	
	}

