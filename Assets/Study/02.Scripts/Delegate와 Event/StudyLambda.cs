using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudyLambda : MonoBehaviour
{
    #region Anonymous

    //익명 함수로 만든 버전
    // public delegate void MyDelegate(string s);
    // public MyDelegate myDelegate;
    // void Start()
    // {
    //     myDelegate += delegate(string s) //매개변수 있는 버전
    //     {
    //         Debug.Log(s);
    //     };
    //
    //     myDelegate?.Invoke("Hello Unity");
    // }
    
    //익명함수 + 매개변수 업느버전
    // public delegate void MyDelegate();
    // public MyDelegate myDelegate;
    // void Start()
    // {
    //     myDelegate += delegate
    //     {
    //         Debug.Log("Hello Unity");
    //     };
    //
    //     myDelegate?.Invoke();
    // }
    

    #endregion
    #region Lambda
    //람다식으로 만든 버전
    // public delegate void MyDelegate();
    // public MyDelegate myDelegate;
    //
    // void Start()
    // {
    //     myDelegate += () => Debug.Log("Hello Unity");
    //
    //     myDelegate?.Invoke();
    // }

    // 람다식 + 매개변수
    // public delegate void MyDelegate(string s);
    // public MyDelegate myDelegate;
    //
    // void Start()
    // {
    //     myDelegate += (s) => Debug.Log(s);
    //
    //     myDelegate?.Invoke("Hello World");
    // }
    
    // 람다식 + 여러줄
    // public delegate void MyDelegate();
    // public MyDelegate myDelegate;
    //
    // void Start()
    // {
    //     myDelegate += () =>
    //     {
    //         Debug.Log("Hello");
    //         Debug.Log("Unity");
    //     };
    //
    //     myDelegate?.Invoke();
    // }
    
    // 람다식 + 여러줄 + 매개변수
    // public delegate void MyDelegate(string s);
    // public MyDelegate myDelegate;
    //
    // void Start()
    // {
    //     myDelegate += (s) =>
    //     {
    //         Debug.Log(s);
    //         Debug.Log("Lambda");
    //     };
    //
    //     myDelegate?.Invoke("Hello World");
    // }
    #endregion
    
    // public Button buttonUI;
    //
    // void Start()
    // {
    //     buttonUI.onClick.AddListener(() =>
    //     {
    //         OnLog("Hello");
    //         OnLog2("aa");
    //         OnLog3("bb");
    //     });
    // }
    //
    // private void OnLog(string msg)
    // {
    //     Debug.Log(msg);
    // }
    // private void OnLog2(string msg)
    // {
    //     Debug.Log(msg);
    // }
    // private void OnLog3(string msg)
    // {
    //     Debug.Log(msg);
    // }

    
    // lambda 이용해서 list에서 홀수 지우는 방법
    // public List<int> intList = new List<int>();
    // void Start()
    // {
    //     for (int i = 0; i < 10; i++)
    //         intList.Add(i + 1);
    //     intList.Sort(); // 오름차순
    //     intList.RemoveAll((n) => n % 2 != 0); //2로 나눠서 나머지가 0이 아닌 것들 removeall
    // }
    
    public Button[] buttonUIs;

    void Start()
    {
        for (int i = 0; i < buttonUIs.Length; i++)
        {
            int j = i; // Closure 이슈 방지 만약 i를 그대로 넣으면 setbutton(length)만 length번 실행됨
            buttonUIs[i].onClick.AddListener(() => SetButton(j));
        }
    }
    
    private void SetButton(int index)
    {
        Debug.Log($"Index : " + index);
    }
}
