using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiskInventory.Models;

/*
    Original Author: Luke Chulack                         
    Date Created:  11/12/2021                                     
    Version: 1.0                                           
    Date Last Modified: 11/12/2021                               
    Modified by: Luke Chulack                                          
    Modification log: 

           version 1.0 -  11/12/2021  - Built the Borrower Controller which links to the view in the Borrower view folder
 
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
    }
}
