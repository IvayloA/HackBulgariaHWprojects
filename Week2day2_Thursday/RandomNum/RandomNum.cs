using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace week2day2
{
    class RandomNum
    {
       

        static  void GenerateRandomMatrix(int rows, int columns, string fileName)
        {
            int[,] RndNumArray = new int[rows,columns];
            Random generator = new Random();
            string[] output = new string[RndNumArray.GetUpperBound(0) + 1];
            string myArray = ""; 


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {

                    RndNumArray[i,j] = generator.Next(1,1000)
                    myArray = myArray + " " + RndNumArray[i, j];
                }
            }
        
         
            File.WriteAllText(fileName, myArray);

        }
        static void Main(string[] args)
        {
            int rows = 5;
            int columns = 5;
            string path = "RandomArray.txt";

            GenerateRandomMatrix(rows, columns, path);

        }
    }
}
