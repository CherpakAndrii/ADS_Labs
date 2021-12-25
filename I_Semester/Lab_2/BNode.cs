using System;
using System.Collections.Generic;

namespace ADS_2
{
    public class BNode
    {
        private const int T = 50;
        private const int MinKeys = T - 1;
        private const int MaxKeys = 2 * T - 1;

        public readonly BNode[] Children;
        public readonly KeyValuePair<int, string>[] Data;
        public int CountKeys;
        public readonly bool IsLeaf;

        public BNode(bool leaf)
        {
            Data = new KeyValuePair<int, string>[MaxKeys];
            Children = new BNode[2 * T];
            CountKeys = 0;
            IsLeaf = leaf;
        }

        public int FindIndex(int requiredKey)
        {
            int lastGreaterThanKey = 0;
            int index = SharrSearch(requiredKey, ref lastGreaterThanKey);
            return index == -1 ? lastGreaterThanKey : index;
        }

        public void RemoveKey(int key)
        {
            int index = FindIndex(key);

            if (index < CountKeys && Data[index].Key == key)
            {
                if (IsLeaf)
                    RemoveFromLeaf(index);
                else
                    RemoveFromNonLeaf(index);
            }
            else
            {
                if (!IsLeaf)
                {
                    if (Children[index].CountKeys < MinKeys) FillMissing(index);
                    Children[index].RemoveKey(key);
                }
                else
                {
                    Console.WriteLine($"Ключа {key} нет в базе?");
                }
            }
        }

        private void RemoveFromLeaf(int index)
        {
            for (int i = index + 1; i < CountKeys; ++i)
            {
                Data[i - 1] = new KeyValuePair<int, string>(Data[i].Key, Data[i].Value);
            }
            CountKeys -= 1;
        }

        private void RemoveFromNonLeaf(int index)
        {
            int k = Data[index].Key;
            if (Children[index].CountKeys >= T)
            {
                KeyValuePair<int, string> previous = GetPrevious(index);
                Data[index] = new KeyValuePair<int, string>(previous.Key, previous.Value);
                Children[index].RemoveKey(previous.Key);
            }
            else if (Children[index + 1].CountKeys >= T)
            {
                KeyValuePair<int, string> succ = GetNext(index);
                var tempValue = Data[index].Value;
                Data[index] = new KeyValuePair<int, string>(succ.Key, tempValue);
                Children[index + 1].RemoveKey(succ.Key);
            }
            else
            {
                Unite(index);
                Children[index].RemoveKey(k);
            }
        }

        private KeyValuePair<int, string> GetPrevious(int index)
        {
            BNode currentNode = Children[index];
            while (!currentNode.IsLeaf)
                currentNode = currentNode.Children[currentNode.CountKeys];
            return new KeyValuePair<int, string>(currentNode.Data[currentNode.CountKeys - 1].Key, currentNode.Data[currentNode.CountKeys - 1].Value);
        }

        private KeyValuePair<int, string> GetNext(int index)
        {
            BNode currentNode = Children[index + 1];
            while (!currentNode.IsLeaf)
                currentNode = currentNode.Children[0];
            return new KeyValuePair<int, string>(currentNode.Data[0].Key, currentNode.Data[0].Value);
        }

        private void FillMissing(int index)
        {
            if (index != 0 && Children[index - 1].CountKeys >= MinKeys)
                ReplaceFromPrevious(index);
            else if (index != CountKeys && Children[index + 1].CountKeys >= MinKeys)
                ReplaceFromNext(index);
            else
            {
                if (index == CountKeys)
                    Unite(index - 1);
                else
                    Unite(index);
            }
        }

        private void ReplaceFromPrevious(int index)
        {
            BNode replaceFrom = Children[index - 1];
            BNode replaceTo = Children[index];
            
            for (int i = replaceTo.CountKeys - 1; i >= 0; --i)
            {
                replaceTo.Data[i + 1] = new KeyValuePair<int, string>(replaceTo.Data[i].Key, replaceTo.Data[i].Value);
            }

            if (!replaceTo.IsLeaf)
            {
                for (int i = replaceTo.CountKeys; i >= 0; --i)
                {
                    replaceTo.Children[i + 1] = replaceTo.Children[i];
                }
            }

            replaceTo.Data[0] = new KeyValuePair<int, string>(Data[index - 1].Key, Data[index - 1].Value);

            if (!replaceTo.IsLeaf)
                replaceTo.Children[0] = replaceFrom.Children[replaceFrom.CountKeys];

            Data[index - 1] = new KeyValuePair<int, string>(replaceFrom.Data[replaceFrom.CountKeys - 1].Key, replaceFrom.Data[replaceFrom.CountKeys - 1].Value);

            replaceTo.CountKeys += 1;
            replaceFrom.CountKeys -= 1;
        }

