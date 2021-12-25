using System.Collections.Generic;

namespace ADS_2
{
    public class BTree
    {
        public BNode Root;
        private const int T = 50;
        private readonly int _maxKeys = 2 * T - 1;
        private static int _maxKeyValue;
        public string SourceFile;
        public int MaxKey
        {
            get => _maxKeyValue;
            set => _maxKeyValue = value;
        }

        public BNode Search(int key)
        {
            if (Root != null)
            {
                return Root.Search(key);
            }
            return null;
        }
        public void Insert(int requiredKey, string newValue)
        {
            if (Root == null)
            {
                Root = new BNode(true);
                Root.Data[0] = new KeyValuePair<int, string>(requiredKey, newValue);
                Root.CountKeys = 1;
            }
            else
            {
                if (Root.CountKeys == _maxKeys)
                {
                    BNode upperNode = new BNode(false);
                    upperNode.Children[0] = Root;
                    upperNode.SplitChild(0, Root);
                    int insertTo = upperNode.Data[0].Key < requiredKey ? 1 : 0;
                    upperNode.Children[insertTo].InsertionToNotFull(requiredKey, newValue);
                    Root = upperNode;
                }
                else
                    Root.InsertionToNotFull(requiredKey, newValue);
            }
            _maxKeyValue += 1;
        }

        public void RemoveRecord(int requiredKey)
        {
            BNode nodeWithRequiredKey = Root.Search(requiredKey);
            nodeWithRequiredKey.RemoveKey(requiredKey);
        }

        public void EditRecord(int requiredKey, string newValue)
        {
            BNode nodeWithRequiredKey = Root.Search(requiredKey);
            int index = nodeWithRequiredKey.FindIndex(requiredKey);
            nodeWithRequiredKey.Data[index] = new KeyValuePair<int, string>(requiredKey, newValue);
        }

        public string GetRecordByKey(int requiredKey)
        {
            BNode nodeWithKey = Root.Search(requiredKey);
            int index = nodeWithKey.FindIndex(requiredKey);
            return nodeWithKey.Data[index].Value;
        }
    }
}
