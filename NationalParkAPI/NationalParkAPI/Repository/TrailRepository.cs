using Microsoft.EntityFrameworkCore;
using NationalParkAPI.DataAccess;
using NationalParkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TrailAPI.Repository.IRepository;

namespace TrailAPI.Repository
{
    public class TrailRepository : ITrailRepository
    {
        
        private readonly ApplicationDbContext _db;

        //dependency injection via constructor
        public TrailRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateTrail(Trail trail)
        {
            _db.Trails.Add(trail);
            return Save();
        }

        public bool DeleteTrail(Trail trail)
        {
            _db.Trails.Remove(trail);
            return Save();
        }

        public Trail GetTrail(int trailId)
        {
            return _db.Trails.Include(c => c.NationalPark).FirstOrDefault(_ => _.Id == trailId);
        }

        public ICollection<Trail> GetTrails()
        {
            return _db.Trails.Include(c => c.NationalPark).OrderBy(_ => _.Name).ToList();
        }

        public bool TrailExists(string name)
        {
            bool value = _db.Trails.Any(_ => _.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool TrailExists(int id)
        {
            return _db.Trails.Any(_ => _.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateTrail(Trail trail)
        {
            _db.Trails.Update(trail);
            return Save();
        }

        public ICollection<Trail> GetTrailsInNationalPark(int npId)
        {
            return _db.Trails.Include(c => c.NationalPark).Where(c => c.NationalParkId == npId).ToList();
        }
    }
}