        private void ReplaceFromNext(int index)
        {
            BNode replaceFrom = Children[index + 1];
            BNode replaceTo = Children[index];

            replaceTo.Data[replaceTo.CountKeys] = new KeyValuePair<int, string>(Data[index].Key, Data[index].Value);

            if (!replaceTo.IsLeaf)
                replaceTo.Children[replaceTo.CountKeys + 1] = replaceFrom.Children[0];

            Data[index] = new KeyValuePair<int, string>(replaceFrom.Data[0].Key, replaceFrom.Data[0].Value);

            for (int i = 1; i < replaceFrom.CountKeys; ++i)
            {
                replaceFrom.Data[i - 1] = new KeyValuePair<int, string>(replaceFrom.Data[i].Key, replaceFrom.Data[i].Value);
            }

            if (!replaceFrom.IsLeaf)
            {
                for (int i = 1; i <= replaceFrom.CountKeys; ++i)
                {
                    replaceFrom.Children[i - 1] = replaceFrom.Children[i];
                }
            }
            replaceTo.CountKeys += 1;
            replaceFrom.CountKeys -= 1;
        }

        private void Unite(int index)
        {
            BNode uniteIn = Children[index];
            BNode uniteFrom = Children[index + 1];
            uniteIn.Data[MinKeys] = new KeyValuePair<int, string>(Data[index].Key, Data[index].Value);

            for (int i = 0; i < uniteFrom.CountKeys; ++i)
            {
                uniteIn.Data[i + T] = new KeyValuePair<int, string>(uniteFrom.Data[i].Key, uniteFrom.Data[i].Value);
            }

            if (!uniteIn.IsLeaf)
            {
                for (int i = 0; i <= uniteFrom.CountKeys; ++i)
                {
                    uniteIn.Children[i + T] = uniteFrom.Children[i];
                }
            }

            for (int i = index + 1; i < CountKeys; ++i)
            {
                Data[i - 1] = new KeyValuePair<int, string>(Data[i].Key, Data[i].Value);
            }

            for (int i = index + 2; i <= CountKeys; ++i)
            {
                Children[i - 1] = Children[i];
            }

            uniteIn.CountKeys += uniteFrom.CountKeys + 1;
            CountKeys -= 1;
        }

        public void InsertionToNotFull(int key, string value)
        {
            int insertTo = CountKeys - 1;

            if (IsLeaf)
            {
                while (insertTo >= 0 && Data[insertTo].Key > key)
                {
                    Data[insertTo + 1] = new KeyValuePair<int, string>(Data[insertTo].Key, Data[insertTo].Value);
                    insertTo--;
                }

                Data[insertTo + 1] = new KeyValuePair<int, string>(key, value);
                CountKeys += 1;
            }
            else
            {
                while (insertTo >= 0 && Data[insertTo].Key > key)
                    insertTo--;

                if (Children[insertTo + 1].CountKeys == MaxKeys)
                {
                    SplitChild(insertTo + 1, Children[insertTo + 1]);

                    if (Data[insertTo + 1].Key < key)
                        insertTo++;
                }
                Children[insertTo + 1].InsertionToNotFull(key, value);
            }
        }

        public void SplitChild(int splitIndex, BNode nodeToSplit)
        {
            BNode neighborNode = new BNode(nodeToSplit.IsLeaf)
            {
                CountKeys = MinKeys
            };

            for (int j = 0; j < MinKeys; j++)
            {
                neighborNode.Data[j] = new KeyValuePair<int, string>(nodeToSplit.Data[j + T].Key, nodeToSplit.Data[j + T].Value);
            }

            if (!nodeToSplit.IsLeaf)
            {
                for (int j = 0; j < T; j++)
                {
                    neighborNode.Children[j] = nodeToSplit.Children[j + T];
                }
            }

            nodeToSplit.CountKeys = MinKeys;
            for (int j = CountKeys; j >= splitIndex + 1; j--)
            {
                Children[j + 1] = Children[j];
            }
            Children[splitIndex + 1] = neighborNode;

            for (int j = CountKeys - 1; j >= splitIndex; j--)
            {
                Data[j + 1] = new KeyValuePair<int, string>(Data[j].Key, Data[j].Value);
            }
            Data[splitIndex] = new KeyValuePair<int, string>(nodeToSplit.Data[MinKeys].Key, nodeToSplit.Data[MinKeys].Value);
            CountKeys += 1;
        }

        public BNode Search(int key)
        {
            int lastGreaterThanKey = CountKeys;
            int index = SharrSearch(key, ref lastGreaterThanKey);
            if (index != -1 && Data[index].Key == key) return this;
            if (IsLeaf) return null;
            if (index == -1 && !IsLeaf) return Children[lastGreaterThanKey].Search(key);
            return null;
        }

        private int SharrSearch(int requiredKey, ref int lastGreaterThanKey)
        {
            int k = (int)Math.Log(CountKeys, 2);
            int i = (int)Math.Pow(2, k);
            if (Data[i].Key == requiredKey) return i;
            if (requiredKey > Data[i].Key)
            {
                k = (int)Math.Log((CountKeys - Math.Pow(2, k) + 1), 2);
                i = CountKeys + k - (int)Math.Pow(2, k);
                if (Data[i].Key == requiredKey) return i;
            }
            else
            {
                lastGreaterThanKey = i;
                i /= 2;
                if (Data[i].Key == requiredKey) return i;
            }
            int б = (int)Math.Pow(2, k - 1);
            while (б>0)
            {
                if (requiredKey > Data[i].Key)
                {
                    i+=б;
                    if (i >= CountKeys) i = CountKeys - 1;
                }
                else
                {
                    lastGreaterThanKey = i;
                    i -= б;
                }
                if (Data[i].Key == requiredKey) return i;
                б /= 2;
            }
            return -1;
        }
    }
}