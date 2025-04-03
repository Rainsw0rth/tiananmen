using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using VRTK.Examples;

public class zhidui : MonoBehaviour
{
    public List<GameObject> ZD;
    public GameObject CurObject;
    public GameObject PhotoObject;
    public List<Material> ZD1, ZD2, ZD3, ZD4, ZD5, ZD6, ZD7, ZD8, ZD9, ZD10, ZD11, ZD12, ZD13, ZD14, ZD15, ZD16, ZD17, ZD18, ZD19, ZD20, ZD21, ZD22, ZD23;
    public Dictionary<int, List<Material>> ZDMaterials = new Dictionary<int, List<Material>>();

    

    // Start is called before the first frame update
    void Start()
    {
        AddDictionary();
        CurObject = (GameObject)GameObject.Instantiate(ZD[Click.Instance.i-1]);
        CurObject.transform.position = Vector3.zero;
        CurObject.transform.localScale = Vector3.one;
        List<Material> CurMaterials = ZDMaterials[Click.Instance.i];
        for (int i=1;i< PhotoObject.GetComponent<MeshRenderer>().materials.Length; i++)
        {
            PhotoObject.GetComponent<MeshRenderer>().materials[i] = CurMaterials[i - 1];
        }
        
    }

    void AddDictionary()
    {
        ZDMaterials[1] = ZD1;
        ZDMaterials[2] = ZD2;
        ZDMaterials[3] = ZD3;
        ZDMaterials[4] = ZD4;
        ZDMaterials[5] = ZD5;
        ZDMaterials[6] = ZD6;
        ZDMaterials[7] = ZD7;
        ZDMaterials[8] = ZD8;
        ZDMaterials[9] = ZD9;
        ZDMaterials[10] = ZD10;
        ZDMaterials[11] = ZD11;
        ZDMaterials[12] = ZD12;
        ZDMaterials[13] = ZD13;
        ZDMaterials[14] = ZD14;
        ZDMaterials[15] = ZD15;
        ZDMaterials[16] = ZD16;
        ZDMaterials[17] = ZD17;
        ZDMaterials[18] = ZD18;
        ZDMaterials[19] = ZD19;
        ZDMaterials[20] = ZD20;
        ZDMaterials[21] = ZD21;
        ZDMaterials[22] = ZD22;
        ZDMaterials[23] = ZD23;
    }    
    // Update is called once per frame
    void Update()
    {

    }
   
}
