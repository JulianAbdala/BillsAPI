using AutoMapper;
using RatingAPI.Data;
using RatingAPI.Entities;
using RatingAPI.Models;

namespace RatingAPI.Services
{
    public class BillsServices : IBillsServices
    {
        private readonly IBillsRepository _billsRepository;
        private readonly IMapper _mapper;
        public BillsServices(IMapper mapper, IBillsRepository billsRepository)
        {
            _billsRepository = billsRepository;
            _mapper = mapper;
        }

        public IEnumerable<BillsDto> GetBills()
        {
            var bills = _billsRepository.GetBills();
            return _mapper.Map<IEnumerable<BillsDto>>(bills);
        }

        public BillsDto? GetBills(int id)
        {
            var bill = _billsRepository.GetBills(id);
            return _mapper.Map<BillsDto?>(bill);
        }

        public BillsDto AddBills(PostBillsDto postBillsDto)
        {
            var newbill = _mapper.Map<Bills>(postBillsDto);

            return _mapper.Map<BillsDto>(newbill);
        }

        public void DeleteBills(int billId)
        {
            _billsRepository.DeleteBills(billId);
            _billsRepository.SaveChange();
        }


    }



}


/*public BillsServices(IMapper mapper, BillsRepository BillsRepository)
        {
            _BillsDataRepository = BillsRepository;
            _mapper = mapper;
        }

        public IEnumerable<BillsDto> GetBills()
        {
            var Bills = _BillsDataRepository.GetBills();
            return _mapper.Map<IEnumerable<BillsDto>>(Bills);
        }
        
        public BillsDto? GetBills(int id)
        {
            var Bills = _BillsDataRepository.GetBills(id);
            return _mapper.Map<BillsDto?>(Bills);
        }

        public BillsDto CreateBill(PostBillsDto postBillsDto)
        {
            var newBills = _mapper.Map<Bills>(postBillsDto);

            return _mapper.Map<BillsDto>(newBills);
        }

        public void KillBill(int billsId)
        {
            _BillsDataRepository.KillBill(billsId);
            _BillsDataRepository.GuardarCambios();
        }*/