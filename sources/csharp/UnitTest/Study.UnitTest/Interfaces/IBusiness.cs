using Study.UnitTest.Models;
using System.Collections.Generic;

namespace Study.UnitTest.Interfaces
{
    public interface IBusiness
    {
        SampleObject GetById(int id);
        IEnumerable<SampleObject> Select(SampleObject obj);
    }
}