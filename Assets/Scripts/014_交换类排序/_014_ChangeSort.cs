using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 交类排序
/// </summary>
public class ChangeSort
{
    #region 3 种 冒泡排序
    /// <summary>
    /// 冒泡排序 版本1：(没有考虑如果已经有序了的情况)
    /// </summary>
    public static void BubbleSort_1(int[] a)
    {
        int len = a.Length;
        int temp = 0;
        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < len - 1 - i; j++)
            {
                if (a[j] > a[j + 1])
                {
                    temp = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = temp;
                }
                Debug.Log("版本1：内部循环次数");
            }
            Debug.Log("版本1：外部循环次数");
            //Utilit.Print(a, i);
        }
        Utilit.Print(a, 0);
    }

    /// <summary>
    /// 冒泡排序 版本2：（避免有序后依然进行排序，减少了外循环次数,但没有考虑后方已经有序的情况，例如：[4,3,2,1,0,5,6,7,8,9]）
    /// </summary>
    /// <param name="a"></param>
    public static void BubbleSort_2(int[] a)
    {
        int len = a.Length;
        int temp = 0;

        bool exchang = false; //标志位：是否有逆序相邻数

        for (int i = 0; i < len; i++)
        {
            exchang = false;
            for (int j = 0; j < len - 1 - i; j++)
            {
                if (a[j] > a[j + 1])
                {
                    temp = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = temp;
                    exchang = true;
                }
                Debug.Log("版本2：内部循环次数");
            }
            if (!exchang)
            {
                break;
            }
            Debug.Log("版本2：外部循环次数");
            //Utilit.Print(a, i);
        }
        Utilit.Print(a, 0);
    }

    /// <summary>
    /// 冒泡排序 版本3：（考虑后方已经有序的情况，例如：[4,3,2,1,0,5,6,7,8,9]，减少了内部的循环次数）
    /// </summary>
    /// <param name="a"></param>
    public static void BubbleSort_3(int[] a)
    {
        int len = a.Length;
        int temp = 0;

        int lastExchangIndex = 0;//记录最后发生交换的索引

        int sortBorder = len - 1; //无序数的边界索引

        bool exchang = false; //标志位：是否有逆序相邻数
        for (int i = 0; i < len; i++)
        {
            exchang = false;
            for (int j = 0; j < sortBorder; j++)
            {
                if (a[j] > a[j + 1])
                {
                    temp = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = temp;
                    exchang = true;
                    lastExchangIndex = j;
                }
                Debug.Log("版本3：内部循环次数");
            }
            sortBorder = lastExchangIndex;
            if (!exchang)
            {
                break;
            }
            Debug.Log("版本3：外部循环次数");
            //Utilit.Print(a, i);
        }
        Utilit.Print(a, 0);
    }
    #endregion

    #region  2 种 快速排序：递归与非递归

    /// <summary>
    /// 快排：（递归）挖坑法
    /// </summary>
    /// <param name="a"></param>
    /// <param name="startIndex"></param>
    /// <param name="endIndex"></param>
    public static void QuickSort_1(int[] a, int startIndex, int endIndex)
    {
        if (startIndex >= endIndex)
        {
            return;
        }

        int pivotIndex = GetPivotIndex(a, startIndex, endIndex);
        QuickSort_1(a, startIndex, pivotIndex - 1);
        QuickSort_1(a, pivotIndex + 1, endIndex);
    }

    /// <summary>
    /// 获得基准的位置:填坑法
    /// </summary>
    /// <param name="a"></param>
    /// <param name="startIndex"></param>
    /// <param name="endIndex"></param>
    /// <returns></returns>
    public static int GetPivotIndex(int[] a, int startIndex, int endIndex)
    {
        int pivot = a[startIndex]; //取第一个元素为基准数
        int left = startIndex;
        int right = endIndex;


        int index = startIndex;//挖坑法：坑的位置

        while (left <= right)
        {
            //right 指针从右向左进行比较
            while (left <= right)
            {
                if (a[right] < pivot)
                {
                    a[left] = a[right];
                    index = right;
                    left++;
                    break;
                }
                right--;
            }

            //left 指针从左向右进行比较
            while (left <= right)
            {
                if (a[left] > pivot)
                {
                    a[right] = a[left];
                    index = left;
                    right--;
                    break;
                }
                left++;
            }
        }

        a[index] = pivot;
        return index;

    }



    /// <summary>
    /// 快速排序：（非递归）用栈消除递归
    /// </summary>
    /// <param name="a"></param>
    /// <param name="startIndex"></param>
    /// <param name="endIndex"></param>
    public static void QuickSort_2(int[] a, int startIndex, int endIndex)
    {
        if (startIndex >= endIndex)
        {
            return;
        }

        Stack<Dictionary<string, int>> quickSortStack = new Stack<Dictionary<string, int>>();

        Dictionary<string, int> rootParam = new Dictionary<string, int>();
        rootParam.Add("startIndex", startIndex);
        rootParam.Add("endIndex", endIndex);
        quickSortStack.Push(rootParam);

        while (quickSortStack.Count != 0)
        {
            Dictionary<string, int> param = quickSortStack.Pop();

            int pivotIndex = GetPivotIndex_2(a, param["startIndex"], param["endIndex"]);


            if (param["startIndex"] < pivotIndex - 1)
            {
                Dictionary<string, int> leftParam = new Dictionary<string, int>();
                leftParam.Add("startIndex", param["startIndex"]);
                leftParam.Add("endIndex", pivotIndex - 1);
                quickSortStack.Push(leftParam);

            }
            if (pivotIndex + 1 < param["endIndex"])
            {
                Dictionary<string, int> rightParam = new Dictionary<string, int>();
                rightParam.Add("startIndex", pivotIndex + 1);
                rightParam.Add("endIndex", param["endIndex"]);
                quickSortStack.Push(rightParam);
            }
        }

    }

    /// <summary>
    /// 获得基准的位置:指针法
    /// </summary>
    /// <param name="a"></param>
    /// <param name="startIndex"></param>
    /// <param name="endIndex"></param>
    /// <returns></returns>
    public static int GetPivotIndex_2(int[] a, int startIndex, int endIndex)
    {
        int pivot = a[startIndex]; //取第一个元素为基准数
        int left = startIndex;
        int right = endIndex;


        while (left < right)
        {
            while (left < right && a[right] >= pivot)
            {
                right--;
            }
            if (left < right)
            {
                a[left] = a[right];
                left++;
            }

            while (left < right && a[left] < pivot)
            {
                left++;
            }
            if (left < right)
            {
                a[right] = a[left];
                right--;
            }
        }

        a[left] = pivot;
        return left;
    }

    #endregion
}


public class _014_ChangeSort : MonoBehaviour
{


    void Start()
    {
        int[] a = Utilit.RandArray(20, 10);//new int[] { 4,3,2,1,0,5,6,7,8,9};

        int[] b = (int[])a.Clone();

        //int[] c = (int[])a.Clone();

        //Debug.Log("---------------冒泡排序 版本1--------------");
        //ChangeSort.BubbleSort_1(a);


        //Debug.Log("---------------冒泡排序 版本2--------------");
        //ChangeSort.BubbleSort_2(b);

        //Debug.Log("---------------冒泡排序 版本3--------------");
        //ChangeSort.BubbleSort_3(c);

        Debug.Log("---------------快速排序:挖坑法--------------");
        ChangeSort.QuickSort_1(a, 0, a.Length - 1);
        Utilit.Print(a, 0);


        Debug.Log("---------------快速排序:非递归--------------");
        ChangeSort.QuickSort_2(b, 0, a.Length - 1);
        Utilit.Print(b, 0);
    }


}
