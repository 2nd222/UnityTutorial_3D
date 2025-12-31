using System;
using System.Collections.Generic;
using UnityEngine;

public class StudyFunc : MonoBehaviour
{
    // public Func<int, int, int> myFunc;
    //
    // void Start()
    // {
    //     myFunc += AddMethod;
    //     myFunc += MinusMethod;
    //
    //     int result = myFunc.Invoke(10, 7);
    //     
    //     Debug.Log($"최종 결과: {result }"); //result는 맨 마지막에 반환된 거만
    // }
    //
    // private int AddMethod(int num1, int num2)
    // {
    //     Debug.Log("Add");
    //     return num1 + num2;
    // }
    //
    // private int MinusMethod(int num1, int num2)
    // {        
    //     Debug.Log("Minus");
    //     return num1 - num2;
    // }
    
    private List<Func<int, int, int>> funcList = new List<Func<int, int, int>>();

    void Start()
    {
        funcList.Add(AddMethod);
        funcList.Add(MinusMethod);
        funcList.Add(MultiplyMethod);
        funcList.Add((a, b) => a + b);

        int result = 0;
        foreach (var func in funcList)
        {
            result += func(5, 2);
        }

        Debug.Log($"최종 결과: {result}");
    }

    private int AddMethod(int a, int b)
    {
        return a + b;
    }
    
    private int MinusMethod(int a, int b)
    {
        return a - b;
    }
    
    private int MultiplyMethod(int a, int b)
    {
        return a * b;
    }
}
