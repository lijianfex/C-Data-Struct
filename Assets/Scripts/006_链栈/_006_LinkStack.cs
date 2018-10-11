using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 链栈节点类
/// </summary>
/// <typeparam name="T"></typeparam>
public class LinkStackNode<T>
{
    private T data;//数据

    private LinkStackNode<T> next; //指针，下个元素

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

    public LinkStackNode<T> Next
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

    public LinkStackNode()
    {
        this.data = default(T);
        this.next = null;
    }

    public LinkStackNode(T _data, LinkStackNode<T> _next)
    {
        this.data = _data;
        this.next = _next;
    }

    public LinkStackNode(T _data)
    {
        this.data = _data;
        this.next = null;
    }

    public LinkStackNode(LinkStackNode<T> _next)
    {
        this.next = _next;
        this.data = default(T);
    }

}


public class LinkStack<T>
{
    private LinkStackNode<T> top;//栈顶头指针

    private int count;//栈中元素个数

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

    //初始化栈
    public LinkStack()
    {
        top = new LinkStackNode<T>();
        count = 0;
    }

    //判栈空
    public bool IsEmpty()
    {
        return (Count == 0)&&(top.Next==null);
    }

    //进栈
    public void Push(T item)
    {
        LinkStackNode<T> newNode = new LinkStackNode<T>(item);
        if(newNode==null)
        {
            return;
        }
        newNode.Next = top.Next;
        top.Next = newNode;
        Count++;
    }

    //出栈
    public T Pop()
    {
        if(IsEmpty())
        {
            throw new System.Exception("栈空，无法出栈！");
        }
        LinkStackNode<T> currentTopNode = top.Next;
        top.Next = currentTopNode.Next;        
        Count--;
        return currentTopNode.Data;
    }

    //访问栈顶元素
    public T Peek()
    {
        if (IsEmpty())
        {
            throw  new System.Exception("栈空，无法访问栈顶！");
        }
        return top.Next.Data;
    }

   

    //清空栈
    public void Clear()
    {
        top.Next=null;
        Count = 0;
    }

}


public class _006_LinkStack : MonoBehaviour
{

    LinkStack<string> linkStack;

    void Start()
    {
        //初始化链栈
        linkStack = new LinkStack<string>();
        

        //判空
        Debug.Log("链栈是否空：" + linkStack.IsEmpty());


        //进栈
        Debug.Log("进栈：" + "1,2,3,4");
        linkStack.Push("1");
        linkStack.Push("2");
        linkStack.Push("3");
        linkStack.Push("4");

        //判空
        Debug.Log("链栈是否空：" + linkStack.IsEmpty());

        //栈中元素个数
        Debug.Log("链栈中元素个数：    " + linkStack.Count);
        

        //出栈
        Debug.Log("出栈-----出栈值为：" + linkStack.Pop());

        //栈中元素个数
        Debug.Log("出栈后，链栈中元素个数：    " + linkStack.Count);

        //访问栈顶元素
        Debug.Log("链栈顶元素值：    " + linkStack.Peek());

        //栈中元素个数
        Debug.Log("访问链栈顶后，链栈中元素个数：    " + linkStack.Count);

        //清空栈
        linkStack.Clear();
        Debug.Log("清空链栈！");

        //栈中元素个数
        Debug.Log("清空链栈后，栈中元素个数：    " + linkStack.Count);
    }

}
