using System;
/// <summary>
///    מגיש מרדכי שוקרון
/// </summary>

namespace AbstractCollections
{
    class Recursion
    {
        public static void PrintAscendingOrder(int n)// עולה  1 2 3
        {
            if (n == 1)
            {
                Console.WriteLine(1);
            }
            else
            {
                PrintAscendingOrder(n - 1);
                Console.WriteLine(n);
            }

        }
        
        public static void PrintDescendingOrder(int n)// יורד
        {
            if (n < 1)
                return;
            Console.WriteLine(n);
            PrintDescendingOrder(n - 1);
        }
        public static int NumOfDigits(int n)
        {
            if (n < 10)
                return 1;
            return NumOfDigits(n / 10)+1;
        }
        public static int SumOfDigits(int n)
        {
            if (n < 10)
                return n;
            return SumOfDigits (n/10) + n % 10;
        }
        public static bool AreAllDigitsEven(int n)//344 האם כל הספרות זוגיות
       {
           
            if ((n % 10) % 2 == 1)
                return false;
            if (n < 10)
            {
                return true;
            }

            return AreAllDigitsEven(n / 10);
       }
        public static int BiggestDigits(int n)// 371
        {
            int n1 = n % 10; //1  7  3
            int n2 = n / 10;//37  3  0

            if (n2 == 0)
            { 
                return n1;// 3
            }
            int n3 = BiggestDigits(n2); // 37 3 
            return n1 > n3 ? n1 : n3; // 7
            


        }
        public static bool IsDivisor(int n, int divisor) // 8 2 האם הוא מחלק ללא שארית
    {
            if (divisor == 0)
            {
                return false;
            }
            if (n == 0)
            {
                return true;
            }
            if (n < divisor)
            {
                return false;
            }

            return IsDivisor(n - divisor, divisor);
    }
        public static int Gcd(int x,int y) //  8  3 המחלק הגבוהה ביותר 
    {
            if (y == 0 || x==0)
            {
                return 0;
            }
            if (x == y)
            {
                return x;
            }
            if (y > x)
            {
                return y / 2;
            }
            return Gcd(x, y + y);
  }
        public static int FibonacciRec(int num)
        {
            //0 1 1 2 3 5 8

            if (num <= 1)
            {
                return num;

            }
          Console.WriteLine($"num - 1  {num - 1} num - 2  {num - 2}");
            return FibonacciRec(num - 1) + FibonacciRec(num - 2);
        }

        public static int Fibonacci(int num)
        {
            

            
            int temp1 = 1;
            int temp2 = 0;
            int sum = 0;
            while (num > 0)
            {
                temp2 = temp1;
                temp1 = sum;
                sum = temp1 + temp2;  
                --num;                  
            }
            return sum ;
        }
    }
}
