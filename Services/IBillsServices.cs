using RatingAPI.Models;

namespace RatingAPI.Services
{
    public interface IBillsServices
    {
        IEnumerable<BillsDto> GetBills();
        BillsDto? GetBills(int id);
        BillsDto AddBills(PostBillsDto postBillsDto);
        public void DeleteBills(int billId);
    }
}
