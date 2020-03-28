using NationalParkAPI.DataAccess;
using NationalParkAPI.Models;
using NationalParkAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NationalParkAPI.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        
        private readonly ApplicationDbContext _db;

        //dependency injection via constructor
        public NationalParkRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateNationalPark(NationalParkDto nationalPark)
        {
            _db.NationalParks.Add(nationalPark);
            return Save();
        }

        public bool DeleteNationalPark(NationalParkDto nationalPark)
        {
            _db.NationalParks.Remove(nationalPark);
            return Save();
        }

        public NationalParkDto GetNationalPark(int nationalParkId)
        {
            return _db.NationalParks.FirstOrDefault(_ => _.Id == nationalParkId);
        }

        public ICollection<NationalParkDto> GetNationalParks()
        {
            return _db.NationalParks.OrderBy(_ => _.Name).ToList();
        }

        public bool NationalParkExists(string name)
        {
            bool value = _db.NationalParks.Any(_ => _.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool NationalParkExists(int id)
        {
            return _db.NationalParks.Any(_ => _.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateNationalPark(NationalParkDto nationalPark)
        {
            _db.NationalParks.Update(nationalPark);
            return Save();
        }
    }
}
