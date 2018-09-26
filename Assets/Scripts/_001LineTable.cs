using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///线性表接口
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IListDS<T>
{
    int GetLength();
    void Clear();
    bool IsEmpty();
    void Add(T item);
    void Insert(T item, int index);
    T Delete(int index);
    T this[int index] { get; }
    T GetElem(int index);
    int Locate(T value);   
    
}

/// <summary>
/// 顺序表
/// </summary>
/// <typeparam name="T"></typeparam>
public class SqeList<T> : IListDS<T>
{
    private T[] data;
    private int count = 0;

    public SqeList(int size)//size最大容量
    {
        data = new T[size];
        count = 0;
    }

    public SqeList():this(10)//默认构造函数，容量10
    {

    }


    
    public T this[int index]
    {
        get {return GetElem(index); }
    }

    public void Add(T item)
    {
        if(count==data.Length)
        {
            Debug.Log("当前顺序表已存满！");
            return;
        }
        data[count] = item;
        count++;
    }

    public void Clear()
    {
        count = 0;
    }

    public T Delete(int index)
    {
        T temp = data[index];
        for(int i=index+1;i<count;i++)
        {
            data[i - 1] = data[i];
        }
        count--;
        return temp;
    }

    public T GetElem(int index)
    {
        if(index>=0&&index<=count-1)
        {
            return data[index];
        }
        else
        {
            Debug.Log("索引不存在");
            return default(T);
        }
    }

    public int GetLength()
    {
        return count;
    }

    public void Insert(T item, int index)
    {
        for(int i=count-1;i>index-1;i--)
        {
            data[i + 1] = data[i];
        }
        data[index] = item;
        count++;
    }

    public bool IsEmpty()
    {
        return count == 0;
    }

    public int Locate(T value)
    {
        for(int i=0;i<count;i++)
        {
            if(data[i].Equals(value))
            {
                return i;
            }
        }
        return -1;
    }
}


public class _001LineTable : MonoBehaviour {

    //使用顺序表
    SqeList<string> sqeList = new SqeList<string>();
   
	void Start ()
    {
        sqeList.Add("123");
        sqeList.Add("456");
        sqeList.Add("789");

        Debug.Log(sqeList[0]);
        sqeList.Insert("111", 1);
        for(int i=0;i<sqeList.GetLength();i++)
        {
            Debug.Log(sqeList[i]);
        }
        sqeList.Delete(3);
        for (int i = 0; i < sqeList.GetLength(); i++)
        {
            Debug.Log(sqeList[i]);
        }

    }

}
