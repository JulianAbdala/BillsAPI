using RatingAPI.Entities;
using static RatingAPI.Controllers.AuthenticationController;

namespace RatingAPI.Data
{
    public interface IBillsRepository
    {
        public IEnumerable<Bills> GetBills();
        public Bills? GetBills(int idProduct);
        public void AddBills(Bills product);
        public void DeleteBills(int productId);
        public void UpdateBills(Bills product);
        public bool SaveChange();
    }
}


/*//bool BillExists(int idBills);
        void CreateBill(Bills bills);
        public IEnumerable<Bills> GetBills();
        public Bills? GetBills(int idBills);
        //public IEnumerable<Bills> SearchBillsByName(string name);
        bool GuardarCambios();
        //bool BillByNameExists(string name);
        void KillBill(int billsId);*/