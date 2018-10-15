using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/// <summary>
/// 选择类排序
/// </summary>
public class SelectSort
{
    /// <summary>
    ///1、 简单选择排序
    /// </summary>
    /// <param name="a"></param>
    public static void SampleSelectSort(int[] a)
    {
        int len = a.Length;//获得数组长度
        
        for(int i=0;i<len-1;i++)
        {

            int minIndex = i;
            int minValue = a[i];
            for (int j = i + 1; j < len; j++) //找后方最小值的位置与值
            {
                if (a[j] < minValue) //(改为 > 则为降序)
                {
                    minValue = a[j];
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                int temp = a[i];
                a[i] = a[minIndex];
                a[minIndex] = temp;
            }
            
            Utilit.Print(a, i);
        }
    }


    /// <summary>
    /// 错误的简单选择排序
    /// </summary>
    /// <param name="a"></param>
    public static void ErrorSampleSelectSort(int[] a)
    {
        int len = a.Length;//获得数组长度

        for (int i = 0; i < len - 1; i++)
        {

            for (int j = i + 1; j < len; j++) 
            {
                if (a[j] < a[i]) //每次把比较小的放到了最前方，并非把最小的找到，而且是不稳定排序
                {
                    int temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                }
            }
            
            Utilit.Print(a, i);
        }
    }
    

}

public class _013_SelectSort : MonoBehaviour {

	
	void Start ()
    {
        int[] a = Utilit.RandArray(20, 10);

        int[] b = (int[])a.Clone();

        Debug.Log("-------------正确简单选择排序--------------");
        SelectSort.SampleSelectSort(a);
        
        Debug.Log("-------------错误简单选择排序--------------");
        SelectSort.ErrorSampleSelectSort(b);

    }
	
}
