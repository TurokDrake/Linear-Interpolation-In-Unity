using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolationBezier : MonoBehaviour
{
    public Transform cube; // 小方块

    // 三个点均在检查器面板设置
    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;

    public float startTime;
    public float timeDuration;
    public bool canMove;

    private void Update()
    {
        // 开始测试
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canMove = true;
            startTime = Time.time;
        }
        // 回到原点
        if (Input.GetKeyDown(KeyCode.P))
        {
            cube.position = Vector3.zero;
            canMove = false;
        }
        if (!canMove)
            return;

        float u = (Time.time - startTime) / timeDuration;

        if (u >= 1)
        {
            u = 1;
            canMove = false;
        }

        Vector3 pos12 = (1 - u) * pos1 + u * pos2;
        Vector3 pos23 = (1 - u) * pos2 + u * pos3;

        Vector3 pos123 = (1 - u) * pos12 + u * pos23;

        cube.position = pos123;

    }
}
