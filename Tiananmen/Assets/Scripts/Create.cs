using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{

    public GameObject Cube_Prefab;//Cube预制体

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("ui_canvas(Clone)")==null)
        {
            Instantiate(Cube_Prefab);
        }
       

    }

    // Update is called once per frame
    void Update()
    {

    }
}
