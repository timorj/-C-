using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointerTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintValueAndAddress();

            UsePointerToPoint();

            Point p = new Point();
            p.x = 5;
            p.y = 6;
            unsafe
            {
                int* x = &p.x;
                Console.WriteLine("Point is:{0}", *x);
            }
            Solution solution = new Solution();
            double s = solution.FindMedianSortedArrays(new int[] { 1,2}, new int[] { 3,4});
        }
        public class Solution
        {
            public double FindMedianSortedArrays(int[] nums1, int[] nums2)
            {
                int[] totalArray = new int[nums1.Length + nums2.Length];
                int i = 0;
                foreach (var l in nums1)
                {
                    totalArray[i] = nums1[i];
                    i++;
                }
                foreach (var n in nums2)
                {
                    totalArray[i] = nums2[i - nums1.Length];
                    i++;
                }
                Array.Sort<int>(totalArray);
                if ((nums1.Length + nums2.Length) % 2 == 0)
                {
                    return ((double)totalArray[totalArray.Length / 2] + (double)totalArray[totalArray.Length / 2 + 1]) / 2;
                }
                else
                {
                    return (double)totalArray[(totalArray.Length - 1) / 2];
                }

            }
        }
        unsafe static void PrintValueAndAddress()
        {
            int myInt;

            int* ptrToMyInt = &myInt;

            *ptrToMyInt = 123;

            Console.WriteLine("Value of myInt {0}",myInt);
            Console.WriteLine("Address of myInt {0:x}", (int)ptrToMyInt);
        }

        unsafe public static void UnsafeSwap(int* i, int* j) 
        {
            int temp = *i;
            *i = *j;
            *j = temp;
        }
        unsafe static void UsePointerToPoint() 
        {
            Point point;
            Point* p = &point;
            p->x = 100;
            p->y = 200;
            Console.WriteLine(p->ToString());

            Point point2;
            Point* p2 = &point2;
            (*p2).x = 200;
            (*p2).y = 300;
            Console.WriteLine((*p2).ToString());
            
        }
    }
    struct Point 
    {
        public int x;
        public int y;
        
        public override string ToString()
        {
            string s;
            Dictionary<int, string> m;
            
            return string.Format("[{0}, {1}]", x, y);
        }
    }
}
