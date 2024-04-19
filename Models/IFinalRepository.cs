using _413FinalExam_Demars.Models;

namespace _413FinalExam_Demars.Models
{
    public interface IFinalRepository
    {
        IQueryable<Entertainer> Entertainers { get; }

        public IQueryable<Entertainer> GetEntertainers();

        public void AddEntertainer(Entertainer entertainer);

        public void EditEntertainer(Entertainer entertainer);
        public void DeleteEntertainer(Entertainer entertainer);
    }
}
