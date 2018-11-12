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
    private static string output;

    private static void VisitNode(TreeNode<T> node)
    {
        output += node.Data.ToString() + " ";
    }

    public static void DisPlayOutPut()
    {
        Debug.Log(output);
        output = string.Empty;
    }//显示遍历结果

    //非递归：

    /// <summary>
    /// 先序遍历
    /// </summary>
    /// <param name="root"></param>
    public static void PreOrderTraversal(TreeNode<T> rootNode)
    {
        TreeNode<T> node = rootNode;

        LinkStack<TreeNode<T>> S = new LinkStack<TreeNode<T>>();//使用了自己定义的链栈
        //Stack<TreeNode<T>> S = new Stack<TreeNode<T>>(); //系统提供的

        while (node != null || !S.IsEmpty())
        {
            while (node != null)
            {
                VisitNode(node); //访问该节点

                S.Push(node);
                node = node.Left;
            }
            if (!S.IsEmpty())
            {
                node = S.Pop();
                node = node.Right;
            }
        }
       
    }


    /// <summary>
    /// 中序遍历
    /// </summary>
    /// <param name="rootNode"></param>
    public static void InOrderTraversal(TreeNode<T> rootNode)
    {
        TreeNode<T> node = rootNode;

        LinkStack<TreeNode<T>> S = new LinkStack<TreeNode<T>>();//使用了自己定义的链栈
        
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
                VisitNode(node); //访问该节点
                node = node.Right;
            }
        }
        
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
            VisitNode(outNode); //访问该节点
        }

        
    }

    /// <summary>
    /// 层序遍历：（重点）
    /// 使用 ：队列
    /// </summary>
    /// <param name="rootNode"></param>
    public static void LayerOrderTraversal(TreeNode<T> rootNode)
    {
       
        if (rootNode == null) return; //若是空树，直接返回

        LinkQueue<TreeNode<T>> queue = new LinkQueue<TreeNode<T>>();   //创建队列，使用自定义的链队列   Queue<TreeNode<T>> queue;//系统提供的

        int deepth = 0;//记录当前遍历层次

        int levelNodesCount = 0; //当前遍历的层的节点总数

        TreeNode<T> outNode; 

        queue.Enqueue(rootNode);

        while (!queue.IsEmpty())
        {
            ++deepth;

            levelNodesCount = queue.Count; 

            for (int i = 0; i < levelNodesCount; ++i)
            {
                outNode = queue.Dequeue(); //出队 

                VisitNode(outNode); //访问该节点

                //若输出节点，左右孩子不空，依次入队
                if (outNode.Left != null) queue.Enqueue(outNode.Left);
                if (outNode.Right != null) queue.Enqueue(outNode.Right);
            }

        }

       

    }

    //遍历的应用

    /// <summary>
    /// 输出树的叶子结点：非递归---利用先序非递归实现
    /// </summary>
    /// <param name="rootNode"></param>
    public static void PreOderPrintLeaves(TreeNode<T> rootNode)
    {
        TreeNode<T> node = rootNode;

        LinkStack<TreeNode<T>> S = new LinkStack<TreeNode<T>>();//使用了自己定义的链栈
        
        while (node != null || !S.IsEmpty())
        {
            while (node != null)
            {
                if (node.Left == null && node.Right == null)//判断是否是叶节点
                {
                    VisitNode(node); //访问该节点
                }
                S.Push(node);
                node = node.Left;
            }
            if (!S.IsEmpty())
            {
                node = S.Pop();
                node = node.Right;
            }
        }
        
    }

    /// <summary>
    /// 输出树的叶子结点：递归式
    /// </summary>
    /// <param name="rootNode"></param>
    public static void PrintLeaves(TreeNode<T> rootNode)
    {
        TreeNode<T> BT = rootNode;
        if (BT != null)
        {
            if (BT.Left == null && BT.Right == null)
            {
                VisitNode(BT); //访问该节点
            }
            PrintLeaves(BT.Left);
            PrintLeaves(BT.Right);
        }
    }

    /// <summary>
    /// 输出树的高度：非递归---利用层序非递归实现
    /// </summary>
    /// <param name="rootNode"></param>
    /// <returns></returns>
    public static int LayerOderBinTreeHigh(TreeNode<T> rootNode)
    {
        if (rootNode == null) return 0;

        LinkQueue<TreeNode<T>> queue = new LinkQueue<TreeNode<T>>();   //创建队列，使用自定义的链队列

        int deepth = 0;//记录当前遍历层次

        int levelNodesCount = 0; //当前遍历的层的节点总数

        TreeNode<T> outNode;                  

        queue.Enqueue(rootNode);

        

        while (!queue.IsEmpty())
        {
            ++deepth;//当前遍历的层次

            levelNodesCount = queue.Count;

            for (int i = 0; i < levelNodesCount; ++i)
            {
                outNode = queue.Dequeue();

                if (outNode.Left != null) queue.Enqueue(outNode.Left);
                if (outNode.Right != null) queue.Enqueue(outNode.Right);
            }


        }

        return deepth; //最终的层次：树的高度

    }

    /// <summary>
    /// 输出树的高度:递归式---利用公式：max(LH,RH)+1
    /// </summary>
    /// <param name="rootNode"></param>
    /// <returns></returns>
    public static int BinTreeHigh(TreeNode<T> rootNode)
    {
        int LH, RH;
        TreeNode<T> BT = rootNode;
        if (BT == null)
        {
            return 0;
        }
        else
        {
            LH = BinTreeHigh(BT.Left);
            RH = BinTreeHigh(BT.Right);
            return LH > RH ? LH + 1 : RH + 1;
        }
    }

    /// <summary>
    /// 输出某层的所有节点：非递归---利用层序非递归实现
    /// </summary>
    /// <param name="rootNode"></param>
    /// <param name="level"></param>
    public static void LayerOderPrintLevelNodes(TreeNode<T> rootNode, int level)
    {
        if (rootNode == null) return;

        LinkQueue<TreeNode<T>> queue = new LinkQueue<TreeNode<T>>();   //创建队列，使用自定义的链队列

        int deepth = 0;//记录当前遍历层次

        int levelNodesCount = 0; //当前遍历的层的节点总数

        TreeNode<T> outNode;

        queue.Enqueue(rootNode);


        while (!queue.IsEmpty())
        {
            ++deepth;

            levelNodesCount = queue.Count;

            for (int i = 0; i < levelNodesCount; ++i)
            {
                outNode = queue.Dequeue();

                if (deepth == level) //判断是否是要访问的层的节点
                {
                    VisitNode(outNode);//访问节点
                }

                if (outNode.Left != null) queue.Enqueue(outNode.Left);
                if (outNode.Right != null) queue.Enqueue(outNode.Right);
            }

        }
        
    }

    /// <summary>
    /// 输出某层的所有节点：递归式---判断 Leve==1
    /// </summary>
    /// <param name="rootNode"></param>
    /// <param name="level"></param>
    public static void PrintLevelNodes(TreeNode<T> rootNode, int level)
    {
        if (rootNode == null) return;
        TreeNode<T> BT = rootNode;
        if (level == 1)
        {
            VisitNode(BT);
        }
        else
        {
            PrintLevelNodes(BT.Left, level - 1);
            PrintLevelNodes(BT.Right, level - 1);
        }
    }

   


}



