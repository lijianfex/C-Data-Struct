using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AVLTree
{
    //创建AVL：

    public static TreeNode<int> CreatAVLTree(int[] listData)
    {
        TreeNode<int> AVL = null;
        for (int i = 0; i < listData.Length; i++)
        {
            AVL = AVLTree.AVL_Insert(listData[i], AVL);
        }
        return AVL;
    }

    //AVL插入节点
    public static TreeNode<int> AVL_Insert(int data, TreeNode<int> T)
    {
        if (T == null)
        {
            T = new TreeNode<int>(data);
        }
        else if (data < T.Data) //向左子树插入
        {
            T.Left = AVL_Insert(data, T.Left);
            if(GetHeigth(T.Left)-GetHeigth(T.Right)==2)
            {
                if(data<T.Left.Data)
                {
                    T = SingleLeftRotation(T); //LL旋转（左单旋）
                }
                else
                {
                    T = DoubleLeftRightRotation(T);//LR旋转 (左-右双旋）
                }
            }

        } //插入左子树结束
        else if(data>T.Data) //插入 T 的右子树
        {
            T.Right = AVL_Insert(data, T.Right);
            if(GetHeigth(T.Left)-GetHeigth(T.Right)==-2)
            {
                if(data>T.Right.Data)
                {
                    T = SingleRightRotation(T);
                }
                else
                {
                    T = DoubleRightLeftRotation(T);
                }
            }
        }

        return T;
    }

    //AVL删除节点
    public static TreeNode<int> AVL_Delete(int data, TreeNode<int> T)
    {
        T= BinSerachTree.Delete(data, T);
        if (GetHeigth(T.Left) - GetHeigth(T.Right) == 2)
        {
            return DoubleLeftRightRotation(T);
        }
        if (GetHeigth(T.Left) - GetHeigth(T.Right) == -2)
        {
            return DoubleRightLeftRotation(T);
        }
        return T;

    }

    

    //得到树的高度
    private static int GetHeigth(TreeNode<int> T)
    {
        return BinTree<int>.LayerOderBinTreeHigh(T); 
    }

    //LL旋转（左单旋）
    private static TreeNode<int> SingleLeftRotation(TreeNode<int> A)
    {
        TreeNode<int> B = A.Left;
        A.Left = B.Right;
        B.Right = A;

        return B; 
    }

    //RR旋转（右单旋）
    private static TreeNode<int> SingleRightRotation(TreeNode<int> A)
    {
        TreeNode<int> B = A.Right;
        A.Right = B.Left;
        B.Left = A;
        return B;
    }

    //LR旋转 (左-右双旋）
    private static TreeNode<int> DoubleLeftRightRotation(TreeNode<int> A)
    {
        A.Left = SingleRightRotation(A.Left);
        return SingleLeftRotation(A);
    }

    //RL旋转 (右-左双旋）
    private static TreeNode<int> DoubleRightLeftRotation(TreeNode<int> A)
    {
        A.Right = SingleLeftRotation(A.Right);
        return SingleRightRotation(A);
    }


}


/// <summary>
/// 平衡二叉树
/// </summary>
public class _019_AVLTree : MonoBehaviour
{
    private string avlTree = @"
                      8
                    /   \
                  2      17
                / \     /   \
               0   4   14   18
                      / \     \
                    12   16    19
                     
                            ";

    void Start()
    {
        int[] listData = new int[] { 2, 18, 8, 19, 0, 17, 14, 4, 12, 16 };

        //创建二叉搜索树：
        Debug.Log("创建平衡二叉树---------数组:{ 2 ,18 ,8 ,19 ,0 ,17 ,14 ,4, 12 ,16 } ");
        TreeNode<int> AVL = AVLTree.CreatAVLTree(listData);
        Debug.Log("平衡二叉树:" + "\n" + avlTree);

        Debug.Log("先序遍历：");
        BinTree<int>.PreOrderTraversal(AVL);
        BinTree<int>.DisPlayOutPut();

        Debug.Log("中序遍历：");
        BinTree<int>.InOrderTraversal(AVL);
        BinTree<int>.DisPlayOutPut();

        Debug.Log("层序遍历：");
        BinTree<int>.LayerOrderTraversal(AVL);
        BinTree<int>.DisPlayOutPut();

        //查找
        Debug.Log("查找:14");
        TreeNode<int> node = BinSerachTree.IterFind(14, AVL);
        Debug.Log(" 14的左孩子：" + node.Left.Data + "  ,  14的右孩子是：" + node.Right.Data);

        //找最小
        Debug.Log("查找最小");
        TreeNode<int> minNode = BinSerachTree.IterFindMin(AVL);
        Debug.Log(minNode.Data);

        //找最大
        Debug.Log("查找最大");
        TreeNode<int> maxNode = BinSerachTree.IterFindMax(AVL);
        Debug.Log(maxNode.Data);

        Debug.Log("输出第3层的所有节点：");       
        BinTree<int>.LayerOderPrintLevelNodes(AVL, 3);
        BinTree<int>.DisPlayOutPut();

        //插入5
        Debug.Log("插入5");
        AVL = AVLTree.AVL_Insert(5, AVL);

        Debug.Log("先序遍历：");
        BinTree<int>.PreOrderTraversal(AVL);
        BinTree<int>.DisPlayOutPut();

        //删除5
        Debug.Log("删除5");
        AVL= AVLTree.AVL_Delete(5, AVL);

        Debug.Log("先序遍历：");
        BinTree<int>.PreOrderTraversal(AVL);
        BinTree<int>.DisPlayOutPut();

        //删除0
        Debug.Log("删除0");
        AVL = AVLTree.AVL_Delete(0, AVL);

        Debug.Log("先序遍历：");
        BinTree<int>.PreOrderTraversal(AVL);
        BinTree<int>.DisPlayOutPut();

        //删除4
        Debug.Log("删除4");
        AVL = AVLTree.AVL_Delete(4, AVL);
       

        Debug.Log("先序遍历：");
        BinTree<int>.PreOrderTraversal(AVL);
        BinTree<int>.DisPlayOutPut();
    }

}
