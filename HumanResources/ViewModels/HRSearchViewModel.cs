using HumanResources.Models;

namespace HumanResources.ViewModels
{
    public class HRSearchViewModel
    {
        public List<HumanResourcesMaster> HumanResourcesMasters { get; set; } = new List<HumanResourcesMaster>();
        public string Title { get; set; } = string.Empty;
    }
}
