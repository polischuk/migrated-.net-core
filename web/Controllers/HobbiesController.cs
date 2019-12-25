using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace web.Controllers
{
    [Authorize]
    public class HobbiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HobbiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var hobbies =  _context.ApplicationUserHobbies
                .Include(userHobbies => userHobbies.Hobby)
                .Include(userHobbies => userHobbies.ApplicationUser)
                .Where(userHobbies => userHobbies.ApplicationUser.UserName == User.Identity.Name)
                .Select(userHobbies => new HobbyDto
                {
                    Id = userHobbies.Hobby.Id,
                    Name =  userHobbies.Hobby.Name
                }).ToList();
            return View(hobbies);
        }
    }

    public class HobbyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}