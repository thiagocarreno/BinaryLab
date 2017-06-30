using Study.UnitTest.Interfaces;
using Study.UnitTest.Models;

namespace Study.UnitTest.Implements
{
    public class Repository : IRepository
    {
        public SampleObject GetById(int id)
        {
            return default(SampleObject);
        }
    }
}
