using _413FinalExam_Demars.Models;

namespace _413FinalExam_Demars.Models
{
    //public class EFFinalRepository : IFinalRepository
    //{
    //    private EntertainmentAgencyExampleContext _context;

    //    public EFFinalRepository(EntertainmentAgencyExampleContext temp)
    //    {
    //        _context = temp;
    //    }

    //    public List<Entertainer> Entertainers => _context.Entertainers.ToList();
    //}

    public class EFFinalRepository : IFinalRepository
    {
        private EntertainmentAgencyExampleContext _context;
        public EFFinalRepository(EntertainmentAgencyExampleContext temp)
        {
            _context = temp;
        }
        public IQueryable<Entertainer> Entertainers => _context.Entertainers;

        public void AddEntertainer(Entertainer entertainer)
        {
            _context.Add(entertainer);
            _context.SaveChanges();
        }

        public void EditEntertainer(Entertainer entertainer)
        {
            _context.Update(entertainer);
            _context.SaveChanges();
        }

        public void DeleteEntertainer(Entertainer entertainer)
        {
            _context.Entertainers.Remove(entertainer);
            _context.SaveChanges();
        }

        public IQueryable<Entertainer> GetEntertainers()
        {
            return _context.Entertainers;
        }
    }

}


