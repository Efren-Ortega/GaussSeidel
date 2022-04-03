using System;
using System.Collections.Generic;

namespace guassSeidel
{
    class Program
    {
        static void Main(string[] args)
        {

            //Variables Declaration
            const int MATRIX_ROWS = 3;
            const int MATRIX_COLUMNS = 4;
            string variable = "", sign="";
            int x=0, y=0, z=0;

            //Matrix Declaration
            double[,] matrix = new double[MATRIX_ROWS, MATRIX_COLUMNS];
            double[,] newMatrix = new double[MATRIX_ROWS, MATRIX_COLUMNS];

            //List Declaration
            List<double> Numbers = new List<double>();
            List<double> NumbersDesc = new List<double>();

            List<int> Rows = new List<int>();
            List<int> RowsOrder = new List<int>();

            //Request the user the values to fill the matrix
            for (int i = 0; i < MATRIX_ROWS; i++)
            {
                for (int j = 0; j < MATRIX_COLUMNS; j++)
                {
                    Console.Write("Enter value for ({0},{1}): ", i, j);
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            }

            //Method to display the first matrix in console
            displayMatrix(matrix, MATRIX_ROWS, MATRIX_COLUMNS, Numbers, Rows, variable = "", sign = "");

            //Method to get the largest value of each Matrix Rows
            getLargestValue(matrix, MATRIX_ROWS, MATRIX_COLUMNS, Numbers, Rows);

            //Method to order the rows stored before
            OrderValues(Numbers, NumbersDesc, Rows, RowsOrder);

            //Method to make the new matrix
            MakeNewMatrix(RowsOrder, newMatrix, matrix, MATRIX_ROWS, MATRIX_COLUMNS);

            //To display the new Matrix
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
            int num = Convert.ToInt32(Console.ReadLine());


        }

        //METHODS

        //This is to display the first matrix in console
        static double displayMatrix(double[,] matrix, int MATRIX_ROWS, int MATRIX_COLUMNS, List<double> Numbers, List<int> Rows, string variable = "", string sign= ""){

            for (int i = 0; i < MATRIX_ROWS; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < MATRIX_COLUMNS; j++)
                {
                    //"Ifs" to give format each value when displaying the matrix
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
                    else if (j == 2)
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

                    //Displaying the matrix
                    Console.Write(sign + matrix[i, j] + variable);
                }
                Console.Write("\n");
            }

            return 0;
        }

        //This is to get the largest value of each Matrix Rowss
        static double getLargestValue(double[,] matrix, int MATRIX_ROWS, int MATRIX_COLUMNS, List<double> Numbers, List<int> Rows) {

            for (int i = 0; i < MATRIX_ROWS; i++)
            {
                for (int j = 0; j < MATRIX_COLUMNS; j++)
                {

                    if ((matrix[i, j] > matrix[i, j + 1]) && (matrix[i, j] > matrix[i, j + 2]))
                    {
                        Numbers.Add(matrix[i, j]);//I store the value in a list
                        Rows.Add(i);//I store the Row number of the found largest value.
                        break;
                    }
                    else if ((matrix[i, j + 1] > matrix[i, j]) && (matrix[i, j + 1] > matrix[i, j + 2]))
                    {
                        Numbers.Add(matrix[i, j + 1]);
                        Rows.Add(i);
                        break;
                    }
                    else if ((matrix[i, j + 2] > matrix[i, j]) && (matrix[i, j + 2] > matrix[i, j + 1]))
                    {
                        Numbers.Add(matrix[i, j + 2]);
                        Rows.Add(i);
                        break;
                    }

                }
            }
            return 0;
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
                        int index = Numbers.IndexOf(value);
                        RowsOrder.Add(Rows[index]);
                        Rows.Remove(Rows[index]);
                        NumbersDesc.Add(value);
                        Numbers.Remove(value);                        

                        i = -1;
                        break;
                    }
                }
            }

            /*for (int i = 0; i< RowsOrder.Count; i++)
            {
                Console.WriteLine("The new order of the row numbers found are: Row ->"+ RowsOrder[i]);
            }*/

            for (int i = 0; i < NumbersDesc.Count; i++)
            {
                Console.WriteLine("The new order of the row numbers found are: Row ->" + NumbersDesc[i]);
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

        static double ClearVariable(double[,] newMatrix, int MATRIX_ROWS, int MATRIX_COLUMNS, string sign, string variable, List<double> NumbersDesc) {

            string ClearVar = "";
            int j = 0;
            int band = 0, i=0;
            for (i = 0; i<MATRIX_ROWS; i++) {//3 -> END
                               
                //j -> 3
                if (i == 0 && j==0) {sign = "X = ";}//
                if (i == 1 && j==0) {sign = "Y = ";}//
                if (i == 2 && j==0) {sign = "Z = ";}//"Z ="

                if (j == 0) {variable = "x";}//
                if (j == 1) { variable = "y"; }//
                if (j == 2) { variable = "z"; }//
                if (j > 2) { variable = ""; }//""


                if ((j == 1 || j == 2) && j!=i)//2  &&  2!=2
                {
                                        
                    //[2, 1] = 4
                 
                    if (band > 0)
                    {
                        //-4
                        if ((newMatrix[i, j]*-1) > 0)
                        {
                            sign = "+";
                        }

                        //Z = -3x-4y
                        ClearVar += (sign + (newMatrix[i, j] * -1) + variable);
                        band++;//2
                    }
                    else
                    {      
                        //
                        ClearVar += (sign + (newMatrix[i, j] * -1) + variable);
                        band++;//
                    }
                    
                }
                else if(j!=i)//3 != 2
                {
                    if(band > 0)
                    {
                        //[2, 3] = 6       
                        if (newMatrix[i, j] > 0)
                        {
                            sign = "+";
                        }

                        //Z = -3x-4y+6
                        ClearVar += (sign + newMatrix[i, j] + variable);
                        band++;//3
                    }
                    else
                    {

                        //[2, 0] = 3
                        //Z = -3x
                        ClearVar += (sign + (newMatrix[i, j]*-1) + variable);
                        band++;//1
                    }

                }               

                j++; //4

                if (band == 3)
                {
                    //Z = -3x-4y+6
                    ClearVar += " / " + newMatrix[i, i]; //Z = -3x-4y+6 / -10

                    Console.WriteLine(ClearVar); //X = -2y + 1z - 2 / 9
                                                 //Y = -7x - 5z + 3 / 8
                                                 //Z = -3x - 4y + 6 / -10

                    j = 0;
                    sign = "";
                    variable = "";
                    continue;
                }
                else
                {
                    if (i == 0) { i = 0; }//
                    if (i == 1) { i = 1; }//
                    if (i == 2) { i = 2; }//2
                    sign = "";
                }
            }   

            return 0;
        }
    }
}

