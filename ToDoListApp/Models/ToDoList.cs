using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListApp.Models
{
    public class ToDoList
    {
        public int ListId { get; set; }

        [Required(ErrorMessage = "Please, enter description!")]
        public string ListDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please, enter end date!")]
        public DateTime ListEndDate { get; set; }

        [Required(ErrorMessage = "Please, enter category!")]
        public string CategoryId { get; set; } = string.Empty;

        [ValidateNever]
        public Category Category { get; set; } = null;

        [Required(ErrorMessage = "Please, enter status!")]
        public string StatusId { get; set; } = string.Empty;

        [ValidateNever]
        public Status Status { get; set; } = null;

        public bool IsPending => StatusId == "open" && ListEndDate < DateTime.Today; 
    }
}
