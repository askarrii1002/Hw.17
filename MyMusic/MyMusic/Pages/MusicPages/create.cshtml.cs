using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyMusic.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MyMusic.Pages.MusicPages
{
    public class CreateModel : PageModel
    {
        private ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [TempData]
        public string AfterAddMessage { get; set; }
        [BindProperty]
        public Music Music1{ get; set; }
        public void OnGet ()
        {
        }

        public async Task <IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                _db.MusicList.Add(Music1);
                await _db.SaveChangesAsync();
                AfterAddMessage = "New Music added!";
                return RedirectToPage("Index");
            }
        }

    }
}