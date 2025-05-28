using System;
using System.Text;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] array3D = {
                { { 1, 2 }, { 3, 4 } },
                { { 4, 5 }, { 6, 7 } },
                { { 7, 8 }, { 9, 10 } },
                { { 10, 11 }, { 12, 13 } }
            };

            string formattedArray = Format3DArray(array3D);
            Console.WriteLine(formattedArray);
            Console.ReadKey();
        }

        static string Format3DArray(int[,,] array)
        {
            var sb = new StringBuilder();
            sb.Append("{");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                sb.Append("{");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sb.Append("{");
                    sb.Append(string.Join(", ", GetRow(array, i, j)));
                    sb.Append("}");
                    if (j < array.GetLength(1) - 1)
                        sb.Append(", ");
                }
                sb.Append("}");
                if (i < array.GetLength(0) - 1)
                    sb.Append(", ");
            }

            sb.Append("}");
            return sb.ToString();
        }

        static int[] GetRow(int[,,] array, int i, int j)
        {
            int[] row = new int[array.GetLength(2)];
            for (int k = 0; k < array.GetLength(2); k++)
                row[k] = array[i, j, k];
            return row;
        }
    }
}
