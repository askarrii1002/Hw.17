using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyMusic.Model;

namespace MyMusic.Pages.MusicPages
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;
        public void OnGet(int id)
        {
            Music1 = _db.MusicList.Find(id);
        }
        public async Task <IActionResult> OnPost()
        {
        if(ModelState.IsValid)
        {
                var musicInDb = _db.MusicList.Find(Music1.ID);
                musicInDb.Artist = Music1.Artist;
                var musicInDb1 = _db.MusicList.Find(Music1.ID);
                musicInDb.Album = Music1.Album;
                var musicInDb2 = _db.MusicList.Find(Music1.ID);
                musicInDb.Song = Music1.Song;
                var musicInDb3 = _db.MusicList.Find(Music1.ID);
                musicInDb.StarRating = Music1.StarRating;

                await _db.SaveChangesAsync();
                AfterAddMessage = "list item updated successfully!";

                return RedirectToPage("Index");
            }
        else
        {
                return RedirectToPage();
        }

        }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [TempData]
        public string AfterAddMessage { get; set; }
        [BindProperty]
        public Music Music1 { get; set; }
    }
}   