using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleSaleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleSaleApp.Controllers
{
    public class SaleController : Controller
    {
        private readonly AppDbContext _context;

        public SaleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SaleController
        public ActionResult Index()
        {
            var sales = _context.Sales.ToList();
            if (sales == null)
            {
                return NotFound();
            }

            return View("View", sales);
        }

        // GET: SaleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("SaleId,SaleName,StartDate,EndDate,Price,Product")] Sale sale)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(sale);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: SaleController/Edit/5
        public ActionResult Edit(int id)
        {
            var sales = _context.Sales.SingleOrDefault(x => x.SaleId == id);

            if (sales != null)
            {
                return View(sales);
            }

            return NotFound();
        }

        // POST: SaleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("SaleId,SaleName,StartDate,EndDate,Price,Product")] Sale sale)
        {
            if (id != sale.SaleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.SaleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        private bool SaleExists(int id)
        {
            return _context.Sales.Any(e => e.SaleId == id);
        }

        // GET: SaleController/Delete/5
        public ActionResult Delete(int id)
        {

            var Sale = _context.Sales.SingleOrDefault(m => m.SaleId == id);
            if (Sale == null)
            {
                return NotFound();
            }

            return View(Sale);
        }

        // POST: SaleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int saleId, IFormCollection collection)
        {
            try
            {
                var sales = _context.Sales.SingleOrDefault(m => m.SaleId == saleId);

                _context.Sales.Remove(sales);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
