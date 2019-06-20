using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorting
{
    public partial class Form2 : Form
    {
        List<string> numList;

        int[] numArray;

        string unrangedNum;

        List<string> sorted;

        int myid;
        public Form2(int id)
        {
            InitializeComponent();
            myid = id;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // الارقام غير المرتبة
            unrangedNum = txtUnrangednum.Text;

            try
            {
                if (myid == 0)
                {
                    //استخلاص الارقام من التكست بوكس وتخزينها فى ليست
                    numList = unrangedNum.Split('-').OfType<string>().ToList<string>();
                    sorted = MergeSort(numList);
                    lblResult.Text = "";
                    foreach (var item in sorted)
                    {
                        lblResult.Text += item + " ";
                    }
                }
                else if (myid == 1)
                {
                    numArray = InsertionSort(Array.ConvertAll(unrangedNum.Split('-'), int.Parse));
                    lblResult.Text = "";
                    foreach (var item in numArray)
                    {
                        lblResult.Text += item + " ";
                    }
                }
                else
                {
                    
                    numArray = Array.ConvertAll(unrangedNum.Split('-'), int.Parse);
                    quickSort(numArray, 0, numArray.Length - 1);
                    lblResult.Text = "";
                    foreach (var item in numArray)
                    {
                        lblResult.Text += item + " ";
                    }
                   

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("make sure that each number separated by (-)", "Warniing");
            }
        }
        // merge sort ....
        private static List<string> Merge(List<string> left, List<string> right)
        {
            List<string> result = new List<string>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (int.Parse(left.First()) <= int.Parse(right.First()))  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }

        private static List<string> MergeSort(List<string> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<string> left = new List<string>();
            List<string> right = new List<string>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        // insertion sort
        private int[] InsertionSort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (inputArray[j - 1] > inputArray[j])
                    {
                        int temp = inputArray[j - 1];
                        inputArray[j - 1] = inputArray[j];
                        inputArray[j] = temp;
                    }
                }
            }
            return inputArray;
        }

        //quick sort ..
        static public int Partition(int[] arr, int left, int right)
        {
            int pivot;
            pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }
                while (arr[right] > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        static public void quickSort(int[] arr, int left, int right)
        {
            int pivot;
            if (left < right)
            {
                pivot = Partition(arr, left, right);
                if (pivot > 1)
                {
                    quickSort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    quickSort(arr, pivot + 1, right);
                }
            }
        }
    }
}
