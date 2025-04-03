using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ExcelReadEditor : MonoBehaviour
{
    //读取的excel文件路径
    public static readonly string filePath = Application.streamingAssetsPath + "/Excel/" + "知识问答题库答案.xlsx";
    int count = 0;
    static List<Goods> manager = new List<Goods>(); //数据载体
    public Text title, OptionA, OptionB, OptionC, OptionD,Fen;
    public GameObject error;
    public GameObject showimg;
    int fenshu;
    void Start()
    {
        CreateSignInData();
    }
    private void Update()
    {
        if (!showimg.activeInHierarchy)
        {
            count = 0;
            fenshu = 0;
            Fen.text = "得分： " + fenshu.ToString();
        }
    }

    
    public static void CreateSignInData()
    {

        manager = ExcelRead.ReadGoodsExcel(filePath);

        //string path = "Assets/Resources/" + "Test.asset"; //保存到Resources文件下
        //AssetDatabase.CreateAsset(manager, path);
        //AssetDatabase.SaveAssets();
        //AssetDatabase.Refresh();
        //Debug.Log("读取数据成功");
    }
    public void show()
    {
        title.text = manager[count].name;
        OptionA.text = manager[count].OptionA;
        OptionB.text = manager[count].OptionB;
        OptionC.text = manager[count].OptionC;
        OptionD.text = manager[count].OptionD;
    }
    public void OnClick(int i)
    {
        Debug.Log(manager[count].Answer);
        count += 1;
        show();
        if (i == manager[count].Answer)
        {
            fenshu += 1;
            Fen.text = "得分： " + fenshu.ToString();
        }
        else
        {
            error.SetActive(true);
            Invoke("hide", 0.5f);
        }
    }
   void hide()
    {
        error.SetActive(false);
    }
}