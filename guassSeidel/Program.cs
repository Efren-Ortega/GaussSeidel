using System;
using System.Collections.Generic;

namespace guassSeidel
{
    class Program
    {
        static void Main(string[] args)
        {

            const int MATRIX_ROWS = 3;
            const int MATRIX_COLUMNS = 4;
            string variable = "", sign="";

            double[,] matrix = new double[MATRIX_ROWS, MATRIX_COLUMNS];
            double[,] newMatrix = new double[MATRIX_ROWS, MATRIX_COLUMNS];

            List<double> Numbers = new List<double>();
            List<double> NumbersDesc = new List<double>();
            List<int> Rows = new List<int>();
            List<int> RowsOrder = new List<int>();

            for (int i = 0; i < MATRIX_ROWS; i++)
            {
                for (int j = 0; j < MATRIX_COLUMNS; j++)
                {
                    Console.Write("Enter value for ({0},{1}): ", i, j);
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < MATRIX_ROWS; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < MATRIX_COLUMNS; j++)
                {
                    if (j == 0)
                    {
                        variable = "x";
                        sign = "";
                    }
                    else if (j == 1)
                    {
                        variable = "y";
                        sign = "";
                        if (matrix[i, j] > 0)
                        {
                            sign += "+";
                        }
                        
                    }
                    else if (j==2)
                    {
                        variable = "z";
                        sign = "";
                        if (matrix[i, j] > 0)
                        {
                            sign += "+";
                        }
                    }
                    else
                    {
                        variable = "";
                        sign = "=";
                    }

                    Console.Write(sign + matrix[i, j] + variable);
                }
                Console.Write("\n");
            }



            for (int i = 0; i < MATRIX_ROWS; i++)
            {
                for (int j = 0; j < MATRIX_COLUMNS; j++)
                {

                    if ((matrix[i, j] > matrix[i, j + 1]) && (matrix[i, j] > matrix[i, j + 2]))
                    {
                        Console.WriteLine("The largest number in the row: " + i + " is: " + matrix[i, j]);
                        Numbers.Add(matrix[i, j]);
                        Rows.Add(i);
                        break;
                    }
                    else if ((matrix[i, j + 1] > matrix[i, j]) && (matrix[i, j + 1] > matrix[i, j + 2]))
                    {
                        Console.WriteLine("The largest number in the row: " + i + " is: " + matrix[i, j+1]);
                        Numbers.Add(matrix[i, j+1]);
                        Rows.Add(i);
                        break;
                    }
                    else if ((matrix[i, j + 2] > matrix[i, j]) && (matrix[i, j + 2] > matrix[i, j + 1]))
                    {
                        Console.WriteLine("The largest number in the row: " + i + " is: " + matrix[i, j+2]);
                        Numbers.Add(matrix[i, j+2]);
                        Rows.Add(i);
                        break;
                    }

                }
            }

            for (int i = 0; i < Rows.Count; i++)
            {
                Console.WriteLine(Rows[i]);
            }                        

            //This method is to order the numbers found 'em before
            OrderValues(Numbers, NumbersDesc, Rows, RowsOrder);
            MakeNewMatrix(RowsOrder, newMatrix, matrix, MATRIX_ROWS, MATRIX_COLUMNS);

            for (int i = 0; i < MATRIX_ROWS; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < MATRIX_COLUMNS; j++)
                {
                    if (j == 0)
                    {
                        variable = "x";
                        sign = "";
                    }
                    else if (j == 1)
                    {
                        variable = "y";
                        sign = "";
                        if (newMatrix[i, j] > 0)
                        {
                            sign += "+";
                        }

                    }
                    else if (j == 2)
                    {
                        variable = "z";
                        sign = "";
                        if (newMatrix[i, j] > 0)
                        {
                            sign += "+";
                        }
                    }
                    else
                    {
                        variable = "";
                        sign = "=";
                    }

                    Console.Write(sign + newMatrix[i, j] + variable);
                }
                Console.Write("\n");
            }


            Console.Write("\n");
            Console.WriteLine("Ingresa otro numero: ");
            int x = Convert.ToInt32(Console.ReadLine());


        }

        //This method is to order the numbers found 'em before
        static double OrderValues(List<double> Numbers, List<double> NumbersDesc, List<int> Rows, List<int> RowsOrder)
        {

            for(int i=0; i>=0; i++)
            {

                int band = 0;

                if (Numbers.Count == 1)
                {
                    NumbersDesc.Add(Numbers[0]);
                    RowsOrder.Add(Rows[0]);
                    break;
                }

                double value = Numbers[i];

                for (int j=0; j<Numbers.Count; j++) {
                                         
                    if (value >= Numbers[j])
                    {
                        band++;
                    }

                    if (band == Numbers.Count)
                    {
                        NumbersDesc.Add(value);                        
                        int index = Numbers.IndexOf(value);
                        RowsOrder.Add(Rows[index]);
                        Rows.Remove(Rows[index]);
                        Numbers.Remove(value);                        

                        i = -1;
                        break;
                    }
                }
            }

            for (int i = 0; i<NumbersDesc.Count; i++)
            {
                Console.WriteLine("The order of the numbers are: Row ->"+ RowsOrder[i]+" "+ NumbersDesc[i]);
            }

            
            return 0;
        }


        //This method will make other array but with a new order
        static double MakeNewMatrix(List<int> RowsOrder, double[,] newMatrix, double[,] matrix, int MATRIX_ROWS, int MATRIX_COLUMNS) {

            for (int i = 0; i < MATRIX_ROWS; i++)
            {
                for (int j = 0; j < MATRIX_COLUMNS; j++)
                {
                    newMatrix[i, j] = matrix[RowsOrder[i], j];
                }
            }

            return 0;
        }

    }
}

