using Paroxe.PdfRenderer;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayPDF : MonoBehaviour
{
    public RawImage rawImage;   //显示PDF的UI
    PDFDocument pdfDocument;    //PDF文件
    PDFRenderer pdfRenderer;    //PDF渲染
    int curPDFPage;    //当前显示的PDF页数
    int countOfPDFAllPage;    //PDF文件总页数
    //PDF网络路径 （这里填入自己的网络PDF路径）
    string url = "https:// xx.xxxx.xxxx.pdf";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DownLoadFile(url));
    }

    /// <summary>
    /// 加载本地PDF文件
    /// </summary>
    /// <param name="url"></param>
    void LoadLocalPDF(string url)
    {
        pdfDocument = new PDFDocument(url);
        if (pdfDocument.IsValid)    //判断该文档是否有效
        {
            curPDFPage = 0;
            countOfPDFAllPage = pdfDocument.GetPageCount();
            ScreenShowPDF(GetCurPagePDFTexture(curPDFPage));

        }
        else
        {
            if (File.Exists(url))
            {
                File.Delete(url);
            }
            pdfDocument = null;
        }
    }

    /// <summary>
    /// 获取当前页面的PDF画面
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    Texture2D GetCurPagePDFTexture(int page)
    {
        if (pdfDocument == null) return null;
        Texture2D tex = pdfDocument.Renderer.RenderPageToTexture(pdfDocument.GetPage(page));
        //纹理的过滤模式
        tex.filterMode = FilterMode.Bilinear;
        //随着值变大，纹理在浅角度下会更清晰。值越低，表示纹理在浅角度下更模糊。‎
        tex.anisoLevel = 8;

        return tex;
    }

    /// <summary>
    /// 下载网络PDF文件到本地
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    IEnumerator DownLoadFile(string url)
    {
        yield return new WaitForSeconds(0.5f);
        // string directoryPath = Application.persistentDataPath + "/FileCache";
        string directoryPath = Application.streamingAssetsPath + "/FileCache";
        //if (!Directory.Exists(directoryPath))
        //{
        //    Directory.CreateDirectory(directoryPath);
        //}
        //string downloadFileName = url.Substring(url.LastIndexOf('/') + 1);
        //string localpath = directoryPath + "/" + downloadFileName;
        //string downloadFileName = url.Substring(url.LastIndexOf('/') + 1);
        string localpath = directoryPath + "/" + "中国共产党简史.pdf";
        Debug.Log(localpath);
        //pdfDocument = new PDFDocument(localpath);
        //curPDFPage = 0;
        //countOfPDFAllPage = pdfDocument.GetPageCount();
        //ScreenShowPDF(GetCurPagePDFTexture(curPDFPage));
        //MDebug(localpath);
        //如果本地文件已存在 直接加载
        if (File.Exists(localpath))
        {
            LoadLocalPDF(localpath);
            yield break;
        }

        //UnityWebRequest webRequest = new UnityWebRequest();
        //UnityWebRequest webRequest = UnityWebRequest.Get(url);
        //webRequest.timeout = 60;
        //yield return webRequest.SendWebRequest();
        //if (webRequest.isNetworkError)
        //{
        //    Debug.Log("Download Error: " + webRequest.error);
        //    if (File.Exists(localpath))
        //    {
        //        File.Delete(localpath);
        //    }
        //}
        //else
        //{
        //    var file = webRequest.downloadHandler.data;
        //    FileStream nFile = new FileStream(localpath, FileMode.Create);
        //    nFile.Write(file, 0, file.Length);
        //    nFile.Close();
        //    LoadLocalPDF(localpath);
        //}
    }
    /// <summary>
    /// 切换PDF页面
    /// </summary>
    void ChangePDFPage()
    {
        Texture2D tex = GetCurPagePDFTexture(curPDFPage);
        ScreenShowPDF(tex);
    }

    /// <summary>
    /// 显示PDF在UI或者物体上
    /// </summary>
    /// <param name="texture"></param>
    private void ScreenShowPDF(Texture2D texture)
    {
        if (texture == null) return;
        if (texture.width >= 2048 || texture.height >= 2048)
            return;

        RectTransform recttrans = rawImage.GetComponent<RectTransform>();
        //3DUI PDF rawimage 大小
        float maxWidth = 1920;
        float maxHeight = 1080;
        float scalex = texture.width * 1.0f / maxWidth;
        float scaley = texture.height * 1.0f / maxHeight;
        if (scalex > scaley)
        {
            float d = 1.0f / scalex;
            scaley = scaley * d;
            scalex = 1.0f;
        }
        else
        {
            float d = 1.0f / scaley;
            scalex = scalex * d;
            scaley = 1.0f;
        }
        recttrans.sizeDelta = new Vector2(maxWidth * scalex, maxHeight * scaley);
        rawImage.GetComponent<RawImage>().texture = texture;
        rawImage.GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        ////翻页 翻页时关闭自动播放
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{

        //    StopAllCoroutines();
        //    curPDFPage += 1;
        //    if (curPDFPage >= countOfPDFAllPage) curPDFPage = 0;
        //    ChangePDFPage();
        //}
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    StopAllCoroutines();
        //    curPDFPage -= 1;
        //    if (curPDFPage < 0) curPDFPage = countOfPDFAllPage - 1;
        //    ChangePDFPage();
        //}

        ////自动播放
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    StartCoroutine(AutoTurnPage());
        //}
        ////停止自动播放
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    StopAllCoroutines();
        //}
    }


    /// <summary>
    /// 下一页
    /// </summary
    public void next()
    {
        StopAllCoroutines();
        curPDFPage += 1;
        if (curPDFPage >= countOfPDFAllPage) curPDFPage = 0;
        ChangePDFPage();
    }

    /// <summary>
    /// 上一页
    /// </summary>
    public void last()
    {
        StopAllCoroutines();
        curPDFPage -= 1;
        if (curPDFPage < 0) curPDFPage = countOfPDFAllPage - 1;
        ChangePDFPage();
    }

    bool IsAutoPlayLoop = false;    //循环播放
    bool autoTurnPageOver = false;  //自动播放结束
                                    /// <summary>
                                    /// 自动翻页
                                    /// </summary>
                                    /// <returns></returns>
    IEnumerator AutoTurnPage()
    {
        yield return new WaitForSeconds(2);
        curPDFPage += 1;
        if (curPDFPage < countOfPDFAllPage)
        {
            autoTurnPageOver = false;
            ChangePDFPage();
            StartCoroutine(AutoTurnPage());
        }
        else
        {

            if (IsAutoPlayLoop)  //循环自动播放
            {
                curPDFPage = 0;
                ChangePDFPage();
                StartCoroutine(AutoTurnPage());
            }
            else//非循环自动播放
            {
                if (autoTurnPageOver)
                {
                    curPDFPage = 0;
                    ChangePDFPage();
                    StartCoroutine(AutoTurnPage());
                }
            }
            autoTurnPageOver = true;
        }

    }
}