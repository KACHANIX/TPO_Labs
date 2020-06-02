using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPO_Lab3_Backend.Models
{
    public class AlmsgivingRepository
    {
        private readonly TpoContext _context;

        public AlmsgivingRepository(TpoContext context)
        {
            _context = context;
        }

        public List<Almsgiving> GetAllAlmsgivings()
        {
            return _context.Almsgiving.Select(p => p).ToList();
        }

        public Almsgiving GetAlmsgivingById(int almsgivingId)
        {
            return _context.Almsgiving.First(a => a.Id == almsgivingId);
        }

        public List<Almsgiving> SearchAlmsgivings(string name)
        {
            return _context.Almsgiving.Where(p => p.Name.Contains(name)).ToList();
        }

        public List<Almsgiving> GetAllBearersAlmsgivings(int bearerId)
        {
            return _context.Almsgiving.Where(a => a.BearerId == bearerId).ToList();
        }

        public void DeleteAlmsgiving(int almsgivingId)
        { 
            _context.Almsgiving.Remove(GetAlmsgivingById(almsgivingId));
            _context.SaveChanges();
        }

        public void AddAlmsgiving(Almsgiving almsgiving)
        {
            _context.Almsgiving.Add(almsgiving);
            _context.SaveChanges();
        }
    }
}