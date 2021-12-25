// /using System;
// using System.Collections.Generic;
// using System.Runtime.CompilerServices;
//
// namespace Lab5
// {
    /*public class Kata
    {
        public static string Add(string a, string b)
        {
            string bigger = a.Length >= b.Length ? "0"+a : "0"+b, smaller = a.Length >= b.Length ? "0"+b : "0"+a, res = "", strPart;
            int carry = 0, part;

            for (int i = 1; i <= smaller.Length; i++)
            {
                part = bigger[^i] + smaller[^i] - 96 + carry;
                carry = part / 10;
                part %= 10;
                res = part + res;
            }
            
            
            
            
            while (smaller.Length > 9)
            {
                part = Int32.Parse(bigger.Substring(bigger.Length - 9, 9)) +
                           Int32.Parse(smaller.Substring(smaller.Length - 9, 9)) + carry;
                if (part > 999999999)
                {
                    part %= 1000000000;
                    carry = 1;
                }
                else carry = 0;

                strPart = Convert.ToString(part);
                while (strPart.Length < 9) strPart = "0" + strPart;
                res = strPart + res;
                bigger = bigger.Substring(bigger.Length - 9);
                smaller = smaller.Substring(smaller.Length - 9);
            }

            if (bigger.Length <= 9) res = Convert.ToString(Int32.Parse(bigger)+Int32.Parse(smaller)+carry)+ res;
            else
            {
                part = Int32.Parse(bigger.Substring(bigger.Length - 9, 9)) +
                       Int32.Parse(smaller) + carry;
                if (part > 999999999)
                {
                    part %= 1000000000;
                    carry = 1;
                }
                else carry = 0;

                strPart = Convert.ToString(part);
                while (strPart.Length < 9) strPart = "0" + strPart;
                res = strPart + res;
                bigger = bigger.Substring(bigger.Length - 9);

                while (bigger.Length>9)
                {
                    part = Int32.Parse(bigger.Substring(bigger.Length - 9, 9)) + carry;
                    if (part > 999999999)
                    {
                        part %= 1000000000;
                        carry = 1;
                    }
                    else carry = 0;

                    strPart = Convert.ToString(part);
                    while (strPart.Length < 9) strPart = "0" + strPart;
                    res = strPart + res;
                    bigger = bigger.Substring(bigger.Length - 9);
                }
                res = Convert.ToString(Int32.Parse(bigger)+carry)+ res;
            }
            return res;
        }
    }
}*/
//     public static class Tests
//     {
//         public static KeyValuePair<int, string> isWinPos()
//         {
//             int problemCtr = 0;
//             string problemCases = "";
//             Game gm = new Game();
//             Game.FieldSize = 5;
//             int[,] inp = new int[4,5]{
//                 {1, 0, 0, 0, 1},
//                 {0, 1, 1, 1, 1},
//                 {0, 1, 1, 1, 1},
//                 {0, 1, 1, 1, 1}};
//             if (!gm.PositionIsWinning(inp))
//             {
//                 problemCtr++;
//                 problemCases += "1, ";
//             }
//             inp = new int[4,5]{
//                 {1, 0, 1, 1, 1},
//                 {0, 1, 1, 1, 1},
//                 {1, 1, 1, 1, 1},
//                 {1, 1, 1, 1, 1}};
//             if (!gm.PositionIsWinning(inp))
//             {
//                 problemCtr++;
//                 problemCases += "2, ";
//             }
//             inp = new int[4,5]{
//                 {1, 1, 1, 1, 1},
//                 {1, 1, 1, 1, 1},
//                 {1, 1, 1, 1, 1},
//                 {1, 1, 1, 1, 1}};
//             if (!gm.PositionIsWinning(inp))
//             {
//                 problemCtr++;
//                 problemCases += "3, ";
//             }
//             inp = new int[4,5]{
//                 {1, 0, 0, 1, 1},
//                 {0, 1, 1, 1, 1},
//                 {1, 1, 1, 1, 1},
//                 {1, 1, 1, 1, 1}};
//             if (gm.PositionIsWinning(inp))
//             {
//                 problemCtr++;
//                 problemCases += "4, ";
//             }
//             inp = new int[4,5]{
//                 {1, 0, 0, 0, 0},
//                 {0, 0, 0, 0, 1},
//                 {1, 1, 1, 1, 1},
//                 {1, 1, 1, 1, 1}};
//             if (!gm.PositionIsWinning(inp))
//             {
//                 problemCtr++;
//                 problemCases += "5, ";
//             }
//             inp = new int[4,5]{
//                 {1, 0, 1, 1, 1},
//                 {0, 0, 1, 1, 1},
//                 {0, 0, 1, 1, 1},
//                 {0, 1, 1, 1, 1}};
//             if (!gm.PositionIsWinning(inp))
//             {
//                 problemCtr++;
//                 problemCases += "6, ";
//             }
//             return new (problemCtr, problemCases);
//         }
//         public static KeyValuePair<int, string> isLosPos()
//         {
//             int problemCtr = 0;
//             string problemCases = "";
//             Game gm = new Game();
//             Game.FieldSize = 5;
//             int[,] inp = new int[4,5]{
//                 {1, 0, 0, 0, 0},
//                 {0, 1, 1, 1, 1},
//                 {0, 1, 1, 1, 1},
//                 {0, 1, 1, 1, 1}};
//             if (!gm.PositionIsLosing(inp))
//             {
//                 problemCtr++;
//                 problemCases += "1, ";
//             }
//             inp = new int[4,5]{
//                 {1, 0, 0, 0, 1},
//                 {0, 1, 1, 1, 1},
//                 {1, 1, 1, 1, 1},
//                 {1, 1, 1, 1, 1}};
//             if (!gm.PositionIsLosing(inp))
//             {
//                 problemCtr++;
//                 problemCases += "2, ";
//             }
//             inp = new int[4,5]{
//                 {1, 0, 0, 0, 0},
//                 {1, 1, 1, 1, 1},
//                 {1, 1, 1, 1, 1},
//                 {1, 1, 1, 1, 1}};
//             if (!gm.PositionIsLosing(inp))
//             {
//                 problemCtr++;
//                 problemCases += "3, ";
//             }
//             inp = new int[4,5]{
//                 {1, 0, 0, 1, 1},
//                 {0, 0, 1, 1, 1},
//                 {1, 1, 1, 1, 1},
//                 {1, 1, 1, 1, 1}};
//             if (gm.PositionIsLosing(inp))
//             {
//                 problemCtr++;
//                 problemCases += "4, ";
//             }
//             inp = new int[4,5]{
//                 {1, 0, 0, 0, 0},
//                 {0, 0, 0, 0, 0},
//                 {1, 1, 1, 1, 1},
//                 {1, 1, 1, 1, 1}};
//             if (!gm.PositionIsLosing(inp))
//             {
//                 problemCtr++;
//                 problemCases += "5, ";
//             }
//             inp = new int[4,5]{
//                 {1, 0, 1, 1, 1},
//                 {0, 0, 1, 1, 1},
//                 {0, 1, 1, 1, 1},
//                 {0, 1, 1, 1, 1}};
//             if (!gm.PositionIsLosing(inp))
//             {
//                 problemCtr++;
//                 problemCases += "6, ";
//             }
//             return new (problemCtr, problemCases);
//         } 
//     }
// }