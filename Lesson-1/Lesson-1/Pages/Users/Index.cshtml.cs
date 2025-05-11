using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UserManagementSystem.Data;
using UserManagementSystem.Models;

namespace UserManagementSystem.Pages.Users
{
    public class IndexModel : PageModel
    {
        //ApplicationDbContext là class chịu trách nhiệm kết nối với Database.
        //Được Inject qua constructor.
        //Trong React, đây có thể coi như props hoặc Context API để truyền dữ liệu.
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        //Tương tự như state trong React, nhưng ở đây nó là một property.
        public IList<User> Users { get; set; }



        //OnGetAsync() :Đây là phương thức được gọi tự động khi trang Razor Page này được truy cập.

        //Tương tự như useEffect() trong React.

        //await _context.Users.ToListAsync():

        //Lệnh này sẽ thực hiện truy vấn dữ liệu từ bảng Users và trả về danh sách người dùng dưới dạng List<User>.

        //ToListAsync() là phương thức Asynchronous, tương tự như await axios.get() trong React.

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
