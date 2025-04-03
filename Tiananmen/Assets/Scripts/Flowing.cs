using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowing : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TargetA, TargetB;
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!TargetA.activeInHierarchy)
        {
            transform.position = TargetB.transform.position;
            transform.rotation = Quaternion.Euler(0, TargetB.transform.localEulerAngles.y, 0);
        }
        else
        {
            transform.position = TargetA.transform.position;
            transform.rotation = Quaternion.Euler(0, TargetA.transform.localEulerAngles.y ,0);
        }

       
    }
}
