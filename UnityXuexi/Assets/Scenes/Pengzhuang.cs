using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pengzhuang : MonoBehaviour
{
    
    public GameObject XingXing;
    public GameObject XingXing1;
    public GameObject XingXing2;
    public GameObject XiaoQiu;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "XingXing")
        {
            XingXing.transform.position +=Vector3.up;
        }
        if (other.gameObject.tag == "XingXing2")
        {
            XingXing1.transform.position += Vector3.up;
        }
        if (other.gameObject.tag == "XingXing3")
        {
            XingXing2.transform.position += Vector3.up;
        }

    }




}
