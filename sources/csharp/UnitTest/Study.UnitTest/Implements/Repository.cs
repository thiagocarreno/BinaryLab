using Study.UnitTest.Interfaces;
using Study.UnitTest.Models;
using System.Collections.Generic;

namespace Study.UnitTest.Implements
{
    public class Repository : IRepository
    {
        public SampleObject GetById(int id)
        {
            return default(SampleObject);
        }

        public IEnumerable<SampleObject> Select(SampleObject obj)
        {
            return new List<SampleObject>
            {
                new SampleObject { Id = 1 }
            };
        }
    }
}
