using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Transform cube; // 小方块的transform组件


    private void Update()
    {
        Vector3 mouseScreenPos = Input.mousePosition; // 鼠标屏幕坐标
        mouseScreenPos.z = 10; // 手动设置一下
        if (Input.GetKeyDown(KeyCode.S))
            Debug.Log(mouseScreenPos);

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos); // 将屏幕坐标转换成世界坐标
        if(Input.GetKeyDown(KeyCode.W))
            Debug.Log(mouseWorldPos);

        float u = 0.5f;

        cube.position = (1 - u) * cube.position + u * mouseWorldPos;
        


    }
}
