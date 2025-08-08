// Pages/Index.cshtml.cs
using EasyChat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EasyChat.Data;
using System.Collections.Generic;
namespace EasyChat.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        //  оллекци€ всех сообщений
        public List<MyMessage> Messages { get; set; }

        // GET-запрос: получение списка сообщений
        public async Task OnGetAsync()
        {
            Messages = await _context.Messages.ToListAsync();
        }

        // POST-запрос: отправка нового сообщени€
        public async Task<IActionResult> OnPostAsync(string Content)
        {
            var newMessage = new MyMessage
            {
                Content = Content,
                CreatedAt = DateTime.Now
            };

            _context.Messages.Add(newMessage);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        // DELETE-запрос: удаление существующего сообщени€
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message != null)
            {
                _context.Messages.Remove(message);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}