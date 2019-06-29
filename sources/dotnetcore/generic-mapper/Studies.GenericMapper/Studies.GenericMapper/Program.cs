namespace Studies.GenericMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        static void Test()
        {
            var mapper = new Mapper
            {
                Mapping = new MapperObject[1]
                {
                    new MapperObject
                    {
                        Name = "Name",
                        Type = PropertyType.String,
                        To = new MapperObject
                        {
                            Name = "Nome",
                            Type = PropertyType.String
                        }
                    }
                }
            };


        }
    }

    class Mapper
    {
        public MapperObject[] Mapping { get; set; }
    }

    class MapperObject
    {
        public string Name { get; set; }
        public PropertyType Type { get; set; }
        public MapperObject To { get; set; }
    }

    enum PropertyType
    {
        String = 1,
        Int = 2,
        Decimal = 3,
        Array = 4
    }
}