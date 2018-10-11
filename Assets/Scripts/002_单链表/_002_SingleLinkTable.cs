using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/// <summary>
/// 单链表节点
/// </summary>
/// <typeparam name="T"></typeparam>
public class Node<T>
{
    private T data;//数据

    private Node<T> next; //指针，下个元素

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

    public Node<T> Next
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

    public Node()
    {
        this.data = default(T);
        this.next = null;
    }

    public Node(T _data, Node<T> _next)
    {
        this.data = _data;
        this.next = _next;
    }

    public Node(T _data)
    {
        this.data = _data;
        this.next = null;
    }

    public Node(Node<T> _next)
    {
        this.next = _next;
        this.data = default(T);
    }
       
}

/// <summary>
/// 单链表
/// </summary>
/// <typeparam name="T"></typeparam>
public class LinkList<T> 
{
    private Node<T> head;//头指针

    public LinkList()
    {
        head = new Node<T>();
    }

    

    //判空
    public bool IsEmpty()
    {
        return head.Next == null;
    }

    //添加操作
    public void Add(T item,bool isHeadAdd=false)
    {
        if(isHeadAdd)
        {
            Insert(item, 0);
            return;
        }

        if(IsEmpty())
        {
            head.Next = new Node<T>(item);
        }
        else
        {
            Node<T> temp = head;
            while (true)
            {
                if(temp.Next!=null)
                {
                    temp = temp.Next;
                }
                else
                {
                    break;
                }
            }
            temp.Next = new Node<T>(item);
        }
    }


    //插入操作
    public void Insert(T item, int index)
    {
        if (index < 0 || index > GetLength()) //可以插到尾部
        {
            throw new System.Exception("插入index不合法！");
        }

        Node<T> newNode = new Node<T>(item);
        if(index==0)//头插入
        {
            newNode.Next = head.Next;
            head.Next = newNode;            
        }
        else
        {
            Node<T> temp = head;
            for (int i = 0; i < index ; i++)
            {
                temp = temp.Next;
            }
            Node<T> preNode = temp;
            Node<T> currteNode = temp.Next;
            preNode.Next = newNode;
            newNode.Next = currteNode;
        }
    }

    

    //删除操作
    public T Delete(int index)
    {
        T data = default(T);
        if (index < 0 || index > GetLength()-1)
        {
            throw new System.Exception("删除位置index不合法！");
        }

        Node<T> temp = head;
        for (int i = 0; i < index; i++)
        {
            temp = temp.Next;
        }
        Node<T> preNode = temp;
        Node<T> currteNode = temp.Next;
        preNode.Next = currteNode.Next;
        data = currteNode.Data;
        currteNode = null;
        return data;
    }


    public T this[int index]//索引器访问值
    {
        get
        {
            
            if (index < 0 || index > GetLength() - 1)
            {
                throw new System.Exception("索引不存在");
            }
            Node<T> temp = head;
            for(int i=0;i<=index;i++)
            {
                temp = temp.Next;
            }
            return temp.Data;
        }
    }

    //访问index位置的值
    public T GetElem(int index)
    {
        return this[index];
    }


    //链表长度
    public int GetLength()
    {
        int length = 0;
        if(!IsEmpty())
        {
            Node<T> temp = head;
            while (true)
            {
                if (temp.Next != null)
                {
                    length++;
                    temp = temp.Next;                    
                }
                else
                {
                    break;
                }
            }
        }
        return length;
    }

   
    //寻址
    public int Locate(T value)//有相同值的返回首次查找到的元素的index
    {
        if(!IsEmpty())
        {
            int index = 0;
            Node<T> temp = head;
            while(true)
            {
                if(temp.Next!=null)
                {
                    temp = temp.Next;
                    if (temp.Data.Equals(value))
                    {
                        return index;
                    }
                    index++;
                }
                else
                {
                    break;
                }
            }
            Debug.Log("无此值！");
            return -1;
        }
        else
        {
            Debug.Log("空表！");
            return -1;
        }
        
    }

    //清空操作
    public void Clear()
    {
        head.Next = null;
    }

    //显示表元素
    public void Display()
    {
        if (IsEmpty())
        {
            Debug.Log("表空");
            return;
        }
        Debug.Log("表中的值：");

        int index = 0;
        Node<T> temp = head;
        while (true)
        {
            if (temp.Next != null)
            {
                temp = temp.Next;
                Debug.Log("index:" + index.ToString() + "   value:" +temp.Data);
                index++;
            }
            else
            {
                break;
            }
        }
    }

   
}


public class _002_SingleLinkTable : MonoBehaviour {


   
    LinkList<string> sqeList;

    void Start()
    {   
        //初始化顺序表
        sqeList = new LinkList<string>();

        ////判空操作
        Debug.Log("单链表是否为空：" + sqeList.IsEmpty());



        ////添加操作
        Debug.Log("头插法，添加操作--------------添加'123','456','789'");
        sqeList.Add("123",true);
        sqeList.Add("456",true);
        sqeList.Add("789",true);
        sqeList.Display();
        Debug.Log("尾插法，添加操作--------------添加'123','456','789'");
        sqeList.Add("123");
        sqeList.Add("456");
        sqeList.Add("789");
        sqeList.Display();

        Debug.Log("单链表是否为空：" + sqeList.IsEmpty());


        ////插入操作
        Debug.Log("单链表插入操作---------------在index=3处插入字符串：'111'");
        sqeList.Insert("111", 3);
        sqeList.Display();

        ////删除操作
        sqeList.Delete(2);
        Debug.Log("单链表删除操作---------------删除index=2的元素");
        sqeList.Display();

        ////表长
        Debug.Log("单链表表长-------------------单链表表长：" + sqeList.GetLength());

        ////查找
        Debug.Log("单链表查找--------------index查value");
        Debug.Log("index=0的值：" + sqeList[0]);
        Debug.Log("index=2的值：" + sqeList.GetElem(2));
        Debug.Log("单链表查找--------------value查index");

        ////寻址
        Debug.Log("'789’的index值：" + sqeList.Locate("789"));

        ////清空
        Debug.Log("清空单链表");
        sqeList.Clear();
        sqeList.Display();
    }


}
