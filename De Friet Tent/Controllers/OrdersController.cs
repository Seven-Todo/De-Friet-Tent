using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using De_Friet_Tent.DB;
using De_Friet_Tent.Models;

namespace De_Friet_Tent.Controllers
{
    public class OrdersController : Controller
    {
        private readonly Friesshopdb _context;

        public OrdersController(Friesshopdb context)
        {
            _context = context;
        }

        public IActionResult ChoiceOrderCustomer()
        {
            return View();
        }

        public IActionResult ChoiceOrderOwner()
        {
            return View();
        }

        public IActionResult ChoiceOrderEmployee()
        {
            return View();
        }

        public async Task<IActionResult> IndexCustomerDelete()
        {
            var friesshopdb = _context.Orders.Include(o => o.Customer).Include(o => o.Status);
            return View(await friesshopdb.ToListAsync());
        }

        public async Task<IActionResult> IndexCustomer()
        {
            var friesshopdb = _context.Orders.Include(o => o.Customer).Include(o => o.Status);
            return View(await friesshopdb.ToListAsync());
        }
        public async Task<IActionResult> IndexEmployee()
        {
            var friesshopdb = _context.Orders.Include(o => o.Customer).Include(o => o.Status);
            return View(await friesshopdb.ToListAsync());
        }
        public async Task<IActionResult> IndexEmployeeDelete()
        {
            var friesshopdb = _context.Orders.Include(o => o.Customer).Include(o => o.Status);
            return View(await friesshopdb.ToListAsync());
        }
        public async Task<IActionResult> IndexOwnerDelete()
        {
            var friesshopdb = _context.Orders.Include(o => o.Customer).Include(o => o.Status);
            return View(await friesshopdb.ToListAsync());
        }


        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var friesshopdb = _context.Orders.Include(o => o.Customer).Include(o => o.Status);
            return View(await friesshopdb.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Status)
                .Include(p => p.Products)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        public IActionResult CreateCustomer()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Lastname");
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Name");

            var products = _context.Product.ToList();
            ViewData["Products"] = products;
            var selectedProducts = new List<int>();


            OrderProductViewModel orderproduct = new OrderProductViewModel()
            {
                Order = new Order(),
                SelectedProducts = selectedProducts,
                Products = products
            };

            return View(orderproduct);
        }


        public IActionResult CreateEmployee()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Lastname");
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Name");

            var products = _context.Product.ToList();
            ViewData["Products"] = products;
            var selectedProducts = new List<int>();


            OrderProductViewModel orderproduct = new OrderProductViewModel()
            {
                Order = new Order(),
                SelectedProducts = selectedProducts,
                Products = products
            };

            return View(orderproduct);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Lastname");
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Name");

            var products = _context.Product.ToList();
            ViewData["Products"] = products;
            var selectedProducts = new List<int>();


            OrderProductViewModel orderproduct = new OrderProductViewModel()
            {
                Order = new Order(),
                SelectedProducts = selectedProducts,
                Products = products
            };

            return View(orderproduct);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                if (model.SelectedProducts != null)
                {
                    if (model.Order.Products == null)
                    {
                        model.Order.Products = new List<Product>();
                    }

                    model.Order.Products.Clear();

                    foreach (var productId in model.SelectedProducts)
                    {
                        var product = await _context.Product
                            .FirstOrDefaultAsync(p => p.Id == productId);

                        if (product != null)
                        {
                            model.Order.Products.Add(product);
                        }

                    }

                }

                _context.Add(model.Order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }



            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", model.Order.CustomerId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Id", model.Order.StatusId);
            ViewData["Products"] = _context.Product.ToList();


            return View(model);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Lastname", order.CustomerId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Name", order.StatusId);
            var products = await _context.Product.ToListAsync();
            var selectedProducts = new List<int>();

            if (order.Products != null)
            {
                selectedProducts = order.Products.Select(x => x.Id).ToList();
            }

            OrderProductViewModel orderproduct = new OrderProductViewModel()
            {
                Order = order,
                SelectedProducts = selectedProducts,
                Products = products
            };

            return View(orderproduct);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OrderProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var existingorder = await _context.Order
                .Include(o => o.Customer)
                .Include(p => p.Products)
                .Include(o => o.Status)
                .FirstOrDefaultAsync(m => m.Id == model.Order.Id);

            if (existingorder == null)
            {
                return NotFound();
            }

            if (model.SelectedProducts != null)
            {
                if (existingorder.Products == null)
                {
                    existingorder.Products = new List<Product>();
                }

                existingorder.Products.Clear();

                foreach (var productId in model.SelectedProducts)
                {
                    var product = await _context.Product
                        .FirstOrDefaultAsync(p => p.Id == productId);

                    if (product != null)
                    {
                        existingorder.Products.Add(product);
                    }

                }

            }

            _context.Entry(existingorder).CurrentValues.SetValues(model.Order);
            await _context.SaveChangesAsync();
            var products = await _context.Product.ToListAsync();
            model.Products = products;

            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", existingorder.CustomerId);
            return RedirectToAction(nameof(Index));
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
