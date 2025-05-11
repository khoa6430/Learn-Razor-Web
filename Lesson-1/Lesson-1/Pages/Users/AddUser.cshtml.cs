using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementSystem.Data;
using UserManagementSystem.Models;

namespace UserManagementSystem.Pages.Users
{
    public class AddUserModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AddUserModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User NewUser { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Users.Add(NewUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
