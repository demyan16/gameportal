namespace GamePortal
{
    public class Game
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private int _year;

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public Game(string name, string description, int year)
        {
            Name = name;
            Description = description;
            Year = year;
        }
    }
}