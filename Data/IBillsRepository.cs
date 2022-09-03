using RatingAPI.Entities;
using static RatingAPI.Controllers.AuthenticationController;

namespace RatingAPI.Data
{
    public interface IBillsRepository
    {
        public IEnumerable<Bills> GetBills();
        public Bills? GetBills(int idBills);
        public void AddBills(Bills bills);
        public void DeleteBills(int billId);
        public void UpdateBills(Bills bills);
        public bool SaveChange();
        public IEnumerable<Bills> SearchBillsByName(string name);
        public bool BillByNameExists(string name);
    }
}