using Study.UnitTest.Interfaces;
using Study.UnitTest.Models;

namespace Study.UnitTest.Implements
{
    public class Business : IBusiness
    {
        readonly IRepository _repository;

        public Business(IRepository repository)
        {
            _repository = repository;
        }

        public SampleObject GetById(int id)
        {
            var result = default(SampleObject);

            if (id > default(int))
                result = _repository.GetById(id);

            return result;
        }
    }
}
