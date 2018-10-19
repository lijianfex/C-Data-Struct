using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 基数排序
/// </summary>
public class RadixDSort
{

    /// <summary>
    /// 桶排序
    /// </summary>
    /// <param name="arr"></param>
    public static void Sort(int[] arr,int max)
    {
        
        int n = 1;  //代表位数对应的数：个位、十位、百位、千位..直到小于max的最大位数

        int k = 0;  //保存每一位排序后的结果用于下一位的排序输入
        int length = arr.Length;

        int[,] bucket = new int[10,length];//排序桶用于保存每次排序后的结果，这一位上排序结果相同的数字放在同一个桶里

        int[] order = new int[length];//用于保存每个桶里有多少个数字

        while (n < max)
        {
            for (int i=0;i<arr.Length;i++) //将数组array里的每个数字放在相应的桶里
            {
                int num = arr[i];
                int digit = (num / n) % 10;
                bucket[digit,order[digit]] = num;
                order[digit]++;
            }
            for (int i = 0; i < length; i++)//将前一个循环生成的桶里的数据覆盖到原数组中用于保存这一位的排序结果
            {
                if (order[i] != 0)//这个桶里有数据，从上到下遍历这个桶并将数据保存到原数组中
                {
                    for (int j = 0; j < order[i]; j++)
                    {
                        arr[k] = bucket[i,j];
                        k++;
                    }
                }
                order[i] = 0;//将桶里计数器置0，用于下一次位排序
            }
            Utilit.Print(arr, n);

            n *= 10;//扩大位数，如从个位扩大到十位
            k = 0;//将k置0，用于下一轮保存位排序结果
        }
        


    }




    /// <summary>
    /// 得到数组中位数最大的值
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    //public static int GetMaxBit(int[] arr)
    //{
    //    int maxBit = 0;
    //    for (int i = 0; i < arr.Length; i++)
    //    {
    //        int length = arr[i].ToString().Length;
    //        if (length > maxBit)
    //        {
    //            maxBit = length;
    //        }
    //    }
    //    return maxBit;
    //}
    ///// <summary>
    ///// 创建桶子
    ///// </summary>
    ///// <param name="nums"></param>
    ///// <returns></returns>
    //public static List<List<int>> CreatBuckets(int nums)
    //{
    //    List<List<int>> buckets = new List<List<int>>();
    //    for (int i = 0; i < nums; i++)
    //    {
    //        buckets.Add(new List<int>());
    //    }
    //    return buckets;
    //}

    ///// <summary>
    ///// 按某位上的数字依次向桶里放
    ///// </summary>
    ///// <param name="arr"></param>
    ///// <param name="bit"></param>
    ///// <returns></returns>
    //public static List<List<int>> Distributes(int[] arr, int bit, List<List<int>> buckets)
    //{
    //    for (int i = 0; i < arr.Length; i++)//依次向桶里放东西
    //    {
    //        buckets[GetNumAtBit(arr[i], bit)].Add(arr[i]);
    //    }
    //    return buckets;
    //}

    ///// <summary>
    ///// 某位上的值
    ///// </summary>
    ///// <param name="x"></param>
    ///// <param name="bit"></param>
    ///// <returns></returns>
    //public static int GetNumAtBit(int x, int bit)
    //{
    //    string strx = x.ToString();
    //    if (bit > strx.Length)
    //    {
    //        return 0;
    //    }
    //    else
    //    {
    //        return Convert.ToInt32(strx[strx.Length - bit].ToString());
    //    }
    //}

    ///// <summary>
    ///// 从0号桶到9号桶依次收集数字到数组中
    ///// </summary>
    ///// <param name="arr"></param>
    ///// <param name="bucket"></param>
    //public static void Collecte(int[] arr, List<List<int>> buckets)
    //{
    //    int k = 0;
    //    for (int i = 0; i < buckets.Count; i++)
    //    {
    //        for (int j = 0; j < buckets[i].Count; j++)
    //        {
    //            arr[k] = buckets[i][j];
    //            k++;                
    //        }
    //    }

    //}

}

public class _016_RadixSort : MonoBehaviour
{


    void Start()
    {
        int[] a = Utilit.RandArray(10000, 10);

        Debug.Log("---------------基数排序:桶排序--------------");
        RadixDSort.Sort(a,10000);
        
    }
}
