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

        for (int i = 0; i < len - 1; i++)
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

    //调整推
    public static void HeapAdjust(int[] List, int s, int last) //s 为临时堆顶 索引  last 为 堆尾索引
    {
       
        int maxTemp = s;

        int sLChild = 2 * s;   // s 节点的 左孩子索引
        int sRChild = 2 * s + 1; // s 节点的 右孩子索引


        if (s <= last / 2)  //完全二叉树的叶子结点不需要调整，没有孩子
        {
            if (sLChild <= last && List[sLChild] > List[maxTemp])//如果 当前 结点的左孩子比当前结点记录值大，调整，大顶堆
            {
                //更新 maxtemp
                maxTemp = sLChild;
            }
            if (sRChild <= last && List[sRChild] > List[maxTemp])//如果 当前 结点的右孩子比当前结点记录值大，调整，大顶堆
            {
                //更新 maxtemp
                maxTemp = sRChild;
            }

            //如果调整了就交换，否则不需要交换
            if (List[maxTemp] != List[s])
            {
                //不使用中间变量交换两数的值
                List[maxTemp] = List[maxTemp] + List[s];
                List[s] = List[maxTemp] - List[s];
                List[maxTemp] = List[maxTemp] - List[s];

                //交换完毕，防止调整之后的新的以 maxtemp 为父节点的子树不是大顶堆，再调整一次
                HeapAdjust(List, maxTemp, last);
            }

        }
    }

    //建立堆
    public static void BuildHeap(int[] List, int last)
    {
        //明确，具有 n 个结点的完全二叉树（从左到右，从上到下），编号后，有如下关系，设 a 结点编号为 i，若 i 不是第一个结点，那么 a 结点的双亲结点的编号为[i / 2]

        //非叶节点的最大序号值为 last / 2
        for (int i = last / 2; i >= 0; i--)
        {
            //从头开始调整为大顶堆
            HeapAdjust(List, i, last);
        }
    }

    /// <summary>
    /// 3、选择排序：堆排序
    /// </summary>
    /// <param name="List">数组</param>    
    public static void HeapSort(int[] List)
    {
        //建立大顶堆
        BuildHeap(List, List.Length-1);

        //调整堆
        for (int i = List.Length - 1; i >= 1; i--)
        {
            //将堆顶记录和当前未经排序子序列中最后一个记录相互交换
            //即每次将剩余元素中的最大者list[0] 放到最后面 list[i]
            List[i] = List[i] + List[0];
            List[0] = List[i] - List[0];
            List[i] = List[i] - List[0];

            //重新筛选余下的节点成为新的大顶堆
            HeapAdjust(List, 0, i - 1);
            Utilit.Print(List, i);
        }
    }
}

public class _013_SelectSort : MonoBehaviour
{


    void Start()
    {
        int[] a = Utilit.RandArray(20, 10);

        int[] b = (int[])a.Clone();

        Debug.Log("---------------简单选择排序--------------");
        SelectSort.SampleSelectSort(a);

        //Debug.Log("-------------错误简单选择排序--------------");
        //SelectSort.ErrorSampleSelectSort(b);

        Debug.Log("-------------选择排序:堆排序--------------");
        SelectSort.HeapSort(b);

    }

}
