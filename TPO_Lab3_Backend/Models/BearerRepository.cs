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

        public int Authorize(Bearer bearer)
        {
            bool bearerExists =
                _context.Bearer.Any(b => b.Nickname == bearer.Nickname && b.Password == bearer.Password);
            if (bearerExists)
            {
                var a = _context.Bearer.First(b => b.Nickname == bearer.Nickname && b.Password == bearer.Password);
                return a.Id;
            }
            return 0;
        }
        public int RegisterNewBearer(Bearer bearer)
        {
            _context.Bearer.Add(bearer);
            _context.SaveChanges();
            return bearer.Id;
        }
    }
}