using System;
using System.Collections.Generic;

namespace ADS_2
{
    public static class UserInput
    {
        public static void Listen(BTree tree)
        {
            Console.WriteLine("1 - Додати запис");
            Console.WriteLine("2 - Редагувати запис");
            Console.WriteLine("3 - Видалити запис");
            Console.WriteLine("4 - Знайти значення за ключем");
            Console.WriteLine("5 - Вивести всi записи");
            Console.WriteLine("6 - Зберегти змiни i вийти");
            Console.WriteLine("Оберiть режим роботи:");
            int type, key;
            while (!int.TryParse(Console.ReadLine(), out type))
            {
                Console.WriteLine("Некоректний ввiд!");
                Console.WriteLine("Оберiть режим роботи:");
            }
            string input;
            while (type != 6)
            {
                switch (type)
                {
                    case 1:
                        key = tree.MaxKey;
                        while (tree.Search(key) != null)
                        {
                            key++;
                        }
                        tree.MaxKey = key;
                        Console.WriteLine("Який запис треба додати?");
                        input = Console.ReadLine();
                        tree.Insert(key, input);
                        Console.WriteLine($"Додано: {key} - {input}");
                        break;

                    case 2:
                        Console.WriteLine("Введiть ключ для редагування запису:");
                        key = int.Parse(Console.ReadLine());
                        if (tree.Search(key) != null)
                        {
                            Console.WriteLine("Введiть новий запис:");
                            input = Console.ReadLine();
                            tree.EditRecord(key, input);
                        }
                        else
                        {
                            Console.WriteLine("Запису з таким ключем немає. Додати запис? [y/n]");
                            string YesOrNo = Console.ReadLine();
                            while (!new List<string>{"Y", "y", "Yes", "yes", "Ok", "ok", "Okay", "okay", "+", "Так", "так", "N", "n", "No", "no", "-", "Ні", "ні"}.Contains(YesOrNo))
                            {
                                Console.WriteLine("Некоректний ввід! Оберіть з таких варіантів: Y, N");
                                YesOrNo = Console.ReadLine();
                            }

                            if (new List<string> { "Y", "y", "Yes", "yes", "Ok", "ok", "Okay", "okay", "+", "Так", "так" }.Contains(YesOrNo))
                            {
                                Console.WriteLine("Який запис треба додати?");
                                input = Console.ReadLine();
                                tree.Insert(key, input);
                                Console.WriteLine($"Додано: {key} - {input}");
                            }
                        }

                        break;

                    case 3:
                        Console.WriteLine("Введiть ключ для видалення:");
                        key = int.Parse(Console.ReadLine());
                        if (tree.Search(key) != null)
                        {
                            tree.RemoveRecord(key);
                        }
                        else
                            Console.WriteLine("Запису з таким ключем немає");
                        break;

                    case 4:
                        Console.WriteLine("Введiть ключ для пошуку значення: ");
                        key = int.Parse(Console.ReadLine());
                        if (tree.Search(key) != null)
                        {
                            Console.WriteLine($"Запис найдений: {tree.GetRecordByKey(key)}");
                        }
                        else
                            Console.WriteLine("Запису з таким ключем немає");
                        break;

                    case 5:
                        if (tree.Root!=null) Print(tree.Root);
                        else Console.WriteLine("Дерево порожнє!");
                        break;
                    default:
                        Console.WriteLine("Невiдома команда!");
                        break;
                }
                Console.WriteLine("Оберiть наступну дiю:");
                while (!int.TryParse(Console.ReadLine(), out type))
                {
                    Console.WriteLine("Некоректний ввiд!");
                    Console.WriteLine("Оберiть режим роботи:");
                }
            }
            WorkWithFile.TreeToFile(tree);
        }
        
        private static void Print(BNode node)
        {
            int currentIndex;
            for (currentIndex = 0; currentIndex < node.CountKeys; currentIndex++)
            {
                if (!node.IsLeaf)
                    Print(node.Children[currentIndex]);
                Console.WriteLine($"{node.Data[currentIndex].Key};{node.Data[currentIndex].Value}");
            }

            if (!node.IsLeaf) Print(node.Children[currentIndex]);
        }
    }
}