namespace ADS_2
{
    static class Program
    {
        static void Main(string[] args)
        {
            BTree bTree = WorkWithFile.ImportFromFile();
            UserInput.Listen(bTree);
        }
    }
}