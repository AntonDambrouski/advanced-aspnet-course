namespace Basic_Programming_Principles.DesignPatterns
{
    enum EyesColor
    {
        Blue,
        Green,
        Brown
    }

    enum HairColor
    {
        Black,
        Brown,
        Blonde
    }

    class Person
    {
        public Person()
        {
                
        }
        public Person(EyesColor eyesColor, HairColor hairColor, string name, int age, int height, int weight)
        {
            EyesColor = eyesColor;
            HairColor = hairColor;
            Name = name;
            Age = age;
            Height = height;
            Weight = weight;
        }

        public EyesColor EyesColor { get; set; }
        public HairColor HairColor { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }

    class PersonBuilder
    {
        private Person person;

        public PersonBuilder()
        {
            person = new Person();
        }

        public PersonBuilder WithName(string name)
        {
            person.Name = name;
            return this;
        }
        public PersonBuilder WithAge(int age)
        {
            person.Age = age;
            return this;
        }
        public PersonBuilder WithHeight(int height)
        {
            person.Height = height;
            return this;
        }
        public PersonBuilder WithWeight(int weight)
        {
            person.Weight = weight;
            return this;
        }
        public Person Build()
        {
            return person;
        }
    }



    public class BuilderDemo
    {
        public static void Execute()
        {
            var person = new Person(EyesColor.Blue, HairColor.Brown, "John",age:  25, height: 180, 80);

            var personBuilder = new PersonBuilder()
                .WithName("John");
            //if (true)
            //{
            //    personBuilder.WithAge(25);
            //}
            
            //    .WithAge(25)
            //    .WithHeight(180)
            //    .WithWeight(80)
            //    .Build();
        }
    }
}
