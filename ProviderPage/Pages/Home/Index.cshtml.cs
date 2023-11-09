using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ProviderPage.Models;

namespace ProviderPage.Pages.Home
{
    public class IndexModel : PageModel
    {
        public Provider Provider { get; set; } = new Provider();
        public Product productSelected { get; set; } = new Product();
        public List<Product> listProduct { get; set; } = new List<Product>();

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
                listProduct = _context.Products.Where(x => x.ProviderId == Provider.ProviderId).ToList();

                return Page();
            }
            else
            {
                return Redirect("/login");
            }
        }
        public void loadPage() {
            string user = HttpContext.Session.GetString("user");
            if (!string.IsNullOrEmpty(user))
            {
                Provider = JsonConvert.DeserializeObject<Provider>(user);
                listProduct = _context.Products.Where(x => x.ProviderId == Provider.ProviderId).ToList();       
            }
        }
        public void OnPostDeleteProduct(int productId) 
        { 
            var product = _context.Products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                product.Refrigerated = false;
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            loadPage();
        }
        public void OnPostSelectedProduct(int productId)
        {
            productSelected = _context.Products.FirstOrDefault(x => x.ProductId == productId);
            loadPage();
        }
        public void OnPostAddNewOrUpdate(string ProductId, string ProductName,string ProductDescription,string ProductCategory, string PackedHeight, string PackedWidth,string PackedDepth,string OriginPrice) {
            loadPage();
            if (string.IsNullOrEmpty(ProductId))
            {
                Product product = new Product()
                {
                    ProductName = ProductName,
                    ProductDescription = ProductDescription,
                    ProductCategory = ProductCategory,
                    PackedHeight = Decimal.Parse(PackedHeight),
                    PackedWidth = Decimal.Parse(PackedWidth),
                    PackedDepth = Decimal.Parse(PackedDepth),
                    ProviderId = Provider.ProviderId,
                    OriginPrice = Decimal.Parse(OriginPrice)
                };
                _context.Products.AddRange(product);
                _context.SaveChanges();
            }
            else {
                Product p = _context.Products.FirstOrDefault(x => x.ProductId == Decimal.Parse(ProductId));
                if (p != null) {
                    p.ProductName = ProductName;
                    p.ProductDescription = ProductDescription;
                    p.ProductCategory = ProductCategory;
                    p.PackedHeight = Decimal.Parse(PackedHeight);
                    p.PackedWidth = Decimal.Parse(PackedWidth);
                    p.PackedDepth = Decimal.Parse(PackedDepth);
                    p.ProviderId = Provider.ProviderId;
                    p.OriginPrice = Decimal.Parse(OriginPrice);
                    _context.Products.Update(p);
                    _context.SaveChanges();
                };
               
            }
            loadPage();
        }
        }

    }

