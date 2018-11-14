using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class BinSerachTree
{
    //0.创建：

    ////非递归插入创建
    //public static TreeNode<int> IterCreatBinSerachTree(int[] listData)
    //{
    //    TreeNode<int> BST = null;
    //    for(int i=0;i<listData.Length;i++)
    //    {
    //       BST = BinSerachTree.IterInsert(listData[i], BST);
    //    }
    //    return BST;
    //}
    //递归插入创建
    public static TreeNode<int> CreatBinSerachTree(int[] listData)
    {
        TreeNode<int> BST = null;
        for (int i = 0; i < listData.Length; i++)
        {
            BST = BinSerachTree.Insert(listData[i], BST);
        }
        return BST;
    }

    //1.查找：

    //非递归
    public static TreeNode<int> IterFind(int data, TreeNode<int> BST)
    {
        while (BST != null)
        {
            if (data > BST.Data)
            {
                BST = BST.Right;
            }
            else if (data < BST.Data)
            {
                BST = BST.Left;
            }
            return BST;
        }
        return null;
    }
    //递归式
    public static TreeNode<int> Find(int data, TreeNode<int> BST)
    {
        if (BST == null) return null;
        if (data > BST.Data)
        {
            return Find(data, BST.Right);//尾递归
        }
        else if (data < BST.Data)
        {
            return Find(data, BST.Left);
        }
        else
        {
            return BST;
        }
    }

    //2.找最小：

    //非递归
    public static TreeNode<int> IterFindMin(TreeNode<int> BST)
    {
        if (BST != null)
        {
            while (BST.Left != null)
            {
                BST = BST.Left;
            }
        }
        return BST;
    }
    //递归式
    public static TreeNode<int> FindMin(TreeNode<int> BST)
    {
        if (BST == null)
        {
            return null;
        }
        else if (BST.Left == null)
        {
            return BST;
        }
        else
        {
            return FindMin(BST.Left);
        }


    }

    //3.找最大：

    //非递归
    public static TreeNode<int> IterFindMax(TreeNode<int> BST)
    {

        if (BST != null)
        {
            while (BST.Right != null)
            {
                BST = BST.Right;
            }
        }
        return BST;
    }
    //递归式
    public static TreeNode<int> FindMax(TreeNode<int> BST)
    {
        if (BST == null)
        {
            return null;
        }
        else if (BST.Right == null)
        {
            return BST;
        }
        else
        {
            return FindMax(BST.Right);
        }
    }

    //4.插入值
    //非递归
    //public static TreeNode<int> IterInsert(int data, TreeNode<int> BST)
    //{

    //    if (BST == null)
    //    {
    //       BST = new TreeNode<int>(data);
    //    }
    //    else
    //    {
    //        TreeNode<int> temp = new TreeNode<int>(BST.Data, BST.Left, BST.Right);
    //        while (true)
    //        {
    //            if (data < temp.Data)
    //            {
    //                if (temp.Left == null)
    //                {
    //                    BinSerachTree.IterFind(temp.Data, BST).Left = new TreeNode<int>(data);
    //                }
    //                temp = temp.Left;
    //            }
    //            else if (data > temp.Data)
    //            {
    //                if (temp.Right == null)
    //                {
    //                    BinSerachTree.IterFind(temp.Data, BST).Right = new TreeNode<int>(data);
    //                }
    //                temp = temp.Right;
    //            }
    //            else
    //            {
    //                break;
    //            }

    //        }
    //    }
    //    return BST;
    //}
    //递归式

    public static TreeNode<int> Insert(int data, TreeNode<int> BST)
    {
        if (BST == null)
        {
            BST = new TreeNode<int>(data);
        }
        else
        {
            if (data < BST.Data)
            {
                BST.Left = Insert(data, BST.Left);
            }
            else if (data > BST.Data)
            {
                BST.Right = Insert(data, BST.Right);
            }
        }
        return BST;
    }

    //5.删除值
    public static TreeNode<int> Delete(int data, TreeNode<int> BST)
    {
        if (BST == null)
        {
            Debug.Log("未找到要删除的元素！");
        }
        else if (data < BST.Data)
        {
            BST.Left = Delete(data, BST.Left); //左子树递归删除
        }
        else if (data > BST.Data)
        {
            BST.Right = Delete(data, BST.Right); //右子树递归删除
        }
        else //找到删除的节点
        {
            if (BST.Left != null && BST.Right != null) //被删除的节点，有左右两个儿子
            {
                BST.Data = FindMin(BST.Right).Data; //在右子树中找最小的元素填充删除结点
                BST.Right = Delete(BST.Data, BST.Right);
            }
            else //被删节点有一个或无节点孩子
            {
                if(BST.Left==null) //有右孩子或无子结点
                {
                    BST = BST.Right;
                }
                else if(BST.Right==null) //有左孩子或无子结点
                {
                    BST = BST.Left;
                }                
            }
        }
        return BST;
    }



}

/// <summary>
/// 二叉搜索树
/// </summary>
public class _018_BinSerachTree : MonoBehaviour
{
    private string tree = @"
                    2
                   / \
                  0   18
                      / \
                     8   19
                    / \
                   4   17
                      / 
                     14
                    /  \
                   12   16
                            ";


    void Start()
    {
        int[] listData = new int[] { 2, 18, 8, 19, 0, 17, 14, 4, 12, 16 };

        //创建二叉搜索树：
        Debug.Log("创建二叉搜索树---------数组:{ 2 ,18 ,8 ,19 ,0 ,17 ,14 ,4, 12 ,16 } ");
        TreeNode<int> BST = BinSerachTree.CreatBinSerachTree(listData);
        Debug.Log("二叉搜索树:" + "\n" + tree);

        Debug.Log("先序遍历：");
        BinTree<int>.PreOrderTraversal(BST);
        BinTree<int>.DisPlayOutPut();

        Debug.Log("中序遍历：");
        BinTree<int>.InOrderTraversal(BST);
        BinTree<int>.DisPlayOutPut();

        Debug.Log("层序遍历：");
        BinTree<int>.LayerOrderTraversal(BST);
        BinTree<int>.DisPlayOutPut();

        //查找
        Debug.Log("查找:18");
        TreeNode<int> node = BinSerachTree.IterFind(18, BST);
        Debug.Log(" 18的左孩子：" + node.Left.Data + "  ,  18的右孩子是：" + node.Right.Data);

        //找最小
        Debug.Log("查找最小");
        TreeNode<int> minNode = BinSerachTree.IterFindMin(BST);
        Debug.Log(minNode.Data);

        //找最大
        Debug.Log("查找最大");
        TreeNode<int> maxNode = BinSerachTree.IterFindMax(BST);
        Debug.Log(maxNode.Data);

        //插入5
        Debug.Log("插入5");
        BinSerachTree.Insert(5, BST);

        Debug.Log("先序遍历：");
        BinTree<int>.PreOrderTraversal(BST);
        BinTree<int>.DisPlayOutPut();

        //删除5
        Debug.Log("删除5");
        BinSerachTree.Delete(5, BST);

        Debug.Log("先序遍历：");
        BinTree<int>.PreOrderTraversal(BST);
        BinTree<int>.DisPlayOutPut();
    }



}
