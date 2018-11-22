using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///线性表接口
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IListDS<T>
{
    

    bool IsEmpty();
   

    //void Add(T item);
    void Insert(T item, int index);
    T Delete(int index);

    int GetLength();

    T this[int index] { get; }
    T GetElem(int index);
    int Locate(T value);

    void Clear();



}

/// <summary>
/// 顺序表
/// </summary>
/// <typeparam name="T"></typeparam>
public class SqeList<T> : IListDS<T>
{
    private T[] data;
    private int last = -1;

    //初始化顺序表
    public SqeList(int size)//size最大容量
    {
        data = new T[size];
        last = -1;
    }

    public SqeList() : this(10)//默认构造函数，容量10
    {

    }

    //表最大容量
    public int MaxSize()
    {
        return data.Length;
    }



    //判空
    public bool IsEmpty()
    {
        return last == -1;
    }

    //判满
    public bool IsFull()
    {
        return last == data.Length - 1;
    }


    //添加操作
    public void Add(T item)
    {
        if (IsFull())
        {
            throw new System.Exception("当前顺序表已存满！");           
        }
        data[last + 1] = item;
        last++;
    }


    //插入操作
    public void Insert(T item, int index)
    {
        if (index < 0 || index > last)
        {
            throw new System.Exception("插入index不合法！");
        }
        if (IsFull())
        {
            throw new System.Exception("当前顺序表已存满！");
        }

        for (int i = last; i >= index; i--)
        {
            data[i + 1] = data[i];
        }
        data[index] = item;
        last++;
    }

    //根据索性删除表元素
    public T Delete(int index)
    {
        if (index < 0 || index > last)
        {
            throw new System.Exception("删除位置index不合法！");
            
        }
        T temp = data[index];
        for (int i = index + 1; i <= last; i++)
        {
            data[i - 1] = data[i];
        }
        last--;
        return temp;
    }

    //表长
    public int GetLength()
    {
        return last + 1;
    }

    //根据索引获得表元素
    public T GetElem(int index)
    {
        if (index >= 0 && index <= last)
        {
            return data[index];
        }
        else
        {
            throw new System.Exception("索引不存在");
        }
    }

    public T this[int index]//索引器
    {
        get { return GetElem(index); }
    }



    //获取元素索引值
    public int Locate(T value)
    {
        for (int i = 0; i <= last; i++)
        {
            if (data[i].Equals(value))
            {
                return i;
            }
        }
        return -1;
    }

    //清空顺序表
    public void Clear()
    {
        last = -1;
    }

    //显示所有的表元素值
    public void Display()
    {
        string str = null;
        if (IsEmpty())
        {
            Debug.Log("表中没有元素");
            return;
        }
        Debug.Log("顺序表中的值：");
        for (int i = 0; i <= last; i++)
        {
            //Debug.Log("index:"+i.ToString()+"   value:"+data[i]);
            str += data[i] + " , ";
        }
        Debug.Log(str);
    }
}


public class _001LineTable : MonoBehaviour
{

    //初始化顺序表
    SqeList<string> sqeList = new SqeList<string>(20);

    void Start()
    {
        Debug.Log("顺序表的最大容量：" + sqeList.MaxSize());

        //判空操作
        Debug.Log("顺序表是否为空：" + sqeList.IsEmpty());

        //判满操作
        Debug.Log("顺序表是否已满：" + sqeList.IsFull());

        //添加操作
        Debug.Log("添加操作--------------添加'123','456','789'");
        sqeList.Add("123");
        sqeList.Add("456");
        sqeList.Add("789");        
        sqeList.Display();

        Debug.Log("顺序表是否为空：" + sqeList.IsEmpty());
        

        //插入操作
        Debug.Log("插入操作---------------在index=2处插入字符串：'111'");
        sqeList.Insert("111", 2);
        sqeList.Display();

        //删除操作
        sqeList.Delete(2);
        Debug.Log("删除操作---------------删除index=2的元素");
        sqeList.Display();

        //表长
        Debug.Log("表长-------------------顺序表表长：" + sqeList.GetLength());

        //查找
        Debug.Log("查找--------------index查value");
        Debug.Log("index=0的值：" + sqeList[0]);
        Debug.Log("index=2的值：" + sqeList.GetElem(2));
        Debug.Log("查找--------------value查index");
        Debug.Log("'789’的index值：" + sqeList.Locate("789"));

        //清空
        Debug.Log("清空表");
        sqeList.Clear();        
        sqeList.Display();

        

    }



}
