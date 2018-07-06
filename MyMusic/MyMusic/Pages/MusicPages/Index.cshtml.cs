using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyMusic.Model;
using Microsoft.EntityFrameworkCore;

namespace MyMusic.Pages.MusicPages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _db;
        [TempData]
        public string AfterAddMessage { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable <Music> MyMusicLove { get; set; }
        public string SomeData { get; set; }

        public async Task OnGet()
        {
            MyMusicLove = await _db.MusicList.ToListAsync();
        }
        public async Task <IActionResult> OnPostDelete(int id)
        {
            var TheMusicList = _db.MusicList.Find(id);
            _db.MusicList.Remove(TheMusicList);
            await _db.SaveChangesAsync();
            AfterAddMessage = " Track deleted successfully!";

            return RedirectToPage();
        }
    }
}