using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMotors.Domain.Entities;
using WebMotors.Infra.Data;
using WebMotors.Application.Interfaces;
using WebMotors.Application.ViewModels;
using WebMotors.Application.ViewModels.AnuncioWebMotors;

namespace WebMotors.WebApp.Controllers
{
    public class AnuncioWebMotorsController : Controller
    {
        private readonly Itb_AnuncioWebMotorsAppServices _productAppServices;

        public AnuncioWebMotorsController(Itb_AnuncioWebMotorsAppServices productAppServices)
        {
            _productAppServices = productAppServices;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _productAppServices.Find().ConfigureAwait(true));
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var product = await _productAppServices.Find(id).ConfigureAwait(true);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnuncioWebMotorsViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {

                productViewModel = await _productAppServices.Insert(productViewModel).ConfigureAwait(true);

                if (productViewModel.Invalid)
                {
                    foreach (var item in productViewModel.ValidationResult.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }

                    return View("Create", productViewModel);
                }

            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var product = await _productAppServices.Find(id).ConfigureAwait(true);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AnuncioWebMotorsViewModel productViewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    //await _InterfaceProductApp.Update(product);


                    await _productAppServices.Update(productViewModel).ConfigureAwait(true); 

                    //if (product.Notitycoes.Any())
                    //{
                    //    foreach (var item in product.Notitycoes)
                    //    {
                    //        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    //    }

                        return View("Edit", productViewModel);
                    //}

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProductExists(productViewModel.Id).ConfigureAwait(true))
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
            return View(productViewModel);
        }

        private Task<bool> ProductExists(int id)
        {
            throw new NotImplementedException();
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var product = await _productAppServices.Find(id).ConfigureAwait(true); 
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {

            await _productAppServices.Delete(Id).ConfigureAwait(true);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> Exists(int id)
        {

            var objeto = await _productAppServices.Find(id);

            return objeto != null;
        }
    }
}
