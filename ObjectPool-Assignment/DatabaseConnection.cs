namespace ObjectPool_Assignment
{
    public class DatabaseConnection
    {
        public DatabaseConnection(string name)
        {
            Name = name;
        }

        public DatabaseConnection()
        {
            
        }

        public string Name { get; set; }
    }
}