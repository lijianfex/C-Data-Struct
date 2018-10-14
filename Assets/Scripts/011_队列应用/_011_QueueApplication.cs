using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _011_QueueApplication : MonoBehaviour
{
    SeqQueue<string> queue = new SeqQueue<string>(10);
    string input = null, output = null;
    

    void Start()
    {

        //for (; ; )
        //{
        //    for (; ; )
        //    {
        //        print("进程1执行中，输入缓冲中！");
        //        if (Input.anyKeyDown)
        //        {
        //            input = GetChar();

        //            if (input == ";" || input == ",") //正常结束缓冲输入进程
        //            {
        //                break;
        //            }

        //            queue.Enqueue(input); //加入缓冲队列

        //            if (queue.IsFull()) //缓冲循环队列输入已满
        //            {
        //                print("缓冲循环队列输入已满！");
        //                break;
        //            }
        //        }
        //    }


        //}


    }

    private void Update()
    {
        print("等待输入！");
        InputString();



    }

    


    public void InputString()
    {
        if (Input.anyKeyDown)
        {
            input = Input.inputString;

            if (queue.IsFull()) //缓冲循环队列输入已满
            {
                print("缓冲循环队列输入已满！结束缓冲输入进程");
                OutputString();
                return;
            }

            queue.Enqueue(input); //加入缓冲队列

            if (input == ";" || input == ",") //正常结束缓冲输入进程
            {
                print("遇到  ;  ,  字符正常结束缓冲输入进程");
                OutputString();
            }

            if(input == ".")
            {
                print("程序终止");
                UnityEditor.EditorApplication.isPlaying = false;
                OutputString();
            }
        }
    }


    public void OutputString()
    {
        while(!queue.IsEmpty())
        {
            output += queue.Dequeue();
        }
        print("显示缓冲输入区的字符： " + output);
    }

    
}
