using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3>
{

}
//所有的类都需要继承MonoBehaviour才会被调用
public class MouseManager : MonoBehaviour
{
    public EventVector3 OnMouseClicked;
    public RaycastHit hitInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetCursorTexture();
        MouseControl();
    }

    void SetCursorTexture()
    {
        //将鼠标点在屏幕上的转化为射线
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //返回碰撞信息
        Physics.Raycast(ray, out hitInfo);
    }

    void MouseControl()
    {
        if (Input.GetMouseButtonDown(0) && hitInfo.collider != null)
        {
            if (hitInfo.collider.gameObject.CompareTag("Ground"))
            {
                //触发所有订阅了 OnMouseClicked 事件的函数，并将鼠标点击的位置作为参数传递给这些函数
                OnMouseClicked?.Invoke(hitInfo.point);
            }
        }
    }
}
