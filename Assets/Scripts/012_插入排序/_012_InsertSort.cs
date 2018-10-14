using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自定义工具类
/// </summary>
public static class Utilit
{
    /// <summary>
    /// 辅助输出排序结果：
    /// </summary>
    /// <param name="a"></param>
    /// <param name="t"></param>
    public static void Print(int[] a, int t)
    {
        string str = null;
        for (int i = 0; i < a.Length; i++)
        {
            str += a[i].ToString() + " ";
        }
        Debug.Log("第" + t + "趟排序结果：" + str);
    }

    /// <summary>
    /// 辅助生成排序结果
    /// </summary>
    /// <param name="max"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static int[] RandArray(int max, int length)
    {
        string str = null;
        int[] a = new int[length];
        for (int i = 0; i < a.Length; ++i)
        {
            a[i] = Random.Range(0, max);
            str += a[i].ToString() + " ";
        }
        Debug.Log("随机生成的数组：" + str);
        return a;
    }
}

/// <summary>
/// 插入排序类
/// </summary>
public class InsertSort
{
    /// <summary>
    ///1、 直接插入排序法：
    /// </summary>
    /// <param name="a"></param>
    public static void StraightInsetSort(int[] a)
    {
        int insertNum;//要插入的数
        int len = a.Length;//数组长度

        for (int i = 1; i < len; i++) //从第2个数，进行插入排序
        {
            insertNum = a[i];

            int j = i - 1; //前一个数的索性值

            while (j >= 0 && insertNum < a[j])
            {
                a[j + 1] = a[j]; //把大的向后移动
                j--;
            }

            a[j + 1] = insertNum;//找到位置，插入当前元素

            Utilit.Print(a, i);//输出每趟的排序的结果
        }

    }


    /// <summary>
    /// 2、折半插入排序
    /// </summary>
    /// <param name="a"></param>
    public static void BInsertSort(int[] a)
    {
        int insertNum;//要插入的数
        int len = a.Length;//数组长度

        for (int i = 1; i < len; i++)
        {
            insertNum = a[i];
            int low = 0;
            int high = i - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (insertNum < a[mid])
                {
                    high = mid - 1;//插入点在低半区
                }
                else
                {
                    low = mid + 1;//插入点在高半区
                }
            }

            for (int j = i - 1; j >= low; j--)
            {
                a[j + 1] = a[j];//后移元素
            }
            a[low] = insertNum;

            Utilit.Print(a, i);
        }
    }

    /// <summary>
    /// 3、希尔排序
    /// </summary>
    /// <param name="a"></param>    
    public  static void ShellSort(int[] a)
    {
        int len = a.Length;
        while (len != 0)
        {
            len = len / 2;
            for (int i = 0; i < len; i++)//分组
            {
                for (int j = i + len; j < a.Length; j += len)
                {
                    int k = j - len;//k为有序序列最后一个的位置
                    int temp = a[j];
                    while (k >= 0 && temp < a[k])
                    {
                        a[k + len] = a[k];
                        k -= len;
                    }
                    a[k + len] = temp;
                }

                Utilit.Print(a, i); //打印
            }
        }

    }

}

public class _012_InsertSort : MonoBehaviour
{


    void Start()
    {
        int[] a = Utilit.RandArray(20, 10);

        Debug.Log("------------直接插入排序----------------");
        InsertSort.StraightInsetSort(a); //直接插入排序

        Debug.Log("------------折半插入排序----------------");
        InsertSort.BInsertSort(a); //折半插入排序

        Debug.Log("------------希尔排序----------------");
        InsertSort.ShellSort(a);//希尔排序


    }

}
