using System;

namespace MultipleMatrix
{
    class Program
    {
       
           public static int[,] TopLeft(int[,] x)
        {
            int r = x.GetLength(0);
            int[,] A1 = new int[r / 2, r / 2];
            for (int i = 0; i < r / 2; i++)
                for (int j = 0; j < r / 2; j++)
                {
                    A1[i, j] = x[i, j];
                }
            return A1;
        }
        public static int[,] TopRight(int[,] y)
        {
            int r = y.GetLength(0);
            int[,] A2 = new int[r / 2, r / 2];
            for (int i = 0; i < r / 2; i++)
                for (int j = r / 2; j < r; j++)
                {
                    A2[i, j - r / 2] = y[i, j];
                }
            return A2;
        }
        public static int[,] DownLeft(int[,] z)
        {
            int r = z.GetLength(0);
            int[,] A3 = new int[r / 2, r / 2];
            for (int i = r / 2; i < r; i++)
                for (int j = 0; j < r / 2; j++)
                {
                    A3[i - r / 2, j] = z[i, j];
                }
            return A3;
        }
        public static int[,] DownRight(int[,] q)
        {
            int r = q.GetLength(0);
            int[,] A4 = new int[r / 2, r / 2];
            for (int i = r / 2; i < r; i++)
                for (int j = r / 2; j < r; j++)
                {
                    A4[i - r / 2, j - r / 2] = q[i, j];
                }
            return A4;
        }

        public static int[,] plusMatrix(int[,] mat1, int[,] mat2)
        {
            int n = mat1.GetLength(0);
            int[,] res = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    res[i, j] = mat1[i, j] + mat2[i, j];
                }
            }
            return res;

        }
        public static int[,] minusMatrix(int[,] mat1, int[,] mat2)
        {
            int n = mat1.GetLength(0);
            int[,] res = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    res[i, j] = mat1[i, j] - mat2[i, j];
                }
            }
            return res;

        }
        /// / / / / / / / / / / / / / / / / / / / / / / / / / 

        public static int[,] StrassenMatrix(int[,] a, int[,] b)
        {
            int n = a.GetLength(0);
            int[,] res = new int[n, n];
            if (n > 2)
            {
                int n2 = n / 2;
                        
                {
                    int[,] M1 = StrassenMatrix(plusMatrix(TopLeft(a), DownLeft(a)),
                                     plusMatrix(TopLeft(b), TopRight(b)));
                    /*
                     * for (int i = 0; i < M1.GetLength(0); i++)
                    {
                        for (int j = 0; j < M1.GetLength(1); j++)
                        {
                            Console.Write(string.Format("{0} ", M1[i, j]));
                        }
                        Console.Write(Environment.NewLine + Environment.NewLine);
                    }
                    */
                    int[,] M2 = StrassenMatrix(plusMatrix(TopRight(a), DownRight(a)),
                                    plusMatrix(DownLeft(b), DownRight(b)));
                    int[,] M3 = StrassenMatrix(minusMatrix(TopLeft(a), DownRight(a)),
                               plusMatrix(TopLeft(b), DownRight(b)));
                    int[,] M4 = StrassenMatrix(TopLeft(a),
                                minusMatrix(TopRight(b), DownRight(b)));
                    int[,] M5 = StrassenMatrix(plusMatrix(DownLeft(a), DownRight(a)),
                                TopLeft(b));
                    int[,] M6 = StrassenMatrix(plusMatrix(TopLeft(a), TopRight(a)),
                                   DownRight(b));
                    int[,] M7 = StrassenMatrix(DownRight(a),
                                minusMatrix(DownLeft(b), TopLeft(b)));

                    int[,] I = minusMatrix(plusMatrix(M2, M3), minusMatrix(M6, M7));
                    int[,] J = plusMatrix(M4, M6);
                    int[,] K = plusMatrix(M5, M7);
                    int[,] L = minusMatrix(minusMatrix(M1, M3), minusMatrix(M4, M5));

                    //Console.WriteLine("M1: {0}", M1.GetLength(0));
                    int rowLength = M1.GetLength(0);
                    int colLength = M1.GetLength(1);

                    
                    /// / / / / / / / / / // / / / / / / / / / / / / / / / / / / / / 

                    for (int i = 0; i < n2; i++)
                    {
                        for (int j = 0; j < n2; j++)
                        {
                            res[i, j] = I[i, j];
                        }
                    }
                        for (int i = 0; i < n2; i++)
                        {
                            for (int j = n2; j < n; j++)
                        {
                            res[i, j] = J[i, j-n2];
                        }

                    } //first

                    //second
                    for (int i = n2; i < n; i++)
                    {
                        for (int j = 0; j < n2; j++)
                        {
                            res[i, j] = K[i-n2, j];
                        }
                    }
                    for (int i = n2; i < n; i++)
                    {
                        for (int j = n2; j < n; j++)
                        {
                            res[i, j] = L[i-n2, j-n2];
                        }

                    }

                }

                
            }
              
            else
            {
                //res = new int[1, 1];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        res[i,j] = 0;
                        for (int t = 0; t < n; t++)
                        {
                            res[i,j] = res[i,j] + a[i,t] * b[t,j];
                        }
                    }
                }

            }
            return res;
            }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[,] a = new int[4, 4] {
                        { 1,2,3,4},
                         { 6,7,8, 9},
                         { 11,12,13, 14},
                         { 16, 17, 18, 19},
                         };

            int[,] b = new int[4, 4] {
                        { 1,2,3,4},
                         { 6,7,8, 9},
                         { 11,12,13, 14},
                         { 16, 17, 18, 19},
                         };

            int[,] c = StrassenMatrix(a, b);
            for(int i=0; i<4; i++)
            {
                for(int j=0; j<4; j++)
                {
                    Console.Write(string.Format("{0} ", c[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            }

        }
    }

