using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 归并排序
/// </summary>
public class MergeSort
{

    /// <summary>
    /// 递归分治
    /// </summary>
    /// <param name="a"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    public static void SortRecusion(int[] a, int left, int right)
    {
        if (left >= right)
        {
            return;
        }
        int mid = (left + right) / 2;

        SortRecusion(a, left, mid);
        SortRecusion(a, mid + 1, right);
        Merge(a, left, mid, right);
    }

    /// <summary>
    /// 合并
    /// </summary>
    /// <param name="a"></param>
    /// <param name="left"></param>
    /// <param name="mid"></param>
    /// <param name="rigth"></param>
    public static void Merge(int[] a, int left, int mid, int rigth)
    {
        int[] temp = new int[rigth - left + 1];//中间数组

        int i = left;//左开头
        int j = mid + 1;//右开头

        int k = 0;
        while (i <= mid && j <= rigth)//把较小的数先移到新数组中
        {
            if (a[i] <= a[j])
            {
                temp[k++] = a[i++];
            }
            else
            {
                temp[k++] = a[j++];
            }
        }
        // 把左边剩余的数移入数组
        while (i <= mid)
        {
            temp[k++] = a[i++];
        }
        // 把右边边剩余的数移入数组
        while (j <= rigth)
        {
            temp[k++] = a[j++];
        }

        // 把新数组中的数覆盖nums数组
        for (int p = 0; p < temp.Length; p++)
        {
            a[left + p] = temp[p];
        }



    }


    /// <summary>
    /// 非递归
    /// </summary>
    /// <param name="a"></param>
    /// <param name="length"></param>
    public static void SortIteration(int[] a, int length)
    {
        for (int gap = 1; gap < length; gap = 2 * gap)
        {
            MergePass(a, gap, length);
        }
    }

    public static void MergePass(int[] a, int gap, int length)
    {
        int i = 0;

        //归并 gap 长度的两个相邻子表
        for (i = 0; i + 2 * gap - 1 < length; i += 2 * gap)
        {
            Merge(a, i, i + gap - 1, i + 2 * gap - 1);
        }

        //余下两个子表，后者长度小于gap
        if (i + gap - 1 < length)
        {
            Merge(a, i, i + gap - 1, length - 1);
        }
    }
}

public class _015_MergeSort : MonoBehaviour
{


    void Start()
    {
        int[] a = Utilit.RandArray(20, 10);

        int[] b = (int[])a.Clone();

        Debug.Log("---------------归并排序:递归--------------");
        MergeSort.SortRecusion(a, 0, a.Length - 1);
        Utilit.Print(a, 0);

        Debug.Log("---------------归并排序:非递归--------------");
        MergeSort.SortIteration(b, b.Length);
        Utilit.Print(b, 0);
    }


}
