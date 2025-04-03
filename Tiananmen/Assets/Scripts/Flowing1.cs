using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowing1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Target;
    bool ishit = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Target.activeInHierarchy)
        {
            transform.position = new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z);
            //transform.rotation = Quaternion.Euler(transform.localRotation.x, Target.transform.localEulerAngles.y, transform.localRotation.z);
            if (!ishit)
            {
                transform.localRotation = Quaternion.Euler(transform.localRotation.x, Target.transform.localEulerAngles.y, transform.localRotation.z);
                ishit = true;

            }
        }
        else
        {
            ishit = false;
        }



    }
}
