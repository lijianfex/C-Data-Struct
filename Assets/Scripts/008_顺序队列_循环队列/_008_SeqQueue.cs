using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 顺序队列
/// </summary>
/// <typeparam name="T"></typeparam>
public class SeqQueue<T>
{
    private T[] data;
    private int front;//队首
    private int rear;//队尾
    private int count;//队中个数


    //初始化
    public SeqQueue(int size)//size:最大容量
    {
        data = new T[size];
        front = 0;
        rear = 0;
        count = 0;
    }

    public SeqQueue() : this(10)
    {

    }

    //最大容量
    public int MaxSize
    {
        get
        {
            return data.Length;
        }
    }

    //队中元素个数
    public int Count
    {
        get
        {
            return count;
        }

        set
        {
            count = value;
        }
    }

    //判空
    public bool IsEmpty()
    {
        return Count == 0;
    }

    //判满
    public bool IsFull()
    {
        return Count == MaxSize;
    }

    //入队
    public void Enqueue(T item)
    {
        if (IsFull())
        {
            throw new System.Exception("队满，无法入队！");
        }
        data[rear] = item;
        Count++;
        rear = (rear + 1) % MaxSize;//修改队尾指针
    }

    //出队
    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new System.Exception("队空，无法出队！");
        }

        T t = data[front];
        front = (front + 1) % MaxSize; //修改队首指针
        Count--;
        return t;

    }

    //访问队首元素
    public T Peek()
    {
        if (IsEmpty())
        {
            throw new System.Exception("队空，无法访问队首！");
        }
        return data[front];
    }

    //清空队列
    public void Clear()
    {
        front = 0;
        rear = 0;
        Count = 0;
    }


}

public class _008_SeqQueue : MonoBehaviour
{
    SeqQueue<string> seqQueue;

    void Start()
    {
        //初始化队列
        seqQueue = new SeqQueue<string>(4);//size=4

        //队列最大容量       
        Debug.Log("队列最大容量：" + seqQueue.MaxSize);

        //判空
        Debug.Log("队列是否空：" + seqQueue.IsEmpty());

        //判满
        Debug.Log("队列是否满：" + seqQueue.IsFull());

        //入队列
        Debug.Log("入队列：" + "1,2,3,4");
        seqQueue.Enqueue("1");
        seqQueue.Enqueue("2");
        seqQueue.Enqueue("3");
        seqQueue.Enqueue("4");

        //队列中元素个数
        Debug.Log("队列中元素个数：    " + seqQueue.Count);

        //判满
        Debug.Log("队列是否满：" + seqQueue.IsFull());

        //出队列
        Debug.Log("出队列-----出队列值为：" + seqQueue.Dequeue());
       
        //队列中元素个数
        Debug.Log("出队列后，队列中元素个数：    " + seqQueue.Count);

        //访问队首元素
        Debug.Log("队首元素值：    " + seqQueue.Peek());

        //队列中元素个数
        Debug.Log("访问队首后，队列中元素个数：    " + seqQueue.Count);

        //清空队列
        seqQueue.Clear();
        Debug.Log("清空队列！");

        //队列中元素个数
        Debug.Log("清空队列后，队列中元素个数：    " + seqQueue.Count);


    }
}
