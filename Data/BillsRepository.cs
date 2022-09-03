using RatingAPI.Entities;
using RatingAPI.DBContext;
using RatingAPI.Models;
using System;
using RatingAPI.Data;
using RatingAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace RatingAPI.Data
{
    public class BillsRepository : IBillsRepository
    {
        private readonly BillsContext _context;
        public BillsRepository(BillsContext context)
        {
            _context = context; //acceso a la db
        }
        public Bills? GetBills(int productId)
        {
            return _context.Bills.FirstOrDefault(p => p.Id == productId);
        }

        public IEnumerable<Bills> GetBills()
        {
            return _context.Bills.OrderBy(x => x.Id).ToList(); ;
        }

        public void DeleteBills(int productId)
        {
            var product = _context.Bills.Find(productId);
            if (product != null)
                _context.Bills.Remove(product);
        }

        public void AddBills(Bills bills)
        {
            _context.Add(bills);
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateBills(Bills bills)
        {
            _context.Entry(bills).State = EntityState.Modified;
        }

    }
    }

/*
 public Bills? GetBills(int idBills)
        {
            return _context.Bills.Where(b => b.Id == idBills).FirstOrDefault();
        }
        public IEnumerable<Bills> SearchBillsByName(string name)
        {
            return _context.Bills.Where(b => b.Nombre.ToLower() == name.ToLower()).ToList();
        }
        public IEnumerable<Bills> GetBills()
        {
            return _context.Bills.OrderBy(c => c.Precio).ToList();
        }
        public bool BillExists(int idBills)
        {
            return _context.Bills.Where(c => c.Id == idBills).Any();
        }
       public bool BillByNameExists(string name)
        {
            return _context.Bills.Where(c => c.Nombre == name).Any();
        }
        public void CreateBill(Bills bills)
        {

            _context.Add(bills);
        }
        public bool GuardarCambios()
        {
            return (_context.SaveChanges() >= 0);
        }
        public void KillBill(int billsId)
        {
            var bill = _context.Bills.Find(billsId);
            if (bill != null)
                _context.Bills.Remove(bill);*/