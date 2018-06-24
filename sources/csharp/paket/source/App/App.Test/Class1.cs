using App.Core;
using Xunit;

namespace App.Test
{
    public class Class1
    {
        public Class1()
        {

        }

        [Fact(DisplayName = "Dog speaking")]
        public void Should_Dogs_Say_Woof()
        {
            IAnimal dog = new Dog();
            Assert.Equal(dog.Speak(), "Woof");
        }

        [Fact(DisplayName = "Cat speaking")]
        public void Should_Cats_Say_Meow()
        {
            IAnimal cat = new Cat();
            Assert.Equal(cat.Speak(), "Meow");
        }

    }
}
