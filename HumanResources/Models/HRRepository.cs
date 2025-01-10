using HumanResources.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HumanResources.Models
{
    public class HRRepository
    {
        HumanResourcesContext _context;
        public HRRepository()
        {
            _context = new HumanResourcesContext();
        }
        public List<HumanResourcesMaster> GetAllHRMasterData() 
        {
            List<HumanResourcesMaster> humanResourcesMasters = new List<HumanResourcesMaster>();
            humanResourcesMasters = _context.HumanResourcesMasters.ToList();
            return humanResourcesMasters;
        }
        public HumanResourcesMaster GetHRMasterDataByID(int id)
        {
            return _context.HumanResourcesMasters.FirstOrDefault(x => x.Id == id);
        }
        public bool AddHRMasterData(HumanResourcesMaster data)
        {
            List<HumanResourcesMaster> humanResourcesMasters = new List<HumanResourcesMaster>();
            try
            {
                data.LastModifiedBy= "Tester";
                data.LastModifiedTime= DateTime.Now;
                data.CreateTime= DateTime.Now;
                _context.HumanResourcesMasters.Add(data);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
        public bool UpdateHRMasterData(HumanResourcesMaster data)
        {
            List<HumanResourcesMaster> humanResourcesMasters = new List<HumanResourcesMaster>();
            try
            {
                data.LastModifiedBy = "Tester";
                var modify = _context.HumanResourcesMasters.FirstOrDefault(x => x.Id == data.Id);
                if (modify != null)
                {
                    modify.Name = data.Name;
                    modify.Gender = data.Gender;
                    modify.Email = data.Email;
                    modify.Phone = data.Phone;
                    modify.CellPhone = data.CellPhone;
                    modify.WorkRegion = data.WorkRegion;
                    modify.Ability = data.Ability;
                    modify.Status = data.Status;
                    modify.LastModifiedBy = data.LastModifiedBy;
                    modify.LastModifiedTime = DateTime.Now;
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteHRMasterData(int id)
        {
            try
            {
                var modify = _context.HumanResourcesMasters.FirstOrDefault(x => x.Id == id);
                if (modify != null)
                {
                    _context.HumanResourcesMasters.Remove(modify);
                    _context.SaveChanges();
                    return true;
                }
                else
                { 
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
