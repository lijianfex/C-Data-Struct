using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
/// <summary>
/// 栈的应用
/// </summary>
public class StackAppliction
{
    #region 1、括号匹配问题 :（{[]}）
    /// <summary>
    /// 括号匹配算法（栈的应用）
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public bool BracketMatch(string str)
    {
        Debug.Log(str);

        if (str == string.Empty||str==null)//校验字符括号是否为空
        {
            Debug.Log("字符括号为空！匹配失败！");
            return false;
        }

        LinkStack<char> stack = new LinkStack<char>(); //用来存储左括号(此处使用了之前自己定义的链栈结构)
        //Stack<char> stack = new Stack<char>();//系统提供的栈

        for (int i = 0; i < str.Length; i++)//读取括号字符串
        {
            switch (str[i])
            {
                case '(':
                case '[':
                case '{':
                    stack.Push(str[i]);//左括号进栈
                    break;
                case ')':
                case ']':
                case '}':
                    if (stack.IsEmpty())//使用系统提供的栈：stack.Count==0
                    {
                        Debug.Log("右括号   " + str[i] + "  多余！匹配失败！");
                        return false;
                    }
                    else
                    {
                        char left = stack.Peek();//访问左括号栈顶值

                        if (Match(left, str[i])) //判断左右括号类型
                        {
                            stack.Pop(); //匹配成功,出栈顶值
                        }
                        else
                        {
                            Debug.Log("左括号:  " + left + "  与右括号：   " + str[i] + "   不同类型！匹配失败！ ");
                            return false;
                        }
                    }
                    break;
                default:
                    Debug.Log(str[i] + "   不合法！匹配失败！ ");
                    return false;
            }
        }

        if (stack.IsEmpty())//使用系统提供的栈：stack.Count==0
        {
            Debug.Log("匹配成功！");
            return true;
        }
        
        Debug.Log("左括号:  " + stack.Peek() + "   多余！匹配失败！");
        return false;

    }

    /// <summary>
    /// 判断左括号与右括号是否同类型
    /// </summary>
    /// <param name="l">左括号</param>
    /// <param name="r">右括号</param>
    /// <returns></returns>
    private bool Match(char l, char r)
    {
        if ((l == '(') && (r == ')'))
        {
            return true;
        }
        if ((l == '[') && (r == ']'))
        {
            return true;
        }
        if ((l == '{') && (r == '}'))
        {
            return true;
        }
        return false;

    }

    #endregion

    


}


public class _010_StackAppliction : MonoBehaviour
{

    void Start()
    {


        StackAppliction appliction = new StackAppliction();



    }
}
