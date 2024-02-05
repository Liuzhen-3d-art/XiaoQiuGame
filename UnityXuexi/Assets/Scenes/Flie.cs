using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Flie : MonoBehaviour
{
    public GameObject XBox;
    public Vector3 BoxZuoBiao;
    private string filePath;
    private float times;

    // Start is called before the first frame update
    void Start()
    {
        BoxZuoBiao = XBox.transform.position;
        filePath = Application.dataPath + "/Scenes/RiZhi.txt";
    }

    // Update is called once per frame
    void Update()
    {
        times += Time.deltaTime;
        Debug.LogAssertion(times);
        if (XBox.transform.position != BoxZuoBiao && times >= 5f)
        {
            BoxZuoBiao = XBox.transform.position; // Update the stored position
            string abc = BoxZuoBiao.ToString();
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(abc);
            }
            Debug.Log("记录一次内容");
            times = 0; // Reset the timer
        }
    }
}

