using Sandman.Models;

namespace SandmanUniversity.Models.Students
{
    public class PaginatedViewModel
    {
        public string CurrentSort { get; set; }
        public string NameSortParm { get; set; }
        public string DateSortParm { get; set; }
        public string CurrentFilter { get; set; }
        public string SearchString { get; set; }
        public PaginatedList<ViewModel> Results { get; set; }
    }
}