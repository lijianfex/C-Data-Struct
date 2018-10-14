using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class InserSort
{
    public static void StraightInsetSort(int[] a)
    {
        int x = a[0];//监视哨

        for (int i = 1; i < a.Length; ++i)
        {
            if (a[i] < a[i - 1])
            {
                int j = i - 1;
                x = a[i];
                a[i] = a[i - 1];
                while (x < a[j])
                {
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = x;
            }
            Debug.Log(a);
        }
    }

}

public class _012_InsertSort : MonoBehaviour
{


    void Start()
    {
        int[] a = Rand(20, 10);

        InserSort.StraightInsetSort(a);


    }

    public int[] Rand(int max,int length)
    {
        int[] a = new int[length];
        for(int i=0;i<a.Length;++i)
        {
            a[i] = Random.Range(0, max);
        }
        return a;

    }


}
