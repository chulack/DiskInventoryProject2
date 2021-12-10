using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiskInventory.Models;

/*
    Original Author: Luke Chulack                         
    Date Created:  11/12/2021                                     
    Version: 2.0                                           
    Date Last Modified: 12/3/2021                               
    Modified by: Luke Chulack                                          
    Modification log: 

           version 1.0 -  11/12/2021  - Built the Borrower Controller which links to the view in the Borrower view folder
            version 2.0 -  12/3/2021  - added logic foradd, edit and delete of Borrowers data.

 */


namespace DiskInventory.Controllers
{
    public class BorrowerController : Controller
    {
        private disk_inventorylcContext context { get; set; }

        public BorrowerController(disk_inventorylcContext ctx)
        {
            context = ctx;

        }
        public IActionResult Index()
        {
            // Sql ( using Linq ) query to get/order data related to the borrower table

            List<Borrower> borrowers = context.Borrowers.OrderBy(b => b.Lname).ThenBy(b => b.Fname).ToList();
            return View(borrowers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Borrower());
        }


        [HttpGet]
        public IActionResult Edit(int id) // overloaded edit to get Borrower id
        {
            ViewBag.Action = "Edit";
            var borrower = context.Borrowers.Find(id);
            return View(borrower);
        }


        [HttpPost]
        public IActionResult Edit(Borrower borrower)
        {
            if (ModelState.IsValid)
            {
                if (borrower.BorrowerId == 0) // add Borrower
                {
                    context.Borrowers.Add(borrower);

                }
                else // update Borrower
                {
                    context.Borrowers.Update(borrower);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Borrower");

            }
            else
            {
                ViewBag.Action = (borrower.BorrowerId == 0) ? "Add" : "Edit";
                return View(borrower);
            }

        }




        [HttpGet]
        public IActionResult Delete(int id) // gets id to delete
        {
            var borrower = context.Borrowers.Find(id);
            return View(borrower);
        }

        [HttpPost]

        public IActionResult Delete(Borrower borrower) // overload delete
        {
            context.Borrowers.Remove(borrower);
            context.SaveChanges();

            return RedirectToAction("Index", "Borrower");
        }


    }
}
