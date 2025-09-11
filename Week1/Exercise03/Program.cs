namespace Exercise03

{
    class Person
    {
        public string Name { get; set; }

        public void Introduce()
        {
            Console.WriteLine($"Hello, my name is {Name}.");
        }
        
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Alex";
            person.Introduce();
        }

    }
}