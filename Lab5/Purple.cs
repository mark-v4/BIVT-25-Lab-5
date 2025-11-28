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

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                int cnt = 0;
                for (int i = 0; i < rows; i++)
                    if (matrix[i, j] < 0) cnt++;
                answer[j] = cnt;
            }

            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int minVal = matrix[i, 0];
                int minIdx = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] < minVal)
                    {
                        minVal = matrix[i, j];
                        minIdx = j;
                    }
                }
                if (minIdx == 0) continue;
                int[] newRow = new int[cols];
                newRow[0] = minVal;
                int pos = 1;
                for (int j = 0; j < cols; j++)
                {
                    if (j == minIdx) continue;
                    newRow[pos++] = matrix[i, j];
                }
                for (int j = 0; j < cols; j++) matrix[i, j] = newRow[j];
            }

            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n, m + 1];
            for (int i = 0; i < n; i++)
            {
                int maxVal = matrix[i, 0];
                int maxIdx = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxIdx = j;
                    }
                }
                int dst = 0;
                for (int j = 0; j <= m; j++)
                {
                    if (j == maxIdx + 1)
                    {
                        answer[i, dst++] = maxVal;
                        continue;
                    }
                    int src = (j <= maxIdx) ? j : j - 1;
                    if (src < m)
                        answer[i, dst++] = matrix[i, src];
                }
            }

            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int maxVal = matrix[i, 0];
                int maxIdx = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxIdx = j;
                    }
                }
                int sum = 0, cnt = 0;
                for (int j = maxIdx + 1; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        cnt++;
                    }
                }
                if (cnt == 0) continue;
                int avg = sum / cnt;
                for (int j = 0; j < maxIdx; j++)
                {
                    if (matrix[i, j] < 0) matrix[i, j] = avg;
                }
            }

            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (k < 0 || k >= cols) return;
            int[] maxes = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int mval = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                    if (matrix[i, j] > mval) mval = matrix[i, j];
                maxes[i] = mval;
            }
            for (int i = 0; i < rows; i++)
            {
                matrix[i, k] = maxes[rows - 1 - i];
            }

            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (array == null || array.Length != cols) return;
            for (int j = 0; j < cols; j++)
            {
                int maxVal = matrix[0, j];
                for (int i = 1; i < rows; i++)
                    if (matrix[i, j] > maxVal) maxVal = matrix[i, j];
                int topIdx = -1;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] == maxVal)
                    {
                        topIdx = i;
                        break;
                    }
                }
                if (topIdx == -1) continue;
                if (array[j] > maxVal)
                {
                    matrix[topIdx, j] = array[j];
                }
            }

            // end

        }
        public void Task7(int[,] matrix)
        {
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows == 0 || cols == 0) return;
            int[] mins = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int minv = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                    if (matrix[i, j] < minv) minv = matrix[i, j];
                mins[i] = minv;
            }
            int[] order = new int[rows];
            for (int i = 0; i < rows; i++) order[i] = i;
            for (int i = 1; i < rows; i++)
            {
                int key = order[i];
                int keyMin = mins[key];
                int j = i - 1;
                while (j >= 0 && mins[order[j]] < keyMin)
                {
                    order[j + 1] = order[j];
                    j--;
                }
                order[j + 1] = key;
            }
            int[,] copy = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int src = order[i];
                for (int j = 0; j < cols; j++) copy[i, j] = matrix[src, j];
            }
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = copy[i, j];
            // end
        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m) return null;
            int len = 2 * n - 1;
            answer = new int[len];
            int baseOffset = n - 1;
            for (int d = -(n - 1); d <= (n - 1); d++)
            {
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    int j = i + d;
                    if (j >= 0 && j < n) sum += matrix[i, j];
                }
                answer[d + baseOffset] = sum;
            }
            // end
            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m) return;
            if (k < 0 || k >= n) return;
            int maxAbs = Math.Abs(matrix[0, 0]);
            int maxI = 0, maxJ = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int a = Math.Abs(matrix[i, j]);
                    if (a > maxAbs)
                    {
                        maxAbs = a;
                        maxI = i;
                        maxJ = j;
                    }
                }
            }
            int[] rowOrder = new int[n];
            int pos = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == maxI) continue;
                rowOrder[pos++] = i;
            }
            for (int i = n - 1; i > k; i--) rowOrder[i] = rowOrder[i - 1];
            rowOrder[k] = maxI;
            int[] colOrder = new int[n];
            pos = 0;
            for (int j = 0; j < n; j++)
            {
                if (j == maxJ) continue;
                colOrder[pos++] = j;
            }
            for (int j = n - 1; j > k; j--) colOrder[j] = colOrder[j - 1];
            colOrder[k] = maxJ;
            int[,] copy = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int srcI = rowOrder[i];
                for (int j = 0; j < n; j++)
                {
                    int srcJ = colOrder[j];
                    copy[i, j] = matrix[srcI, srcJ];
                }
            }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = copy[i, j];
            // end
        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;
            // code here
            int aRows = A.GetLength(0);
            int aCols = A.GetLength(1);
            int bRows = B.GetLength(0);
            int bCols = B.GetLength(1);
            if (aCols != bRows) return null;
            answer = new int[aRows, bCols];
            for (int i = 0; i < aRows; i++)
            {
                for (int j = 0; j < bCols; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < aCols; k++)
                        sum += A[i, k] * B[k, j];
                    answer[i, j] = sum;
                }
            }
            // end
            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                int cnt = 0;
                for (int j = 0; j < cols; j++)
                    if (matrix[i, j] > 0) cnt++;
                int[] row = new int[cnt];
                int p = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0) row[p++] = matrix[i, j];
                }
                answer[i] = row;
            }
            // end
            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;
            // code here
            if (array == null) return new int[0, 0];
            int total = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null) continue;
                total += array[i].Length;
            }
            if (total == 0) return new int[0, 0];
            int[] flat = new int[total];
            int idx = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null) continue;
                for (int j = 0; j < array[i].Length; j++)
                {
                    flat[idx++] = array[i][j];
                }
            }
            int n = (int)Math.Ceiling(Math.Sqrt(total));
            answer = new int[n, n];
            idx = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (idx < total) answer[i, j] = flat[idx++];
                    else answer[i, j] = 0;
                }
            }
            // end
            return answer;
        }
    }
}