using HumanResources.Models;

namespace HumanResources.ViewModels
{
    public class AccountManagementSearchViewModel
    {
        public List<SystemUserData> UserDatas { get; set; } = new List<SystemUserData>();

        public string Title { get; set; } = string.Empty;
    }
}
