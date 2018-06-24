using Study.UnitTest.Models;
using System.Collections.Generic;

namespace Study.UnitTest.Interfaces
{
    public interface IRepository
    {
        SampleObject GetById(int id);
        IEnumerable<SampleObject> Select(SampleObject obj);
    }
}