using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayYP : MonoBehaviour
{
    // Start is called before the first frame update
    public List<AudioClip> YP;
    public static PlayYP Instantiate;
    public AudioSource a;
    public int i=-1;
    public bool isPlay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate = this;
    }
    public void OnPlay()
    {
        a.clip = YP[i];
        a.Play();
        isPlay = true;
    }
    public void OnStop()
    {
        a.Pause();
        isPlay = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            int count = int.Parse(collision.gameObject.name);
            if (i != count)
            {
                i = count;
                OnPlay();
            }
            Debug.Log(count);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            int count = int.Parse(collision.gameObject.name);
            if (i == count)
            {
                if (isPlay)
                {
                    i = -1;
                    OnStop();
                }
            }

        }
    }
    public void OnPlay_YP(int i)
    {
        a.clip = YP[i];
        a.Play();
    }
}
