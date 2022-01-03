using System;
using System.Collections;
using System.Collections.Generic;

namespace AbstractCollections
{
    class Program
    {
      
        static void Main(string[] args)
        {

            

            ADTStack<int> newStart = new ADTStack<int>(5);
            newStart.Push(1);
            newStart.Push(2);
            newStart.Push(3);
          
            
            ReverseStack(newStart);
            newStart.Print();
        }
        public static bool AreBalancedParathesis(char[] exp)
        {
            
          
            ADTStack<char> open =new ADTStack<char>(1);

            for (int i = 0; i < exp.Length; i++)
            {
                switch (exp[i])
                {
                    case '{':
                        open.Push('{');
                        break;
                    case '[':
                        open.Push('[');

                        break;
                    case '(':
                        open.Push('(');

                        break;
                    
                
                    case '}':
                        if (open.Pop() != '{')
                            return false;
                        break;
                    case ']':
                        if (open.Pop() != '[')
                            return false;
                        break;
                    case ')':
                        if (open.Pop() != '(')
                            return false;
                        break;
                   
                }

            }
          

            return true;
        }
        public static void ReverseStack(ADTStack<int> myStack)
        {
            if (myStack.IsEmpty())
            {
                return;
            }
            int temp = myStack.Pop();
            ReverseStack(myStack);

            InsertAtBottom(myStack, temp);
        }
        public static void InsertAtBottom(ADTStack<int> myStack,int item)
        {
            if (myStack.IsEmpty())
            {
                myStack.Push(item);

                return;
            }
            int newItem = myStack.Pop();
            InsertAtBottom(myStack, item);
            myStack.Push(newItem);


        }
        public static int
            GetNumOfItems(ADTStack<int> myItem)
        {
            ADTStack<int> newStack = new ADTStack<int>(1);
            int len = 0;
            while (!myItem.IsEmpty())
            {
                len++;
                newStack.Push(myItem.Pop());
            }
            return len;
        }
        public static bool IsPalindrome(string str)
        {
            ADTStack<char> newStart = new ADTStack<char>(1);
            ADTStack<char> newEnd = new ADTStack<char>(1);
            
            int len = str.Length;// a b c d
            for (int i = 0; i < str.Length; i++)
            {
                newStart.Push(str[i]); // a b c d
                newEnd.Push(str[len-1-i]);// d c b a

            }

            for (int i = 0; i < (str.Length) / 2; i++)
            {
                if (newEnd.Pop() != newStart.Pop())
                {
                    return false;
                }
            }
            return true;

        }

        public static int BinarySearchIteratie(int [] data, int item)
        {
            int start = 0;
            int end = data.Length - 1;
            int middle;
            while( start <= end)
            {
                middle = (start + end) / 2;

                if (data[middle] == item)
                {
                    return middle;
                }

                if (data[middle] > item)
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1;
                }
            }
        
            return -1;
        }
        public static int BinarySearchRecursive(int[] data, int item, int min , int max)
        {
           int  middle = (min + max) / 2;

            if (min > max)
            {
                return -1;
            }

            if (data[middle] > item)
            {
                return BinarySearchRecursive(data, item, min, middle - 1);
            }
            if (data[middle] < item)
            {
                return BinarySearchRecursive(data, item, middle + 1, max);
            }


            return middle;

        }
        public static bool PrimeNum(int num)
        {
            for (int i = 2; i < Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
        public static int LinearSearch(int [] arr, int num)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == num)
                    return i;
                
            }
            return -1;
        }
        public static void BubbleSort(int[] arr)
        {
            int len = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                    else if(arr[j] < arr[j + 1])
                    {
                        len++;
                    }
                }
                if(len== arr.Length - i)
                {
                    Console.WriteLine("is sort");
                    return;
                }
            }
          
        }
        public static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length ; i++)
            {
                for (int j = 0; j < i ; j++)
                {
                    if (arr[j] > arr[i])
                    {
                        int temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;

                    }
                   
                }
            }
        }
        public static void PrintArray(int [] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}