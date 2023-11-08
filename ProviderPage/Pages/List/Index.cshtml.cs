//using Microsoft.AspNetCore.Components.Forms;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json;
//using ProviderPage.Models;
//using System.Text.Json.Serialization;

//namespace ProviderPage.Pages.List
//{
//    public class IndexModel : PageModel
//    {
//        private readonly Prn221Spr22Context _context;
//        public string Room {  get; set; }
//        public List<Service> Services { get; set; } = new List<Service>();

//        public IndexModel(Prn221Spr22Context context) {
//            _context = context;
//        }
//        public void OnGet(string room)
//        {
//            Room = room;
//            if (string.IsNullOrEmpty(Room))
//            {
//                Services = _context.Services.Include(x => x.EmployeeNavigation).ToList();
//            }
//            else {
//               Services = _context.Services.Include(x=> x.EmployeeNavigation).Where(x => x.RoomTitle.Contains(room)).ToList();
//            }
//        }
//        public void OnPost(IFormFile inputFile) {
//            string fileContent = string.Empty;
//            using (var reader = new StreamReader(inputFile.OpenReadStream())) { 
//            fileContent = reader.ReadToEnd();
//            }
//            if (!string.IsNullOrEmpty(fileContent)) {
//                var listOfImportService = JsonConvert.DeserializeObject<List<Service>>(fileContent);
           
//                if (listOfImportService != null) {
//                    foreach (var service in listOfImportService) {
//                        service.Id = 0;
//                    }
//                        _context.Services.AddRange(listOfImportService);
//                    _context.SaveChanges();
//                }
//            }
//            Services = _context.Services.Include(x => x.EmployeeNavigation).ToList();
//        }
//    }
//}
