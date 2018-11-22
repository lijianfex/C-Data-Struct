using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevesingLinkedList<T>
{


    /// <summary>
    /// 1、逆转单链表的 前 K 个 连续的节点
    /// </summary>
    /// <param name="List">带有头指针的单链表</param>
    /// <param name="head">头指针</param>
    /// <param name="k">要逆转的长度</param>
    public static void ReverseK( Node<T> head, int k)
    {
        if (head.Next==null) return;

        int count = 1;

        Node<T> newNode = head.Next;
        Node<T> oldNode = newNode.Next;
        Node<T> afterNode = new Node<T>();



        while (count < k && oldNode != null)
        {
            afterNode = oldNode.Next;
            oldNode.Next = newNode;
            newNode = oldNode; oldNode = afterNode;
            count++;
        }
        head.Next.Next = oldNode;
        head.Next = newNode;
    }


    /// <summary>
    /// 2、逆转单链表的 第 i至k 个 连续的节点
    /// </summary>
    /// <param name="List">带有头指针的单链表</param>
    /// <param name="head">头指针</param>
    /// <param name="i">起始</param>
    /// <param name="k">结束</param>
    public static void ReverseItoK( Node<T> head, int i, int k)
    {
        if (head.Next == null) return;

        int count = 1;

        Node<T> beforeNode = head;
        Node<T> newNode = head.Next;
        Node<T> oldNode = newNode.Next;
        Node<T> afterNode = new Node<T>();

        if(i>k)
        {
            int temp = i;
            i = k;
            k = temp;
        }


        while (count < k && oldNode != null)
        {
            afterNode = oldNode.Next;
            if (count < i)
            {
                beforeNode = newNode;
            }
            if (count >= i)
            {
                oldNode.Next = newNode;
            }
            newNode = oldNode; oldNode = afterNode;
            count++;
        }
        beforeNode.Next.Next = oldNode;
        beforeNode.Next = newNode;
    }


    /// <summary>
    /// 3、K 个一组逆转链表
    /// </summary>
    /// <param name="head"></param>
    /// <param name="k"></param>
    public static void ReverseKGroup( Node<T> head, int k)
    {
        if (head.Next == null) return;

        int start = 1;

        Node<T> curNode=head.Next;

        while(true)
        {
            for(int i=0;i<k;i++) //检查后方是否有 K 个元素
            {
                if (curNode == null)
                {
                    return; //没有就 终止函数
                }
                curNode = curNode.Next;                
            }
            
            ReverseItoK(head, start, start + k-1); //调用问题2的函数
            start += k;
        }
    }

   
}


public class _020_RevesingLinkedList : MonoBehaviour
{


    void Start()
    {
        LinkList<int> List = new LinkList<int>();


        List.Add(1);
        List.Add(2);
        List.Add(3);
        List.Add(4);
        List.Add(5);
        Debug.Log("初始单链表");
        List.Display();

        RevesingLinkedList<int>.ReverseK( List.Head, 3);
        Debug.Log("逆转单链表的前3个元素");
        List.Display();

        RevesingLinkedList<int>.ReverseItoK(List.Head, 2, 4);
        Debug.Log("逆转单链表的2-4号元素");
        List.Display();

        RevesingLinkedList<int>.ReverseKGroup(List.Head,2);
        Debug.Log("2个一组逆转单链表元素");
        List.Display();

       

    }

    
}
