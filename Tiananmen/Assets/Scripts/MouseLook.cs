using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class MouseLook : MonoBehaviour
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
    bool ishit = true;
     GameObject a;
    RaycastHit hit1;
    #endregion
    private void Awake()
    {
        UnityEngine.XR.XRSettings.enabled = false;
    }
    void Start()
    {
        if (tourCamera == null) tourCamera = gameObject.transform;
        // 防止相机边缘穿透
        if (tourCamera.GetComponent<Camera>().nearClipPlane > minDistance / 3)
        {
            tourCamera.GetComponent<Camera>().nearClipPlane /= 3;
        }
    }
    void Update()
    {
        GetDirection();
        // 检测是否离不可穿透表面过近
        RaycastHit hit;
        //if (Physics.Raycast(tourCamera.position, direction, out hit, minDistance))
        //{
        //    if (hit.collider.gameObject != null)
        //    {
        //        //if (hit.collider.gameObject.layer == 9)
        //        //{
        //        //    return;
        //        //}

        //            float angel = Vector3.Angle(direction, hit.normal);
        //            float magnitude = Vector3.Magnitude(direction) * Mathf.Cos(Mathf.Deg2Rad * (180 - angel));
        //            direction += hit.normal * magnitude;
        //            Debug.Log(hit.collider.gameObject.layer);

        //    }
        //}
        //while (Physics.Raycast(tourCamera.position, direction, out hit, minDistance))
        //{
        //    if (hit.collider.gameObject != null)
        //    {
        //        if (hit.collider.gameObject.layer == 10)
        //        {
        //            float angel = Vector3.Angle(direction, hit.normal);
        //            float magnitude = Vector3.Magnitude(direction) * Mathf.Cos(Mathf.Deg2Rad * (180 - angel));
        //            direction += hit.normal * magnitude;
        //            Debug.Log(hit.collider.gameObject.layer);
        //        }
        //        else
        //        {
        //            hit.collider.gameObject.SetActive(false);
        //            a = hit.collider.gameObject;
        //            Invoke(nameof(daly), 0.5f);
        //        }
        //    }
        //    // 消去垂直于不可穿透表面的运动速度分量

        //}
        while (Physics.Raycast(tourCamera.position, direction, out hit, minDistance))
        {
            if (hit.collider.gameObject != null)
            {

                float angel = Vector3.Angle(direction, hit.normal);
                float magnitude = Vector3.Magnitude(direction) * Mathf.Cos(Mathf.Deg2Rad * (180 - angel));
                direction += hit.normal * magnitude;

            }
            // 消去垂直于不可穿透表面的运动速度分量

        }
        // if (ishit)
        tourCamera.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.Return)) SetEnemyNum();
       // if (Input.GetKey(KeyCode.Escape)) Application.Quit();
        //OnRaycastHit();
    }
   


    void daly()
    {
        ishit = true;
        a.SetActive(true);
    }
    //場景跳轉
    void SetEnemyNum()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index == 0)
        {
            SceneManager.LoadScene(1);
        }
        //if (index == 1)
        //{
        //    SceneManager.LoadScene(0);
        //}
    }

    private void GetDirection()
    {
        #region 加速移动
        if (Input.GetKeyDown(KeyCode.LeftShift)) moveSpeed *= shiftRate;
        if (Input.GetKeyUp(KeyCode.LeftShift)) moveSpeed /= shiftRate;
        #endregion
        #region 键盘移动
        // 复位
        speedForward = Vector3.zero;
        speedBack = Vector3.zero;
        speedLeft = Vector3.zero;
        speedRight = Vector3.zero;
        speedUp = Vector3.zero;
        speedDown = Vector3.zero;
        // 获取按键输入
        if (Input.GetKey(KeyCode.W)) speedForward = tourCamera.forward;
        if (Input.GetKey(KeyCode.S)) speedBack = -tourCamera.forward;
        if (Input.GetKey(KeyCode.A)) speedLeft = -tourCamera.right;
        if (Input.GetKey(KeyCode.D)) speedRight = tourCamera.right;
        if (Input.GetKey(KeyCode.E)) speedUp = Vector3.up;
        if (Input.GetKey(KeyCode.Q)) speedDown = Vector3.down;
        direction = speedForward + speedBack + speedLeft + speedRight + speedUp + speedDown;
        #endregion
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
   

    void OnRaycastHit()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("xxxxxxxxxxxxxxxxxxxxxx");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//从摄像机发出到点击坐标的射线
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.DrawLine(ray.origin, hitInfo.point);//划出射线，在scene视图中能看到由摄像机发射出的射线
                GameObject gameObj = hitInfo.collider.gameObject;
                if (gameObj.layer==11)//当射线碰撞目标的name包含Cube，执行拾取操作
                {
                    Debug.Log(gameObj.name);
                }
            }
        } 



    }
}
