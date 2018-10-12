using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 链队列节点类
/// </summary>
public class QueueNode<T>
{
    private T data;
    private QueueNode<T> next;

    public QueueNode(T _data)
    {
        this.Data = _data;
        Next = null;
    }

    public T Data
    {
        get
        {
            return data;
        }

        set
        {
            data = value;
        }
    }

    public QueueNode<T> Next
    {
        get
        {
            return next;
        }

        set
        {
            next = value;
        }
    }
}


/// <summary>
/// 链队列类
/// </summary>
public class LinkQueue<T>
{
    private QueueNode<T> front;

    private QueueNode<T> rear;

    private int count;

    public LinkQueue()
    {
        front = null;
        rear = null;
        count = 0;
    }

    //链队中元素个数
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
        return (front == null) && (rear == null) && (Count == 0);
    }

    //入队
    public void Enqueue(T item)
    {
        QueueNode<T> newNode = new QueueNode<T>(item);
        if (IsEmpty())
        {
            front = newNode;
            rear = newNode;
            Count++;
            return;
        }
        rear.Next = newNode;
        rear = newNode;
        Count++;
    }

    //出队
    public T Dequeue()
    {
        if(IsEmpty())
        {
            throw new System.Exception("链队为空，无法出队");
        }

        T t = front.Data;

        if (Count==1)
        {
            front = rear = null;
            Count = 0;
        }
        else
        {
            front = front.Next;
            Count--;
        }

        return t;
    }

    //访问队首
    public T Peek()
    {
        if(IsEmpty())
        {
            throw new System.Exception("链队为空，无法访问队首!");
        }
        return front.Data;
    }

    //清空链队
    public void Clear()
    {
        front = rear = null;
        Count = 0;
    }

}


public class _009_LinkQueue : MonoBehaviour {

    LinkQueue<string> linkQueue;
	
	void Start () {
        //初始化队列
        linkQueue = new LinkQueue<string>();

       
        //判空
        Debug.Log("队列是否空：" + linkQueue.IsEmpty());

        //入队列
        Debug.Log("入队列：" + "1,2,3,4");
        linkQueue.Enqueue("1");
        linkQueue.Enqueue("2");
        linkQueue.Enqueue("3");
        linkQueue.Enqueue("4");

        //队列中元素个数
        Debug.Log("队列中元素个数：    " + linkQueue.Count);


        //出队列
        Debug.Log("出队列-----出队列值为：" + linkQueue.Dequeue());

        //队列中元素个数
        Debug.Log("出队列后，队列中元素个数：    " + linkQueue.Count);

        //访问队首元素
        Debug.Log("队首元素值：    " + linkQueue.Peek());

        //队列中元素个数
        Debug.Log("访问队首后，队列中元素个数：    " + linkQueue.Count);

        //清空队列
        linkQueue.Clear();
        Debug.Log("清空队列！");

        //队列中元素个数
        Debug.Log("清空队列后，队列中元素个数：    " + linkQueue.Count);
    }
	
}
