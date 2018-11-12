using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 二叉树节点
/// </summary>
/// <typeparam name="T"></typeparam>
public class TreeNode<T>
{
    T data;
    TreeNode<T> left;
    TreeNode<T> right;

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

    public TreeNode<T> Left
    {
        get
        {
            return left;
        }

        set
        {
            left = value;
        }
    }

    public TreeNode<T> Right
    {
        get
        {
            return right;
        }

        set
        {
            right = value;
        }
    }
    

    public TreeNode(T _data, TreeNode<T> _left, TreeNode<T> _right)
    {
        this.data = _data;
        this.left = _left;
        this.right = _right;
    }

    public TreeNode(T _data) : this(_data, null, null)
    {

    }

    //设置 左右孩子
    public void SetLRChild(TreeNode<T> _left, TreeNode<T> _right)
    {
        this.left = _left;
        this.right = _right;
    }

    //设置 左孩子
    public void SetLChild(TreeNode<T> _left)
    {
        this.left = _left;
    }

    //设置 右孩子
    public void SetRChild(TreeNode<T> _right)
    {
        this.right = _right;
    }
}

public class BinTree<T>
{
    private static string output;//显示遍历结果

    //非递归：
    
    /// <summary>
    /// 先序遍历
    /// </summary>
    /// <param name="root"></param>
    public static void PreOrderTraversal(TreeNode<T> root) 
    {
        TreeNode<T> node = root;

        LinkStack<TreeNode<T>> S = new LinkStack<TreeNode<T>>();//使用了自己定义的链栈
        //Stack<TreeNode<T>> S = new Stack<TreeNode<T>>(); //系统提供的

        while (node != null || !S.IsEmpty())
        {
            while (node != null)
            {
                output += node.Data.ToString() + " "; //输出数据;//输出数据
                S.Push(node);
                node = node.Left;
            }
            if (!S.IsEmpty())
            {
                node = S.Pop();
                node = node.Right;
            }
        }
        Debug.Log(output);
        output = string.Empty;
    }
    

    /// <summary>
    /// 中序遍历
    /// </summary>
    /// <param name="rootNode"></param>
    public static void MidOrderTraversal(TreeNode<T> rootNode)
    {
        TreeNode<T> node = rootNode;

        LinkStack<TreeNode<T>> S = new LinkStack<TreeNode<T>>();//使用了自己定义的链栈
        //Stack<TreeNode<T>> S = new Stack<TreeNode<T>>(); //系统提供的

        while (node != null || !S.IsEmpty())
        {
            while (node != null)
            {
                S.Push(node);
                node = node.Left;
            }
            if (!S.IsEmpty())
            {
                node = S.Pop();
                output += node.Data.ToString() + " "; //输出数据
                node = node.Right;
            }
        }
        Debug.Log(output);
        output = string.Empty;
    }


    /// <summary>
    /// 后序遍历：（重点）
    /// 
    /// 使用 : 双栈法
    /// </summary>
    /// <param name="rootNode"></param>
    public static void PostOrderTraversal(TreeNode<T> rootNode)
    {
        TreeNode<T> node = rootNode;

        LinkStack<TreeNode<T>> S = new LinkStack<TreeNode<T>>();//使用了自己定义的链栈
        //Stack<TreeNode<T>> S = new Stack<TreeNode<T>>(); //系统提供的

        LinkStack<TreeNode<T>> OutStack = new LinkStack<TreeNode<T>>();//使用了自己定义的链栈
        //Stack<TreeNode<T>> OutStack = new Stack<TreeNode<T>>();//系统提供的

        while (node != null || !S.IsEmpty())
        {
            while (node != null)
            {
                S.Push(node);
                OutStack.Push(node);
                node = node.Right;
            }

            if (!S.IsEmpty())
            {
                node = S.Pop();
                node = node.Left;
            }
        }

        while (OutStack.Count > 0)
        {
            TreeNode<T> outNode = OutStack.Pop();
            output += outNode.Data.ToString() + " "; //输出数据
        }

        Debug.Log(output);
        output = string.Empty;
    }

    /// <summary>
    /// 层序遍历：（重点）
    /// 使用 ：队列
    /// </summary>
    /// <param name="rootNode"></param>
    public static void LayerOrderTraversal(TreeNode<T> rootNode)
    {
        LinkQueue<TreeNode<T>> queue;//使用自定义的链队列
        //Queue<TreeNode<T>> queue;//系统提供的
        TreeNode<T> outNode;

        if (rootNode == null) return; //若是空树，直接返回

        queue = new LinkQueue<TreeNode<T>>();   //创建队列   
        //queue=new Queue<TreeNode<T>>();

        queue.Enqueue(rootNode);
        while (!queue.IsEmpty())
        {
            outNode = queue.Dequeue(); //出队
            output += outNode.Data.ToString() + " ";    //访问节点数据

            //若输出节点，左右孩子不空，依次入队
            if (outNode.Left != null) queue.Enqueue(outNode.Left);
            if (outNode.Right != null) queue.Enqueue(outNode.Right);

        }

        Debug.Log(output);
        output = string.Empty;

    }



}



public class _017_BinTree : MonoBehaviour
{
    //假设二叉树: 
    private string tree = @"     
              1
             / \
            2   3
           / \
          4   5
         / \ 
        6   7              
                           ";

    void Start()
    {
        //构造树
        TreeNode<int> root = new TreeNode<int>(1);
        TreeNode<int> t2 = new TreeNode<int>(2);
        TreeNode<int> t3 = new TreeNode<int>(3);
        TreeNode<int> t4 = new TreeNode<int>(4);
        TreeNode<int> t5 = new TreeNode<int>(5);
        TreeNode<int> t6 = new TreeNode<int>(6);
        TreeNode<int> t7 = new TreeNode<int>(7);

        root.SetLRChild(t2, t3);
        t2.SetLRChild(t4, t5);
        t4.SetLRChild(t6, t7);

        //遍历：
        Debug.Log("二叉树结构：" + "\n" + tree);

        Debug.Log("------------先序遍历-------------");
        BinTree<int>.PreOrderTraversal(root);

        Debug.Log("------------中序遍历-------------");
        BinTree<int>.MidOrderTraversal(root);

        Debug.Log("------------后序遍历-------------");
        BinTree<int>.PostOrderTraversal(root);

        Debug.Log("------------层序遍历-------------");
        BinTree<int>.LayerOrderTraversal(root);

    }



}
