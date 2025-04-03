using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    public List<GameObject> obj_enble, obj_disenble, obj_enble_�ж�, obj_disenble_�ж�;
    public GameObject obj_ui;
    public static Click Instance;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(obj_ui);
    }


   


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) Application.Quit();

    }
    public void OnClick(int t)
    {
        for (int i = 0; i < obj_enble.Count; i++)
        {
            if (i != t)
            {
                obj_enble[i].SetActive(false);
                obj_disenble[i].SetActive(true);
            }
        }
        obj_enble[t].SetActive(true);
        obj_disenble[t].SetActive(false);
    }
    public void OnClick()
    {
        for (int i = 0; i < obj_enble.Count; i++)
        {

            obj_enble[i].SetActive(false);
            obj_disenble[i].SetActive(true);
        }

    }

    public void OnClick_�ж�(int t)
    {
        for (int i = 0; i < obj_enble_�ж�.Count; i++)
        {
            if (i != t)
            {
                obj_enble_�ж�[i].SetActive(false);
                obj_disenble_�ж�[i].SetActive(true);
            }
        }
        obj_enble_�ж�[t].SetActive(true);
        obj_disenble_�ж�[t].SetActive(false);
    }
    public void OnClick_tiaozhuang(string t)
    {
        if (SceneManager.GetActiveScene().name != t)
        {
            SceneManager.LoadScene(t);
        }

    }

}
