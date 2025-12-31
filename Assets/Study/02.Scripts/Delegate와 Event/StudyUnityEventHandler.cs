using System;
using UnityEngine;
using UnityEngine.Events;

public class DataClass : EventArgs
{
    public string dataName;

    public DataClass(string dataName)
    {
        this.dataName = dataName;
    }
}

public class StudyUnityEventHandler : MonoBehaviour
{
    private event EventHandler<DataClass> handler;

    void Start()
    {
        DataClass data1 = new DataClass("Hello");
        DataClass data2 = new DataClass("Unity");

        handler += StartEvent;

        handler?.Invoke(this, data1);
        handler?.Invoke(this, data2);
    }
    
    private void StartEvent(object o, DataClass e) // handler에서 타입 정하면 eventarg대신 dataclass라고 적어도 됨
    {
        var data = e;
        Debug.Log($"Data Name : {data.dataName}");
    }
    
    // private event EventHandler handler;
    // public event EventHandler Handler
    // {
    //     add
    //     {
    //         Debug.Log($"{value.Method} 추가됨");
    //         handler += value;
    //     }
    //     remove
    //     {
    //         Debug.Log($"{value.Method} 삭제됨");
    //         handler -= value;
    //     }
    // }
    //
    // void OnEnable() //키고 끌 때 꼬이지 않게 꺼져있을때 콜하지 않게
    // {
    //     Handler += MethodA;
    // }
    //
    // void OnDisable()
    // {
    //     Handler -= MethodA;
    // }
    //
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //         handler?.Invoke(this, EventArgs.Empty);
    // }
    //
    // /// <param name="o">이벤트를 실행하는 객체</param>
    // /// <param name="e">이벤트 실행시 전달한 이벤트 변수</param>
    // public void MethodA(object o, EventArgs e)
    // {
    //     Debug.Log("Hello");
    // }
}
