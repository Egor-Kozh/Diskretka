namespace Hello
{
    class Programm1
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
            Console.Write("Введите номер вершины с которой начать поиск: ");
            int num = Convert.ToInt32(Console.ReadLine());
            List<int> cashe = new List<int> { num - 1 };

            List<int> dot = new List<int>();
            for (int i = 0; i < n - 1; i++)
            {
                dot.Add(Poisk(ref graf, cashe, n));
            }


            int b = 0;
            foreach (int i in dot)
            {
                b += i;
            }
            Console.WriteLine(b);
        }

        static int Poisk(ref int[,] graf, List<int> cashe, int n)
        {
            int I = 0, J = 0;
            int a = 1000000000;
            foreach (int i in cashe)
            {
                for (int j = 0; j < n; j++)
                {
                    if (graf[i, j] < a && graf[i, j] > 0)
                    {
                        a = graf[i, j];
                        I = i;
                        J = j;
                    }
                }
            }
            graf[I, J] = 0;
            graf[J, I] = 0;
            cashe.Add(J);
            return a;
        }
    }
}
