using System.Linq;

namespace TPO_Lab3_Backend.Models
{
    public class BearerRepository
    {
        private readonly TpoContext _context;

        public BearerRepository(TpoContext context)
        {
            _context = context;
        }

        public Bearer GetBearerByNickname(string nickname)
        {
            return _context.Bearer.First(bearer => bearer.Nickname == nickname);
        }

        public Bearer GetBearerById(int bearerId)
        {
            return _context.Bearer.First(bearer => bearer.Id == bearerId);
        }

        public bool IsBearerNicknameFree(string nickname)
        {
            return !_context.Bearer.Any(b => b.Nickname == nickname);
        }

        public bool Authorize(Bearer bearer)
        {
            return _context.Bearer.Any(b => b.Nickname == bearer.Nickname && b.Password == bearer.Password);
        }
        public void RegisterNewBearer(Bearer bearer)
        {
            _context.Bearer.Add(bearer);
            _context.SaveChanges();
        }
    }
}