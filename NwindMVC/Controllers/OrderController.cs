using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NwindMVC.Models;





namespace NwindMVC.Controllers
{
    public class OrderController : Controller
    {
        private RepositoryOrders _repositoryOrders;
        public OrderController(RepositoryOrders repository)
        {
            _repositoryOrders = repository;
        }
        // GET: OrderController
        public IActionResult Index()
        {
            List<int> OrdersIds = _repositoryOrders.GetAllOrderID();
            OrderIdsViewModel idsViewModel = new OrderIdsViewModel(OrdersIds);
            return View(idsViewModel);
        }





        // GET: OrderController/Details/5
        [HttpPost]
        public ActionResult Details(int id)
        {
            Order order = _repositoryOrders.FindOrderById(id);
            List<OrderDetail> detail = _repositoryOrders.FindOrderDetailByOrderId(id);
            ViewData["OrderDetail"] = detail;
            return View(order);
            //Console.WriteLine($"Selected Order ID: {ID}");
            //Order order = _repositoryOrders.FindOrderById(ID);
            //if (order != null)
            //{
            //    return View(order); // Pass the order object to the view
            //}
            //return RedirectToAction("Index");
        }





        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }





        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }





        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }





        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }





        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }





        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }



}