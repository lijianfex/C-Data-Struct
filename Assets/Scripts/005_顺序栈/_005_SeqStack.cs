using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 顺序栈
/// </summary>
/// <typeparam name="T"></typeparam>
public class SeqStack<T>
{
    private T[] data;
    private int top; ///*用来存放栈顶元素的下标，top 为-1 表示空栈*/

    public SeqStack(int size)
    {
        data = new T[size];
        top = -1;
    }

    public SeqStack() : this(10)//默认构造函数，最大容量10
    {

    }

    //栈最大容量
    public int MaxSize
    {
        get
        {
            return data.Length;
        }
    }

    //判空
    public bool IsEmpty()
    {
        return top == -1;
    }

    //判满
    public bool IsFull()
    {
        return top == data.Length - 1;
    }

    //进栈
    public void Push(T item)
    {
        if(IsFull())
        {
            Debug.LogError("栈满！");
            return;
        }
        data[++top] = item;
    }

    //出栈
    public T Pop()
    {
        if(IsEmpty())
        {
            throw new System.Exception("栈空，无法出栈！");
        }
        return data[top--];
    }

    //访问栈顶
    public T Peek()
    {
        if (IsEmpty())
        {
            throw new System.Exception("栈空，无法访问栈顶！");           
        }
        return data[top];
    }

    //栈中元素个数
    public int Count
    {
        get
        {
            return top + 1;
        }
    }

    //清空栈
    public void Clear()
    {
        top = -1;
    }
}




public class _005_SeqStack : MonoBehaviour
{
    SeqStack<string> seqStack;

    void Start()
    {
        //初始化栈
        seqStack = new SeqStack<string>(4);//size=4

        //栈最大容量       
        Debug.Log("栈最大容量：" + seqStack.MaxSize);

        //判空
        Debug.Log("栈是否空：" + seqStack.IsEmpty());

        //判满
        Debug.Log("栈是否满：" + seqStack.IsFull());

        //进栈
        Debug.Log("进栈：" + "1,2,3,4");
        seqStack.Push("1");
        seqStack.Push("2");
        seqStack.Push("3");
        seqStack.Push("4");

        //栈中元素个数
        Debug.Log("栈中元素个数：    " + seqStack.Count);

        //判满
        Debug.Log("栈是否满：" + seqStack.IsFull());

        //出栈
        Debug.Log("出栈-----出栈值为：" + seqStack.Pop());

        //栈中元素个数
        Debug.Log("出栈后，栈中元素个数：    " + seqStack.Count);

        //访问栈顶元素
        Debug.Log("栈顶元素值：    " + seqStack.Peek());

        //栈中元素个数
        Debug.Log("访问栈顶后，栈中元素个数：    " + seqStack.Count);

        //清空栈
        seqStack.Clear();
        Debug.Log("清空栈！");

        //栈中元素个数
        Debug.Log("清空栈后，栈中元素个数：    " + seqStack.Count);
    }

}

