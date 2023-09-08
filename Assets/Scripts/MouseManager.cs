using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3>
{

}
//���е��඼��Ҫ�̳�MonoBehaviour�Żᱻ����
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
        //����������Ļ�ϵ�ת��Ϊ����
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //������ײ��Ϣ
        Physics.Raycast(ray, out hitInfo);
    }

    void MouseControl()
    {
        if (Input.GetMouseButtonDown(0) && hitInfo.collider != null)
        {
            if (hitInfo.collider.gameObject.CompareTag("Ground"))
            {
                //�������ж����� OnMouseClicked �¼��ĺ����������������λ����Ϊ�������ݸ���Щ����
                OnMouseClicked?.Invoke(hitInfo.point);
            }
        }
    }
}
