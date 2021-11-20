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

           version 1.0 -  11/12/2021  - Built the Media Controller which links to the view in the Media view folder
 
 */
namespace DiskInventory.Controllers
{
    public class MediaController : Controller
    {
        private disk_inventorylcContext context { get; set; }

        public MediaController(disk_inventorylcContext ctx)
        {
            context = ctx;

        }
        public IActionResult Index()
        {
            // Sql ( using Linq ) query to get/order data related to the Media table

            List<Medium> medium = context.Media.OrderBy(m => m.MediaName).ToList();
            return View(medium);
        }
    }
}
