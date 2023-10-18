using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProviderPage.Models;
using System.Globalization;

namespace ProviderPage.Pages.Order
{
    public class IndexModel : PageModel
    {
      
        public Provider Provider { get; set; } = new Provider();
        public List<OrderDetail> orderDetail { get; set; } = new List<OrderDetail>();
        public Provider order { get; set; } = new Provider();

        private readonly InventoryManagementContext _context;
        public IndexModel(InventoryManagementContext context) { 
        _context = context;
        }


        public IActionResult OnGet()
        {
            string user = HttpContext.Session.GetString("user");
            if (!string.IsNullOrEmpty(user))
            {
                Provider = JsonConvert.DeserializeObject<Provider>(user);
                orderDetail = _context.OrderDetails.Include(x => x.Product).Include(x => x.Warehouse).Where(x => x.ProviderId == Provider.ProviderId).ToList();
                return Page();
            }
            else
            {
                return Redirect("/login");
            }
        }
        public void LoadPage() {
            orderDetail = _context.OrderDetails.Include(x => x.Product).Include(x => x.Warehouse).ToList();

        }
        public void OnPostSuccessOrder(int OrderDetailId) { 
            var orderDl = _context.OrderDetails.FirstOrDefault(x => x.OrderDetailId == OrderDetailId);
            string formattedDate = DateTime.Now.ToString("yyyy/MM/dd");
            DateTime formattedDateTime = DateTime.ParseExact(formattedDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            orderDl.ActualDate = formattedDateTime;
            _context.OrderDetails.Update(orderDl);
            updateInventory(OrderDetailId);
            _context.SaveChanges();
            LoadPage();
        }

        private void updateInventory(int orderId)
        {
           var orderUpdate = _context.OrderDetails.FirstOrDefault(x => x.OrderDetailId == orderId);
            if (orderUpdate != null && orderUpdate.ActualDate != null) {
                Inventory checkExistProduct = _context.Inventories.Include(x => x.Product).FirstOrDefault(x => x.ProductId == orderUpdate.ProductId);
                if (checkExistProduct != null)
                {
                    Inventory inventory = _context.Inventories.Include(x => x.Warehouse).Include(x => x.Product).FirstOrDefault(x => x.WarehouseId == orderUpdate.WarehouseId && x.ProductId == orderUpdate.ProductId);
                    if (inventory != null)
                    {
                        inventory.QuantityAvaiable += orderUpdate.OrderQuantity;
                        _context.Inventories.Update(inventory);
                        _context.SaveChanges();
                    }
                }
                else { 
                Inventory inventoryAdd = new Inventory() { 
                QuantityAvaiable = orderUpdate.OrderQuantity,
                ProductId = orderUpdate.ProductId, 
                WarehouseId = orderUpdate.WarehouseId,
                };
                   
                    _context.Inventories.AddRange(inventoryAdd);
                    _context.SaveChanges();
                
               }
            }
        }
    }
}