public class _017_BinTree : MonoBehaviour
{
    //二叉树结构: 
    private string tree = @"     
              1
             / \
            2   3
           / \
          4   5
         / \ 
        6   7              
                           ";

    TreeNode<int> root; //二叉树根节点

    //创建二叉树
    void CreatBinTree()
    {
       
        root = new TreeNode<int>(1);
        TreeNode<int> t2 = new TreeNode<int>(2);
        TreeNode<int> t3 = new TreeNode<int>(3);
        TreeNode<int> t4 = new TreeNode<int>(4);
        TreeNode<int> t5 = new TreeNode<int>(5);
        TreeNode<int> t6 = new TreeNode<int>(6);
        TreeNode<int> t7 = new TreeNode<int>(7);

        root.SetLRChild(t2, t3);
        t2.SetLRChild(t4, t5);
        t4.SetLRChild(t6, t7);
    }

    void Start()
    {
        CreatBinTree();//创建二叉树

        
        Debug.Log("二叉树结构：" + "\n" + tree);

        //遍历：
        Debug.Log("------------先序遍历（非递归）-------------");
        BinTree<int>.PreOrderTraversal(root);
        BinTree<int>.DisPlayOutPut();

        Debug.Log("------------中序遍历（非递归）-------------");
        BinTree<int>.InOrderTraversal(root);
        BinTree<int>.DisPlayOutPut();

        Debug.Log("------------后序遍历（非递归）-------------");
        BinTree<int>.PostOrderTraversal(root);
        BinTree<int>.DisPlayOutPut();

        Debug.Log("------------层序遍历（非递归）-------------");
        BinTree<int>.LayerOrderTraversal(root);
        BinTree<int>.DisPlayOutPut();


        //遍历应用：
        Debug.Log("输出树的叶子节点：");
        Debug.Log("---------非递归----利用先序非递归实现-----");
        BinTree<int>.PreOderPrintLeaves(root);
        BinTree<int>.DisPlayOutPut();

        Debug.Log("---------递归式----利用先序递归实现-------");
        BinTree<int>.PrintLeaves(root);
        BinTree<int>.DisPlayOutPut();

        Debug.Log("输出树的高度：");
        Debug.Log("---------非递归----利用层序非递归实现------");
        int high1= BinTree<int>.LayerOderBinTreeHigh(root);
        Debug.Log("树的高度: " + high1);        

        Debug.Log("---------递归式----利用公式：max(LH,RH)+1 ");
        int high2 = BinTree<int>.BinTreeHigh(root);
        Debug.Log("树的高度: " + high2);

        Debug.Log("输出第4层的所有节点：");
        Debug.Log("---------非递归----判断 deepth==level-----");
        BinTree<int>.LayerOderPrintLevelNodes(root,4);
        BinTree<int>.DisPlayOutPut();

        Debug.Log("---------递归式----判断 Leve==1-----------");
        BinTree<int>.PrintLevelNodes(root, 4);
        BinTree<int>.DisPlayOutPut();






    }



}
