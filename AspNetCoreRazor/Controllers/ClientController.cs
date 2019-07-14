using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AspNetCoreRazor.Data.Context;
using AspNetCoreRazor.Models;
using AspNetCoreRazor.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreRazor.Controllers
{
    public class ClientController : Controller
    {
        private DataContext _db;

        public ClientController(DataContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var clients = _db.Clients.Where(x => true);
            ViewBag.success = this.TempData["success"];
            ViewBag.error = this.TempData["error"];
            return View(clients);
        }

        public IActionResult Create()
        {
            var clientViewModel = new ClientViewModel();
            return View("Form",clientViewModel);
        }

        public IActionResult Edit(int id)
        {
            var client = _db.Clients.FirstOrDefault(x => x.Id == id);
            var clientViewModel = Mapper.Map<Client, ClientViewModel>(client);
            return View("Form", clientViewModel);
        }

        [HttpPost]
        public IActionResult Update(ClientViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<ClientViewModel, Client>(viewModel);
                if (viewModel.Id != 0)
                {
                    _db.Clients.Update(model);
                }
                else
                {
                    _db.Clients.Add(model);
                }
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("Form",viewModel);
        }

        public IActionResult Delete(int id)
        {
            var client = _db.Clients.FirstOrDefault(x => x.Id == id);
            if (!client.Equals(null))
            {
                _db.Remove(client);
                var result = _db.SaveChanges();
                if(result == 1)
                    this.TempData["success"] = "Success!";
                else
                    this.TempData["error"] = "Error!";

            }

            return RedirectToAction("Index");
        }
    }
}
