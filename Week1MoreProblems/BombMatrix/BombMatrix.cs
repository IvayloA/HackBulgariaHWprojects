using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombMatrix
{
    class BombMatrix
    {
        static void MatrixBombing(int[,] Matrix, int row, int col)
        {
            int[,] Helper = Matrix;
            int beforeDmg = 0;
            int afterDmg = 0;
            int Dmg = 0;
            foreach (var item in Matrix)
            {
                beforeDmg = beforeDmg + item;
            }


            for (int RIndex = 0; RIndex < Matrix.GetLength(0); RIndex++)
            {
                for (int CIndex = 0; CIndex < Matrix.GetLength(1); CIndex++)
                {
                    if (RIndex == row && CIndex == col)
                    {
                        CIndex++;
                    }

                    Helper[RIndex, CIndex] = Matrix[RIndex, CIndex] - Matrix[row, col];

                }

            }
            foreach (int item in Helper)
            {
                afterDmg = afterDmg + item;
                Console.Write("{0} ", item);
            }
            Dmg = beforeDmg - afterDmg;
            Console.WriteLine(beforeDmg);
            Console.WriteLine(afterDmg);
            Console.WriteLine(Dmg);
        }
        static void Main(string[] args)
        {
            int[,] Array = { { 10, 10, 10 }, { 10, 9, 10 }, { 10, 10, 10 } };
            MatrixBombing(Array,1,1);
            Console.Read();
        }
    }
}
