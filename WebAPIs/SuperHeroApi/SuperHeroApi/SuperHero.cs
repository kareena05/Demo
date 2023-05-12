namespace SuperHeroApi
{
    //model or table structure
    public class SuperHero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string place { get; set; }
        public int Age { get; set; } = 0;
    }
}
