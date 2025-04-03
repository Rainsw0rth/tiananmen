//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using VRTK;

//public class HandPressed : MonoBehaviour
//{

//    private VRTK_ControllerEvents vrtk_Controller;
//    private VRTK_Pointer vrtk_Point;
//    public GameObject a;

//    void Start()
//    {
//        vrtk_Controller = GetComponent<VRTK_ControllerEvents>();//获取手柄事件组件
//        vrtk_Controller.TriggerPressed += VRTK_Controller_TriggerPressed;//按下扳机键
//        vrtk_Controller.TriggerReleased += VRTK_Controller_TriggerReleased;//松开扳机键
//        vrtk_Controller.ButtonTwoPressed += VRTK_Controller_ButtonTwoPressed;//按下菜单键
//        vrtk_Controller.TouchpadPressed += VRTK_Controller_TouchpadPressed;//按下圆盘键
//        vrtk_Controller.TouchpadReleased += VRTK_Controller_TouchpadRelease;//松开圆盘键

//        vrtk_Point = GetComponent<VRTK_Pointer>();//获取射线组件
//        vrtk_Point.DestinationMarkerHover += VRTKPoint_DestinationMarkerHover;//射线触碰事件
//    }
//    /// <summary>
//    /// 手柄圆盘键松开
//    /// </summary>
//    /// <param name="sender"></param>
//    /// <param name="e"></param>
//    private void VRTK_Controller_TouchpadRelease(object sender, ControllerInteractionEventArgs e)
//    {
//        //这里写手柄圆盘键松开时要响应的事件
//    }
//    /// <summary>
//    /// 手柄圆盘键按下
//    /// </summary>
//    /// <param name="sender"></param>
//    /// <param name="e"></param>
//    private void VRTK_Controller_TouchpadPressed(object sender, ControllerInteractionEventArgs e)
//    {
//        //这里写手柄圆盘键按下时要响应的事件
//    }
//    /// <summary>
//    /// 手柄射线触碰
//    /// </summary>
//    /// <param name="sender"></param>
//    /// <param name="e"></param>
//    private void VRTKPoint_DestinationMarkerHover(object sender, DestinationMarkerEventArgs e)
//    {

//    }
//    /// <summary>
//    /// 手柄菜单键按下
//    /// </summary>
//    /// <param name="sender"></param>
//    /// <param name="e"></param>
//    private void VRTK_Controller_ButtonTwoPressed(object sender, ControllerInteractionEventArgs e)
//    {
//        //这里写手柄菜单键按下时要响应的事件
//    }

//    /// <summary>
//    /// 手柄扳机键松开
//    /// </summary>
//    /// <param name="sender"></param>
//    /// <param name="e"></param>
//    private void VRTK_Controller_TriggerReleased(object sender, ControllerInteractionEventArgs e)
//    {
//        //这里写手柄扳机键松开时要响应的事件
//        a.SetActive(false);
//    }

//    /// <summary>
//    /// 手柄扳机键按下
//    /// </summary>
//    /// <param name="sender"></param>
//    /// <param name="e"></param>
//    private void VRTK_Controller_TriggerPressed(object sender, ControllerInteractionEventArgs e)
//    {
//        //这里写手柄扳机键按下时要响应的事件
//    }


//}