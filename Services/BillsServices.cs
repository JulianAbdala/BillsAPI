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
            var products = _billsRepository.GetBills();
            return _mapper.Map<IEnumerable<BillsDto>>(products);
        }

        public BillsDto? GetBills(int id)
        {
            var product = _billsRepository.GetBills(id);
            return _mapper.Map<BillsDto?>(product);
        }

        public BillsDto AddBills(PostBillsDto postBillsDto)
        {
            var newProduct = _mapper.Map<Bills>(postBillsDto);

            return _mapper.Map<BillsDto>(newProduct);
        }

        public void DeleteBills(int productId)
        {
            _billsRepository.DeleteBills(productId);
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