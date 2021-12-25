using System.IO;

namespace ADS_2
{
    public static class WorkWithFile
    {
        public static BTree ImportFromFile(string fileName = "data.csv")
        {
            BTree tree = new ()
            {
                SourceFile = fileName
            };
            using (StreamReader streamReader = new (fileName))
            {
                int dataKey;
                string currentLine, dataValue;
                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    if (currentLine == "")
                        continue;
                    dataKey = int.Parse(currentLine.Split(';')[0]);
                    dataValue = currentLine.Split(';')[1];
                    if (tree.Search(dataKey) == null)
                        tree.Insert(dataKey, dataValue);
                }
            }

            return tree;
        }
        
        public static void TreeToFile(BTree tree, string fileName = null)
        {
            if (tree.Root==null) return;
            fileName ??= tree.SourceFile;
            using (StreamWriter streamWriter = new StreamWriter(fileName, false)) NodeToFile(tree.Root, streamWriter);
        }

        private static void NodeToFile(BNode node, StreamWriter sw)
        {
            int currentIndex;
            for (currentIndex = 0; currentIndex < node.CountKeys; currentIndex++)
            {
                if (!node.IsLeaf)
                    NodeToFile(node.Children[currentIndex], sw);
                sw.WriteLine($"{node.Data[currentIndex].Key};{node.Data[currentIndex].Value}");
            }
            
            if (!node.IsLeaf) NodeToFile(node.Children[currentIndex], sw);
        }
    }
}
/*      public static void Add(int key, string value, string fileName)
        {
            using (StreamWriter streamWriter = new StreamWriter(fileName, true)) streamWriter.WriteLine($"{key};{value}");
        }

        public static void Edit(int key, string value, string fileName)
        {
            string temporaryFileName = "temp.csv";
            for (int i = 0; File.Exists(temporaryFileName); i++) temporaryFileName = $"temp{i}.csv";
            
            File.Copy(fileName, temporaryFileName);
            using (StreamReader streamReader = new StreamReader(temporaryFileName))
            {
                using StreamWriter streamWriter = new StreamWriter(fileName);
                string currentLine;
                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    if (int.Parse(currentLine.Split(';')[0]) != key)
                        streamWriter.WriteLine(currentLine);
                    else
                        streamWriter.WriteLine($"{key};{value}");
                }
            }
            File.Delete(temporaryFileName);
        }

        public static void Remove(int key, string fileName)
        {
            string temporaryFileName = "temp.csv";
            for (int i = 0; File.Exists(temporaryFileName); i++) temporaryFileName = $"temp{i}.csv";
            
            File.Copy(fileName, temporaryFileName);
            using (StreamReader streamReader = new StreamReader(temporaryFileName))
            {
                using StreamWriter streamWriter = new StreamWriter(fileName);
                string currentLine;
                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    if (int.Parse(currentLine.Split(';')[0]) != key)
                        streamWriter.WriteLine(currentLine);
                }
            }
            File.Delete(temporaryFileName);
        }
*/