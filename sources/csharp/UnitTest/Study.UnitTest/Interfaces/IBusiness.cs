using Study.UnitTest.Models;

namespace Study.UnitTest.Interfaces
{
    public interface IBusiness
    {
        SampleObject GetById(int id);
    }
}