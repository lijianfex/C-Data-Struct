using System;
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
        if (str == string.Empty || str == null)//校验字符括号是否为空
        {
            Debug.Log("字符括号为空！括号匹配失败！");
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
                        Debug.Log("右括号   " + str[i] + "  多余！括号匹配失败！");
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
                            Debug.Log("左括号:  " + left + "  与右括号：   " + str[i] + "   不同类型！括号匹配失败！ ");
                            return false;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        if (stack.IsEmpty())//使用系统提供的栈：stack.Count==0
        {
            Debug.Log("括号匹配成功！");
            return true;
        }

        Debug.Log("左括号:  " + stack.Peek() + "   多余！括号匹配失败！");
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

    #region 2、表达式求值:  "5 * ( ( 3 + 7 )+(3*2)^2 ) - 4 / 2"
    //2、表达式求值：
    public int ExpEvaluation(string middleExp)
    {


        //1、将str 中缀表达式转为后缀表达式
        string TrailExp = ToTrailExp(middleExp);


        //2、对后缀表达式进行求值操作
        return TrailExpEvalution(TrailExp);

    }

    /// <summary>
    /// 中缀表达式转为后缀表达式
    /// </summary>
    /// <param name="str">中缀表达式</param>
    /// <returns>后缀表达式</returns>
    public string ToTrailExp(string str)
    {
        string traiExp = null;

        if (str == null || str == string.Empty)//校验str是否空
        {
            return null;
        }


        if (!BracketMatch(str))//判断是否平衡圆括号
        {
            Debug.Log("表达式的圆括号不平衡，表达式有误！");
            return null;
        }

        Stack<char> optrStack = new Stack<char>(); //操作符栈

        for (int i = 0; i < str.Length; i++)
        {
            switch (str[i])
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    traiExp += str[i];
                    break;
                case ' ':
                    break;
                case '+':
                case '-':
                case '*':
                case '/':
                case '^':
                    if (optrStack.Count == 0)
                    {
                        optrStack.Push(str[i]);
                    }
                    else
                    {
                        char op = optrStack.Peek();
                        if (op == '(')
                        {
                            optrStack.Push(str[i]);
                        }
                        else
                        {
                            if (Priority(str[i]) <= Priority(op))
                            {
                                traiExp += optrStack.Pop();
                                optrStack.Push(str[i]);
                            }
                            else
                            {
                                optrStack.Push(str[i]);
                            }
                        }
                    }
                    break;
                case '('://碰到左括号，直接入栈
                    optrStack.Push(str[i]);
                    break;
                case ')': //一直出栈至首次出栈的"("
                    while (optrStack.Count > 0 && optrStack.Peek() != '(')
                    {
                        traiExp += optrStack.Pop();
                    }
                    if (optrStack.Count != 0)
                    {
                        optrStack.Pop();
                    }
                    break;
                default:
                    break;
            }
        }

        while (optrStack.Count != 0) //把剩余操作符出栈并输出
        {
            traiExp += optrStack.Pop();
        }

        return traiExp;

    }

    /// <summary>
    /// 判断操作符的优先级
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    private int Priority(char c)
    {
        switch (c)
        {
            case '+':
            case '-':
                return 1;
            case '*':
            case '/':
                return 2;
            case '^':
                return 3;
            default:
                return -1;
        }
    }


    /// <summary>
    /// 对后缀表达式进行求值操作
    /// </summary>
    /// <param name="trailExp">后缀表达式</param>
    /// <returns>结果</returns>
    public int TrailExpEvalution(string trailExp)
    {
        if (trailExp == null || trailExp == string.Empty) //校验是否空
        {
            return -1;
        }

        Stack<int> numStack = new Stack<int>();

        for (int i = 0; i < trailExp.Length; i++)
        {
            int n1, n2;

            switch (trailExp[i])
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    numStack.Push(int.Parse(trailExp[i].ToString()));
                    break;
                case ' ':
                    break;
                case '+':
                    n1 = numStack.Pop();
                    n2 = numStack.Pop();
                    numStack.Push(n1 + n2);
                    break;
                case '-':
                    n1 = numStack.Pop();//减数
                    n2 = numStack.Pop();//被减数
                    numStack.Push(n2 - n1);
                    break;
                case '*':
                    n1 = numStack.Pop();
                    n2 = numStack.Pop();
                    numStack.Push(n2 * n1);
                    break;
                case '/':
                    n1 = numStack.Pop();//除数
                    n2 = numStack.Pop();//被除数
                    numStack.Push(n2 / n1);
                    break;
                case '^':
                    n1 = numStack.Pop();//幂数
                    n2 = numStack.Pop();//低数
                    numStack.Push((int)Math.Pow(n2, n1));
                    break;
                default:
                    break;
            }
        }
        return numStack.Pop();
    }

    #endregion




}



public class _010_StackAppliction : MonoBehaviour
{

    void Start()
    {


        StackAppliction appliction = new StackAppliction();

        //print(appliction.BracketMatch(null));

        //print(appliction.BracketMatch(""));

        //print(appliction.BracketMatch("({})"));

        //print(appliction.BracketMatch("({fsd[f}af)"));

        //print(appliction.BracketMatch("(af{af}"));

        //print(appliction.BracketMatch("af{af}sf)af"));

        //print(appliction.BracketMatch("(dfgd{q)"));

        //print("判断是否平衡圆括号---------------");

        //print("是否平衡圆括号:" + appliction.BracketMatch("()()"));
        //print("是否平衡圆括号:" + appliction.BracketMatch("())"));
        //print("是否平衡圆括号:" + appliction.BracketMatch("(((((())))))"));

        string str = "5 * ( ( 3 + 7 )+(3*2)^2 ) - 4 / 2";

        print("中缀表达式： " + str);

        print("后缀表达式： " + appliction.ToTrailExp(str));

        print("表达式结果： " + appliction.ExpEvaluation(str));



    }
}

