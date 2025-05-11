using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementSystem.Data;
using UserManagementSystem.Models;

namespace UserManagementSystem.Pages.Users
{
    public class AddUserModel : PageModel
    {
        // Inject ApplicationDbContext để truy xuất dữ liệu
        private readonly ApplicationDbContext _context;

        // Constructor để khởi tạo context
        public AddUserModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // BindProperty: Tương tự như useState() trong React để lưu trữ dữ liệu input
        [BindProperty]
        public User NewUser { get; set; }

        // Xử lý POST request (Tương tự như handleSubmit trong React)
        public async Task<IActionResult> OnPostAsync()
        {
            // Kiểm tra dữ liệu đầu vào
            if (!ModelState.IsValid)
            {
                return Page(); // Nếu dữ liệu không hợp lệ, giữ nguyên trang
            }
            // Thêm user mới vào context (tương tự như setState())
            _context.Users.Add(NewUser);

            // Lưu thay đổi vào database (tương tự như API POST request)
            await _context.SaveChangesAsync();

            // Điều hướng về trang Index sau khi thêm user (Tương tự như navigate trong React Router)
            return RedirectToPage("Index");
        }
    }
}
