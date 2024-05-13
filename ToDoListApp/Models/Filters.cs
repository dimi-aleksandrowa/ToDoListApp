using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListApp.Models
{
    public class Filters
    {
        // read only properties
        public string FilterStr { get; }
        public string CategoryId { get; }
        public string EndDate { get; }
        public string StatusId { get; }
        // lambda properties 
        public bool HasCategory => CategoryId.ToLower() != "all";
        public bool HasEndDate => EndDate.ToLower() != "all";
        public bool HasStatus => StatusId.ToLower() != "all";
        public static Dictionary<string, string> EndDateFilterValue =>
            new Dictionary<string, string>
            {
                { "upcoming", "Upcoming"},
                { "past", "Past"},
                { "today", "Today"}
            };
        public bool IsUpcoming => EndDate.ToLower() == "upcoming";
        public bool IsPast => EndDate.ToLower() == "past";
        public bool IsToday => EndDate.ToLower() == "today";

        public Filters(string FilterString)
        {
            FilterStr = FilterString ?? "all-all-all";
            string[] FilterArr = FilterStr.Split('-');
            CategoryId = FilterArr[0];
            EndDate = FilterArr[1];
            StatusId = FilterArr[2];
        }
    }
}
