using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Distance : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform a;
    //public int i;
    public float Distance_forward/*, Distance_right*/;
    float dis;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(a.position, transform.position);
        Debug.Log(dis);
       if(dis<= Distance_forward)
        {
            SceneManager.LoadScene(1);
        }
        //checkTargetDirForMe(a);
        ////Debug.Log(checkTargetDirForMe(a));
        ////checForMe();
        //if (dis > Distance_forward && dis > Distance_right)
        //{
        //    if (PlayYP.Instantiate == null)
        //        return;
        //    if (PlayYP.Instantiate.i == i)
        //    {
        //        PlayYP.Instantiate.i = -1;
        //        PlayYP.Instantiate.OnStop();
        //    }
        //}
    }
    public float checkTargetDirForMe(Transform target)
    {
        //xuqiTest：  target.position = new Vector3(3, 0, 5);  
        Vector3 dir = transform.position - target.position; //位置差，方向  
                                                            //方式1   点乘  
                                                            //点积的计算方式为: a·b =| a |·| b | cos < a,b > 其中 | a | 和 | b | 表示向量的模 。  
                                                            //float dot = Vector3.Dot(transform.forward, dir.normalized);//点乘判断前后：dot >0在前，<0在后
                                                            //float dot1 = Vector3.Dot(transform.right, dir.normalized);//点乘判断左右： dot1>0在右，<0在左
                                                            // float angle = Mathf.Acos(Vector3.Dot(transform.forward.normalized, dir.normalized)) * Mathf.Rad2Deg;//通过点乘求出夹角  
        float dot = Vector3.Dot(target.forward, dir.normalized);//点乘判断前后：dot >0在前，<0在后
        float dot1 = Vector3.Dot(target.right, dir.normalized);//点乘判断左右： dot1>0在右，<0在左
        float angle = Mathf.Acos(Vector3.Dot(dir.normalized, target.forward.normalized)) * Mathf.Rad2Deg;//通过点乘求出夹角  

        if (checForMe())
        {
            if (dot > 0)
            {
                // Debug.Log("在前面");
                if (dis <= Distance_forward)
                {
                   
                }
                if (dot1 > 0)
                {

                    // Debug.Log("在右");
                  
                }
                else
                {
                    //  Debug.Log("在左");
                   
                }
            }
        }
        else
        {
            
        }
        if (dot < 0)
        {
            
        }
       


        //if (dot1 > 0)
        //{

        //    // Debug.Log("在右");
        //    if (dis <= Distance_right)
        //    {
        //        if (PlayYP.Instantiate.i != i)
        //        {
        //            PlayYP.Instantiate.i = i;
        //        }
        //        if (!PlayYP.Instantiate.isPlay)
        //        {
        //            PlayYP.Instantiate.OnPlay();
        //        }
        //    }
        //}
        //else
        //{
        //    //  Debug.Log("在左");
        //    if (dis <= Distance_right)
        //    {
        //        if (PlayYP.Instantiate.i != i)
        //        {
        //            PlayYP.Instantiate.i = i;
        //        }
        //        if (!PlayYP.Instantiate.isPlay)
        //        {
        //            PlayYP.Instantiate.OnPlay();
        //        }
        //    }
        //}
        //Debug.Log("1:   " + angle);
        //方式2   叉乘  
        //叉乘满足右手准则  公式：模长|c|=|a||b|sin<a,b>    
        //Vector3 cross = Vector3.Cross(transform.forward, dir.normalized);//叉乘判断左右：cross.y>0在左，<0在右   
        //Vector3 cross1 = Vector3.Cross(transform.right, dir.normalized); //叉乘判断前后：cross.y>0在前，<0在后   
        //angle = Mathf.Asin(Vector3.Distance(Vector3.zero, Vector3.Cross(transform.forward.normalized, dir.normalized))) * Mathf.Rad2Deg;
        return angle;
    }

    public bool checForMe()
    {
        //xuqiTest：  target.position = new Vector3(3, 0, 5);  
        Vector3 dir = a.position - transform.position; //位置差，方向  
                                                            //方式1   点乘  
                                                            //点积的计算方式为: a·b =| a |·| b | cos < a,b > 其中 | a | 和 | b | 表示向量的模 。  
        float dot = Vector3.Dot(transform.forward, dir.normalized);//点乘判断前后：dot >0在前，<0在后
                                                                   //float dot1 = Vector3.Dot(transform.right, dir.normalized);//点乘判断左右： dot1>0在右，<0在左
                                                                   // float angle = Mathf.Acos(Vector3.Dot(transform.forward.normalized, dir.normalized)) * Mathf.Rad2Deg;//通过点乘求出夹角  
        if (dot > 0)
        {
            Debug.LogWarning("在前面");
            return true;
            
        }else
        {
            Debug.LogWarning("在后面");
        }
        return false;

    }
}
