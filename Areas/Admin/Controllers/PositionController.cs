using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simulation6.Areas.Admin.ViewModels.Position;

using Simulation6.DAL;
using Simulation6.Models;

namespace Simulation6.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PositionController : Controller
    {
        private readonly AppDbContext _db;

        public PositionController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Position> positions = await _db.Positions.Include(p => p.Members).ToListAsync();
            return View(positions);
        }

        public async Task<IActionResult> Create()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePositionVM positionVM)
        {
           
            if (!ModelState.IsValid) return View(positionVM);
            
            Position? position = new Position()
            {
                Name = positionVM.Name,
         
            };
            await _db.Positions.AddAsync(position);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Update(int? id)
        {
           
            Position? position = await _db.Positions.FindAsync(id);
            UpdatePositionVM positionVM = new UpdatePositionVM()
            {
                Name = position.Name,
      
            };
            if (!ModelState.IsValid) return View(positionVM);
            await _db.SaveChangesAsync();
            return View(positionVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdatePositionVM positionVM)
        {
           
            Position? oldPosition = await _db.Positions.FirstOrDefaultAsync(p => p.Id == positionVM.Id);
            if (!ModelState.IsValid) return View(positionVM);
          
            oldPosition.Name = positionVM.Name;
      
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            Position? position = await _db.Positions.FindAsync(id);
            position.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Restore(int? id)
        {
            Position? position = await _db.Positions.FindAsync(id);
            position.IsDeleted = false;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
