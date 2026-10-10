using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 绑定至小方块上
public class Interpolation : MonoBehaviour
{
    public Vector3 curPos; // 当前位置
    public Vector3 startPos; // 起点位置
    public Vector3 endPos = new Vector3(0,0,30); // 最终点的位置
    public float startTime; // 开始运动的起始时间

    //----------新增的代码----------//
    public float easingModify = 2; // 缓动的修饰值
    //----------新增的代码----------//

    public Transform testCubeTransform; // 这个小方块将从初始位置运动到（0，0，10）

    public float timeDuration = 4f; // 插值过程（小方块移动到鼠标的位置这个过程）持续时间

    public bool canMove = false; // 是否可以移动

    private void Start()
    {
        // 获取小方块的Transform组件
        testCubeTransform = this.GetComponent<Transform>();
    }

    private void Update()
    {
        // 当按下空格键，可以开始测试；按下P键，退出测试并回到原点
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canMove = true;
            // 记录开始运动的时间
            startTime = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            canMove = false;
            testCubeTransform.position = new Vector3(0, 0, 0);
        }

        // 没开始测试就不计算这些插值
        if (!canMove)
        {
            return;
        }

        // 记录起始点
        startPos = testCubeTransform.position;

        // 计算u值
        float u = (Time.time - startTime) / timeDuration;

        

        // 限制u的值
        if (u >= 1)
        {
            u = 1;
            canMove = false;
        }

        //----------新增的代码----------//
        //float u2 = Mathf.Pow(u, easingModify);

        //float u2 = 1- Mathf.Pow(1-u, easingModify);

        //float u2 = u;
        //if (u <= 0.5)
        //{
        //    u2 = Mathf.Pow(u, easingModify);
        //}
        //else if(u>0.5)
        //{
        //    u2 = 1 - Mathf.Pow(1 - u, easingModify);
        //}

        //float u2 = u + easingModify * Mathf.Sin(Mathf.PI * u * 2);

        //float u2 = 1 - Mathf.Cos(Mathf.PI * 0.5f * u);

        float u2 = Mathf.Sin(Mathf.PI * 0.5f * u);
        //----------新增的代码----------//

        // 计算当前位置，将u换成u2测试缓动
        curPos = (1 - u2) * startPos + u2 * endPos;

        testCubeTransform.position = curPos;
        
    }
}
