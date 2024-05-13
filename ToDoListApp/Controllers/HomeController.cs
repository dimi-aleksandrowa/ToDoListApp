using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
    public class HomeController : Controller
    {
        private ToDoListContext toDoListContext;
        public HomeController(ToDoListContext context)
        {
            this.toDoListContext = context;
        }
        public IActionResult Index(string Id)
        {
            var filtersArr = new Filters(Id);
            ViewBag.Filters = filtersArr;

            ViewBag.Categories = toDoListContext.ToDoListCategories.ToList();
            ViewBag.Statuses = toDoListContext.ToDoListStatuses.ToList();
            ViewBag.EndDateFilters = Filters.EndDateFilterValue;

            IQueryable<ToDoList> toDoListQuery = toDoListContext.ToDoLists
                                                                .Include(e => e.Category)
                                                                .Include(e => e.Status);

            if (filtersArr.HasCategory)
            {
                toDoListQuery = toDoListQuery.Where(e => e.CategoryId == filtersArr.CategoryId);
            }

            if (filtersArr.HasStatus)
            {
                toDoListQuery = toDoListQuery.Where(e => e.StatusId == filtersArr.StatusId);
            }

            if (filtersArr.HasEndDate)
            {
                var today = DateTime.Today;
                if (filtersArr.IsPast)
                {
                    toDoListQuery = toDoListQuery.Where(e => e.ListEndDate < today);
                }
                else if (filtersArr.IsUpcoming)
                {
                    toDoListQuery = toDoListQuery.Where(e => e.ListEndDate > today);
                }
                else if (filtersArr.IsToday) 
                {
                    toDoListQuery = toDoListQuery.Where(e => e.ListEndDate == today);
                }
            }

            return View();
        }
    }
}
