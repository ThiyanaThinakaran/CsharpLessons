using Microsoft.AspNetCore.Mvc.Rendering;

namespace NwindMVC.Models
{
    public class CustomerIdsViewModel
    {
        public int Id { get; set; } //for the selected item. ie one id for the dropdown
        public readonly List<SelectListItem> CustomerIdsSelectedList;
        public CustomerIdsViewModel(List<string> customerIds)
        {
            CustomerIdsSelectedList = new List<SelectListItem>();
            foreach (var no in customerIds)
            {
                CustomerIdsSelectedList.Add(new SelectListItem { Text = $"{no}", Value = $"{no}" });
            }
        }
    }
}
