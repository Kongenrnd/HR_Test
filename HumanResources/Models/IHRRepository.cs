using HumanResources.Data;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.Models
{
    public interface IHRRepository
    {
        List<HumanResourcesMaster> GetAllHRMasterData();
        HumanResourcesMaster GetHRMasterDataByID(int id);
        bool AddHRMasterData(HumanResourcesMaster data);
        bool UpdateHRMasterData(HumanResourcesMaster data);
        bool DeleteHRMasterData(int id);
    }
}
