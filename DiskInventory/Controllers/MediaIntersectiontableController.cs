using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiskInventory.Models;
using Microsoft.EntityFrameworkCore;

/*
    Original Author: Luke Chulack                         
    Date Created:  12/3/2021                                     
    Version: 1.0                                           
    Date Last Modified: 12/3/2021                              
    Modified by: Luke Chulack                                          
    Modification log: 

           version 1.0 -  11/12/2021  - Built the MediaIntersectiontable Controller which links to the view in the MediaIntersectiontable view folder

 */

namespace DiskInventory.Controllers
{

    // media intersection table controller
    public class MediaIntersectiontableController : Controller
    {

        private disk_inventorylcContext context { get; set; }

        public MediaIntersectiontableController(disk_inventorylcContext ctx)
        {
            context = ctx;

        }

        public IActionResult Index()
        {

            var mediaintersectiontable = context.MediaIntersectiontables.Include(d => d.Media).OrderBy(d => d.Media.MediaName).Include(b => b.Borrower).ToList();

            return View(mediaintersectiontable);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Borrowers = context.Borrowers.OrderBy(t => t.Lname).ToList();
            ViewBag.Media = context.Media.OrderBy(s => s.MediaName).ToList();

            MediaIntersectiontable newMedia = new MediaIntersectiontable();

            newMedia.BorrowedDate = DateTime.Today;

            return View("Edit", newMedia);
        }


        [HttpGet]

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Borrowers = context.Borrowers.OrderBy(t => t.Lname).ToList();
            ViewBag.Media = context.Media.OrderBy(s => s.MediaName).ToList();

            var mediaintersectiontable = context.MediaIntersectiontables.Find(id);
            return View(mediaintersectiontable);

        }

        [HttpPost]
        public IActionResult Edit(MediaIntersectiontable mediaintersectiontable)
        {
            if (ModelState.IsValid)
            {
                if (mediaintersectiontable.MediaIntersectionId == 0) // add media
                {
                    context.MediaIntersectiontables.Add(mediaintersectiontable);

                }
                else // update media
                {
                    context.MediaIntersectiontables.Update(mediaintersectiontable);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "MediaIntersectiontable");

            }
            else
            {
                ViewBag.Action = (mediaintersectiontable.MediaIntersectionId == 0) ? "Add" : "Edit";
                ViewBag.Borrowers = context.Borrowers.OrderBy(t => t.Lname).ToList();
                ViewBag.Media = context.Media.OrderBy(s => s.MediaName).ToList();
                return View(mediaintersectiontable);
            }

        }

    }
}
