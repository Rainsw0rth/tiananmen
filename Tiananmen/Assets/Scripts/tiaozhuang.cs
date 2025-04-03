using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tiaozhuang : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick_tiaozhuang(int t)
    {
        
       SceneManager.LoadSceneAsync(t);
        
    }
    public void OnClick_chage(int t)
    {

        Click.Instance.i = t;

    }
}
