using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here

            answer = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                answer[j] = 0;
                for (int i = 0;  i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        answer[j]++;
                    }
                }
            }

            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                int mini = int.MaxValue;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < mini)
                    {
                        mini = matrix[i, j];
                    }
                }
                a[i, 0] = mini;
                int t = 1;
                for (int j = 0; j < m; j++)
                {
                    if (t != 0 && matrix[i, j] == mini)
                    {
                        t = 0;
                        continue;
                    }
                    a[i, j + t] = matrix[i, j];
                }
            }

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }

            // end

                }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here

            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here

            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here

            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here

            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here

            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here

            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here

            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here

            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here

            // end

            return answer;
        }
    }
}