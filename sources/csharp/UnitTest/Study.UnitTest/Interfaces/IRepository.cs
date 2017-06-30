using Study.UnitTest.Models;

namespace Study.UnitTest.Interfaces
{
    public interface IRepository
    {
        SampleObject GetById(int id);
    }
}