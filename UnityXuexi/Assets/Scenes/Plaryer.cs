using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plaryer : MonoBehaviour
{

    public Rigidbody ballRigidbody;

    public Transform cameraTransform;
    private float moveSpeed=5;
    public Vector3 cameraOffset;
    float mouseX;
    float mouseY;
    Vector3 currentRotation;
    Vector3 smoothRotation;
    

    private void Start()
    {
        currentRotation = cameraTransform.eulerAngles;
        smoothRotation = currentRotation;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 20;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 5;
        }
    }
    private void FixedUpdate()
    {
        // 获取用户输入
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, 0, 90);
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
  

        // 在小球上施加力
        ballRigidbody.AddForce(movement * moveSpeed);
    }

    private void LateUpdate()
    {
        // 确保相机保持相对于小球的偏移位置
        cameraTransform.position = ballRigidbody.position + cameraOffset;
        // 相机始终朝向小球的方向
        Vector3 lookDirection = ballRigidbody.velocity.normalized;
        // 确保只在小球移动时才更新相机的朝向
        if (lookDirection != Vector3.zero)
        {
            // 创建小球移动方向的旋转
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            // 平滑过渡相机的旋转到目标旋转
            cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, targetRotation, Time.deltaTime * moveSpeed);
        }
        
    }
}
