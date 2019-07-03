/**
 * https://practice.geeksforgeeks.org/problems/rotate-a-2d-array-without-using-extra-space/0
 */


using System;

namespace ArrayRotate
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"2
3
1 2 3 4 5 6 7 8 9
2
56 96 91 54";

            string input2 = @"4
3
1 2 3 4 5 6 7 8 9
2
56 96 91 54
4
1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16
1
11";

            input = input.Replace("\r","");
            input2 = input2.Replace("\r", "");
            Test[] tests = parseInput(input2);
            foreach (Test t in tests)
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("ORIGINAL");
                t.writeMatrix();
                t.Rotate90();
                Console.WriteLine("ROTATED");
                t.writeMatrix();
            }
        }

        public static Test[] parseInput(string input)
        {
            string[] inputs = input.Split('\n');
            
            int num_of_tests = Int32.Parse(inputs[0]);
            Test[] tests = new Test[num_of_tests];

            Test t = new Test(0);
            int size = 0;
            int pos1 = 0;
            int pos2 = 0;
            int testPos = 0;

            for (int i = 1; i < inputs.Length; i++)
            {
                if (i%2 == 1) //so odd
                {
                    if(size != 0)
                    {
                        tests[testPos] = t;
                        testPos++;
                    }
                    
                    size = Int32.Parse(inputs[i]);
                    pos1 = 0;
                    pos2 = 0;
                    t = new Test(size);
                }
                else //is even
                {
                    string[] matrix = inputs[i].Split(" ");
                    foreach (string s in matrix)
                    {
                        t.matrix[pos1, pos2] = Int32.Parse(s);
                        pos2++;
                        if(pos2 > size - 1 )
                        {
                            pos2 = 0;
                            pos1++;
                        }
                    }
                }
            }
            tests[testPos] = t;
            return tests;
        }
    }

    public class Test
    {
        public int[,] matrix;
        int size;

        public Test(int s)
        {
            size = s;
            matrix = new int[size, size];
        }

        public string makeString()
        {
            string outString = "";
            foreach (int i in matrix)
            {
                outString = outString + " " + i;
            }
            return outString.Substring(1);
        }

        public void writeMatrix()
        {
            Console.WriteLine(makeString());
        }

        public void Rotate90()
        {
            int pos1 = 0;
            int pos2 = size - 1;
            int moved = 0;
            int s = -1;

            for (int j = 0; j < size; j++)
            {
                for (int i = 0; i < size; i++)
                {
                    
                    if(i > s ||  i >= size - 2 || i >0)
                    {
                        pos2 = (size - 1) - i;
                        pos1 = j;
                        moved = matrix[i, j];
                        matrix[i, j] = matrix[pos1, pos2];
                        matrix[pos1, pos2] = moved;

                        Console.WriteLine("Position: " + i + ", " + j + " to " + pos1 + ", " + pos2 + " swapped " + moved + " with " + matrix[i, j]);
                    }
                }
                s++;
                pos1 = 0;
             }
        }

        public void Rotate()
        {

        }
    }
}
