using System;

namespace DZ4
{
    class Program
    {
        static void SS(int n,int[] a)
        {
            Console.WriteLine("Enter C");
            int C = int.Parse(Console.ReadLine());
            for (int i=0;i<n;i++)
            {
                if (a[i] > C)
                    Console.Write("{0} ", a[i]);
            }
        }
        static Double Mutiply(int n,int[] a)
        {
            int Max;
            Double p=1;
            int[] b = a;
            int d=0;
            Array.Sort(b);
            if (Math.Abs(b[0]) > Math.Abs(b[n - 1]))
                Max = Math.Abs(b[0]);
            else Max = Math.Abs(b[n-1]);
            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(a[i])==Max)
                {
                    d = i;
                    while(d<n)
                    {
                        p = p * a[d];
                        d++;
                    }
                    break;
                }
            }
            return p;

        }

        static void Output1(int n,int[] a)
        {
            int[] c=new int[n];
            int d = 0;
            for (int i = 0; i < n ; i++)
            {
                if (a[i] < 0)
                {  c[d] = a[i];
                    d++; 
                }
            }
            for (int i=0;i<n;i++)
            {
                if (a[i] >= 0)
                {
                    c[d] = a[i];
                    d++;
                }
            }
            for (int i=0;i<n;i++)
            {
                Console.Write("{0} ", c[i]);
            }
        }
        static void Output2(int m,int n, int[,] a)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("a[{0},{1}]={2}\t", i, j, a[i, j]);
                }
                Console.WriteLine();
            }
        }
        static int Number0(int m, int n,int[,] a)
        {
            Boolean check=false;
            int d = 0;
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < m; i++)
                {
                    if (a[i, j] == 0)
                    {
                        check = true;
                        d = j+1;
                        break;
                    }                       
                }
                if (check == true)
                    break;
            }
            return d;
        }
        static void swap(int m, int n, int[,] a)
        {
            int h;
            int[] c = new int[n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c[i] += a[i, j];
                }
            }
            for (int i = 0; i < m-1; i++)
            {
                for (int j =i+1 ; j < m; j++)
                {
                    if (c[i]<c[j])
                    {
                        for (int d = 0; d < n; d++)
                        {
                            h = a[i, d];
                            a[i, d] = a[j, d];
                            a[j, d] = h;
                        }
                    }
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0}  ", a[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int choose;
            Console.WriteLine("enter 1: one - dimensional arrays");
            Console.WriteLine("enter 2: two - dimensional arrays");
            choose = int.Parse(Console.ReadLine());
            switch(choose)
            {
                case 1:
                    {
                        int n;
                        Console.WriteLine("enter n :");
                        n = int.Parse(Console.ReadLine());
                        Random r = new Random();
                        int[] a = new int[n];
                        for (int i = 0; i < n; i++)
                        {
                            a[i] = r.Next(-100, 100);
                            Console.Write("a[{0}]={1} ", i, a[i]);
                        }

                        int choice = 0;
                        while (choice != 4)
                        {
                            Console.WriteLine("\nenter 1: number of array elements greater than C ");
                            Console.WriteLine("enter 2: product of array elements located after the maximum modulo elements");
                            Console.WriteLine("enter 3: array after transformation");
                            Console.WriteLine("enter 4: exit program");
                            Console.WriteLine("Your choice :");
                            choice = int.Parse(Console.ReadLine());
                            Console.Clear();
                            switch (choice)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("number of array elements greater than C ");
                                        SS(n, a);
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("product of array elements located after the maximum modulo elements");
                                        Console.WriteLine("result = {0}", Mutiply(n, a));
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.WriteLine("array after transformation");
                                        Output1(n, a);
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        int m, n;
                        Console.WriteLine("\t2-dimensional arrays m*n");
                        Console.WriteLine("enter m:");
                        m = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter n:");
                        n = int.Parse(Console.ReadLine());
                        int[,] a = new int[m,n];
                        for (int i = 0; i < m; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                Console.Write("a[{0},{1}]=",i,j);
                                a[i,j] = int.Parse(Console.ReadLine());
                            }
                        }
                        Console.Clear();
                        Output2(m, n, a);
                        Console.WriteLine("the number of the first of the columns containing at least one zero element is {0}", Number0(m, n, a));
                        swap(m, n, a);
                        Console.Read();
                        break;
                    }
            }

        }
    }
}
