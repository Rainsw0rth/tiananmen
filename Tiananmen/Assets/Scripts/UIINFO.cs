using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIINFO : MonoBehaviour
{
    public List<Sprite> sprites;
    public GameObject pdf;
    
    public void OnClick(int i)
    {
        transform.GetComponent<Image>().sprite = sprites[i];
        pdf.SetActive(false);
        transform.GetComponent<Image>().enabled = true;
    }
    public void OnOpenPDF()
    {
        transform.GetComponent<Image>().enabled = false;
        pdf.SetActive(true);
    }
}
