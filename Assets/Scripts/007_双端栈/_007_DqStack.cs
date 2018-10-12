using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 顺序栈的两栈共享（双端栈）
/// </summary>
public class DqStack<T>
{
    private T[] data;//数据存储区

    private int[] top = new int[2]; ///*top[0]和 top[1]分别为两个栈顶指示器*/

   

    //初始化
    public DqStack(int size) //size:为最大容量
    {
        data = new T[size];
        top[0] = -1;  //0号栈的栈顶初值
        top[1] = size;//1号栈的栈顶初值
    }

    public DqStack() : this(10) //默认构造函数，最大容量10
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

    /// <summary>
    ///  双栈整体判空
    /// </summary>
    public bool IsEmpty()
    {
        return (top[0] == -1) && (top[1] == MaxSize);
    }


    /// <summary>    
    /// 单栈判空    
    /// </summary>
    /// <param name="i">栈号:0,1</param>
    /// <returns></returns>
    public bool IsEmpty(int i) //i：栈号
    {
        bool isEmpty = false;
        switch (i)
        {
            case 0:
                isEmpty = top[0] == -1 ? true : false;
                break;
            case 1:
                isEmpty = top[1] == MaxSize ? true : false;
                break;
            default:
                throw new System.Exception(i + " 号栈不存在");
        }
        return isEmpty;
    }

    //判满
    public bool IsFull()
    {
        return top[0] + 1 == top[1];
    }



    /// <summary>
    /// 进栈
    /// </summary>
    /// <param name="item">数据</param>
    /// <param name="i">栈号</param>
    public void Push(T item, int i)
    {
        if (IsFull())
        {
            throw new System.Exception("栈已满，无法进栈！");
        }
        switch (i)
        {
            case 0:
                data[++top[0]] = item;
                break;
            case 1:
                data[--top[1]] = item;
                break;
            default:
                throw new System.Exception(i + " 号栈不存在");
        }
    }

    /// <summary>
    /// 出栈
    /// </summary>
    /// <param name="i">栈号</param>
    /// <returns></returns>
    public T Pop(int i)
    {
        if(IsEmpty(i))
        {
            throw new System.Exception(i+" 号栈空，无法出栈！");
        }

        return i == 0 ? data[top[0]--] : data[top[1]++];     
        
    }

    /// <summary>
    /// 访问栈顶元素
    /// </summary>
    /// <param name="i">栈号</param>
    /// <returns></returns>
    public T Peek(int i)
    {
        if (IsEmpty(i))
        {
            throw new System.Exception(i + " 号栈空，无法访问栈顶！");
        }

        return i == 0 ? data[top[0]] : data[top[1]];
    }

    //双栈整体的元素个素
    public int Count()
    {
        return (top[0] + 1) + (MaxSize - top[1]);
    }

    /// <summary>
    /// 单个栈的元素个数
    /// </summary>
    /// <param name="i">栈号</param>
    /// <returns></returns>
    public int Count(int i)
    {
        if(i<0||i>1)
        {
            throw new System.Exception(i + " 号栈，不存在！");
        }

        return i == 0 ? top[0] + 1 : MaxSize - top[1];
    }

    //双栈整体清空
    public void Clear()
    {
        top[0] = -1;
        top[1] = MaxSize;
    }

    /// <summary>
    /// 单个栈清空
    /// </summary>
    /// <param name="i">栈号</param>
    public void Clear(int i)
    {
        if (i < 0 || i > 1)
        {
            throw new System.Exception(i + " 号栈，不存在！");
        }
        if(i==0)
        {
            top[0] = -1;
        }
        else
        {
            top[1] = MaxSize;
        }

        
    }

}


public class _007_DqStack : MonoBehaviour
{
    DqStack<string> dqStack;

    void Start()
    {
        //初始化栈
        dqStack = new DqStack<string>(4);//size=4

        //栈最大容量       
        Debug.Log("双栈最大容量：" + dqStack.MaxSize);

        //判空
        Debug.Log("双栈整体是否空：" + dqStack.IsEmpty());

        //单栈判空
        Debug.Log("0 号栈是否空：" + dqStack.IsEmpty(0));        
        
        Debug.Log("1 号栈是否空：" + dqStack.IsEmpty(1));

        //判满
        Debug.Log("双栈栈是否满：" + dqStack.IsFull());

        //进栈
        Debug.Log("进 0号栈：" + "1,2");
        dqStack.Push("1",0);
        dqStack.Push("2",0);
        Debug.Log("进 1号栈：" + "3,4");
        dqStack.Push("3",1);
        dqStack.Push("4",1);

        Debug.Log("进栈后--------------------");
        //判空
        Debug.Log("双栈整体是否空：" + dqStack.IsEmpty());

        //单栈判空
        Debug.Log("0 号栈是否空：" + dqStack.IsEmpty(0));

        Debug.Log("1 号栈是否空：" + dqStack.IsEmpty(1));

        //判满
        Debug.Log("双栈栈是否满：" + dqStack.IsFull());

        //栈中元素个数
        Debug.Log("进栈后，双栈整体元素个数：    " + dqStack.Count());
        Debug.Log("0 号栈元素个数：    " + dqStack.Count(0));
        Debug.Log("1 号栈元素个数：    " + dqStack.Count(1));

        //出栈
        Debug.Log("出 0号栈-----出栈值为：" + dqStack.Pop(0));
        Debug.Log("出 1号栈-----出栈值为：" + dqStack.Pop(1));

        Debug.Log("出栈后--------------------");
        //栈中元素个数
        Debug.Log("出栈后，双栈整体中元素个数：    " + dqStack.Count());
        Debug.Log("0 号栈元素个数：    " + dqStack.Count(0));
        Debug.Log("1 号栈元素个数：    " + dqStack.Count(1));

        //访问栈顶元素
        Debug.Log("0 号栈顶元素值：    " + dqStack.Peek(0));
        Debug.Log("1 号栈顶元素值：    " + dqStack.Peek(1));

        Debug.Log("访问栈顶--------------------");
        //栈中元素个数
        Debug.Log("访问栈顶，双栈整体中元素个数：    " + dqStack.Count());
        Debug.Log("0 号栈元素个数：    " + dqStack.Count(0));
        Debug.Log("1 号栈元素个数：    " + dqStack.Count(1));

        //清空0栈
        dqStack.Clear(0);
        //栈中元素个数
        Debug.Log("清空0 号栈，双栈整体中元素个数：    " + dqStack.Count());
        Debug.Log("0 号栈元素个数：    " + dqStack.Count(0));
        Debug.Log("1 号栈元素个数：    " + dqStack.Count(1));

        //清空双栈
        dqStack.Clear();
        //栈中元素个数
        Debug.Log("清空双栈，双栈整体中元素个数：    " + dqStack.Count());
        Debug.Log("0 号栈元素个数：    " + dqStack.Count(0));
        Debug.Log("1 号栈元素个数：    " + dqStack.Count(1));

    }

    

}