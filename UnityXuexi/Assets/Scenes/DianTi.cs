using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianTi : MonoBehaviour
{
    public GameObject diantiT;
    private float time_=-0.7f;
    int Key = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DianTi")) // 使用CompareTag而不是直接比较字符串，这样更高效
        {
            Key = 1;
            Debug.Log("进入了电梯" + Key);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DianTi")) // 使用CompareTag而不是直接比较字符串，这样更高效
        {
            Key = 2;
            Debug.Log("离开了电梯" + Key);
        }
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        // 如果电梯被激活上升（Key == 1）且未达到最大高度（5f），则递增 time_
        if (Key == 1 && diantiT.transform.position.y < 5f)
        {
            time_ += Time.deltaTime; // 使用 Time.deltaTime 保证平滑上升，而且不依赖于帧率
        }
        // 如果电梯被激活下降（Key == 2）且未达到最低高度（-0.7f），则递减 time_
        else if (Key == 2 && diantiT.transform.position.y > -0.7f)
        {
            time_ -= Time.deltaTime; // 使用 Time.deltaTime 保证平滑下降
        }

        // Clamp time_ to make sure it stays within the desired range
        time_ = Mathf.Clamp(time_,- 0.7f, 5f);

        // 仅在 Y 轴上增加位置，基于 time_ 的值更新电梯的位置
        diantiT.transform.position = new Vector3(diantiT.transform.position.x, time_, diantiT.transform.position.z);
    }
}
