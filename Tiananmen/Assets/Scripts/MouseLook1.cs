using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseLook1 : MonoBehaviour
{
    public Transform tourCamera;
    #region 相机移动参数
    public float moveSpeed = 1.0f;
    public float rotateSpeed = 90.0f;
    public float shiftRate = 2.0f;// 按住Shift加速
    public float minDistance = 0.5f;// 相机离不可穿过的表面的最小距离（小于等于0时可穿透任何表面）
    #endregion
    #region 运动速度和其每个方向的速度分量
    private Vector3 direction = Vector3.zero;
    private Vector3 speedForward;
    private Vector3 speedBack;
    private Vector3 speedLeft;
    private Vector3 speedRight;
    private Vector3 speedUp;
    private Vector3 speedDown;
    #endregion
    void Start()
    {
        if (tourCamera == null) tourCamera = gameObject.transform;
        // 防止相机边缘穿透
        //if (tourCamera.GetComponent<Camera>().nearClipPlane > minDistance / 3)
        //{
        //    tourCamera.GetComponent<Camera>().nearClipPlane /= 3;
        //}
    }
    void Update()
    {
        GetDirection();
       // if (Input.GetKey(KeyCode.Escape)) Application.Quit();


    }

    //場景跳轉
    void SetEnemyNum()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index == 0)
        {
            SceneManager.LoadScene(1);
        }
        if (index == 1)
        {
            SceneManager.LoadScene(0);
        }
    }
    private void GetDirection()
    {
        
        #region 鼠标旋转
        if (Input.GetMouseButton(1))
        {
            // 转相机朝向
            tourCamera.RotateAround(tourCamera.position, Vector3.up, Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime);
            tourCamera.RotateAround(tourCamera.position, tourCamera.right, -Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime);
            // 转运动速度方向
            direction = V3RotateAround(direction, Vector3.up, Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime);
            direction = V3RotateAround(direction, tourCamera.right, -Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime);
        }
        #endregion
    }

    public Vector3 V3RotateAround(Vector3 source, Vector3 axis, float angle)
    {
        Quaternion q = Quaternion.AngleAxis(angle, axis);// 旋转系数
        return q * source;// 返回目标点
    }
}
