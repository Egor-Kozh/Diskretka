using System.Collections.Specialized;
using System.Runtime.Intrinsics.X86;
using static System.Net.Mime.MediaTypeNames;

namespace Hello
{
    class Programm
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задайте граф при помощи матрицы\n");
            Console.Write("Количество вершин: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] graf = new int[n, n];
            Console.WriteLine("Заполните матрицу, где ее элементы будут веса ребёр");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    graf[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            List<List<int>> dots = new List<List<int>>();
            dots.Add(new List<int>() { -1 });
            List<int> sum = new List<int>();
            while (sum.Count != n - 1)
            {
                int a = 100000000, I = 0, J = 0, g = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (graf[i, j] < a && graf[i, j] != 0)
                        {
                            g = graf[i, j];
                            a = g;
                            I = i; J = j;
                        }
                    }
                }
                graf[I, J] = 0; graf[J, I] = 0;


                int i2 = 0; int i3 = 0;
                bool b1 = false; bool b2 = false; bool b3 = false;
                for (int i1 = 0; i1 < dots.Count; i1++)
                {
                    foreach (int j1 in dots[i1])
                    {
                        if (I == j1 || J == j1)
                        {
                            if (I == j1) { b1 = true; i2 = i1; }
                            else { b2 = true; i3 = i1; }
                        }
                    }
                }
                if (b1 == true && b2 == true && i2 != i3) { b3 = true; }

                if (b1 == false && b2 == false)
                {
                    dots.Add(new List<int>() { I, J });
                    sum.Add(g);
                }
                else if (b1 == true && b2 == true && b3 == true)
                {
                    foreach (int o in dots[i3])
                    {
                        dots[i2].Add(o);
                    }
                    dots[i3].Clear();
                    dots[i3].Add(-2);
                    sum.Add(g);
                }
                else if ((b1 == true && b2 == false) || (b2 == true && b1 == false))
                {
                    if (b1 == true) { dots[i2].Add(J); }
                    else { dots[i3].Add(I); }
                    sum.Add(g);
                }

                Console.WriteLine();
                for (int i = 0; i < dots.Count; i++)
                {
                    foreach (int j1 in dots[i])
                    {
                        Console.Write(j1 + " ");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            int b = 0;
            foreach (int i in sum)
            {
                b += i;
                Console.Write(i + " ");
            }
            Console.WriteLine("\n" + b);

        }
    }
}
