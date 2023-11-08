using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ProviderPage.Models;
using System.Text.Json;
namespace ProviderPage.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly InventoryManagementContext _context;
        public IndexModel(InventoryManagementContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(string Username, string Password)
        {
             Provider provider = handleCheckAuthen(Username, Password); 
            if (provider != null)
            {
                HttpContext.Session.SetString("user", System.Text.Json.JsonSerializer.Serialize(provider));
                return Redirect("/home");
            }
            else
            {            
                return Page();
            }
        }

        private Provider handleCheckAuthen(string username, string password)
        {
           Provider providers = (Provider)_context.Providers.FirstOrDefault(x => x.Password.Equals(password) && x.UserName.Equals(username));
            if (providers != null)
            {
                return providers;
            }
            else {
                return null;
            }
        }
    }
}
