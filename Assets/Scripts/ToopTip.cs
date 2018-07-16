using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToopTip : MonoBehaviour {

    #region 单例模式
    private static ToopTip _instance;
    public static ToopTip Instance
    {
        get
        {
            if (_instance == null)
            {
                //下面的代码只会执行一次
                _instance = GameObject.Find("ToolTip").GetComponent<ToopTip>();
            }
            return _instance;
        }
    }
    #endregion

    public Text NameText;
    public Text UpText;
    private CanvasGroup canvasGroup;
    private  Canvas canvas;
    private Vector2 mouse1Position;
    private Vector2 debugPosition;
    private float targetAlpha = 0;
    private float smoothing = 3;

    void Start()
    {
        NameText = GetComponent<Text>();
        UpText = transform.Find("Text").GetComponent<Text>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        debugPosition = new Vector2(-80,-110);
    }
    void Update()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out mouse1Position);
        //mousePosition = Input.mousePosition;
       // Debug.Log(mousePosition);
        ToopTip.Instance.SetLocalPosition(mouse1Position + debugPosition);//
        if (canvasGroup.alpha != targetAlpha)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, smoothing * Time.deltaTime);
            if (Mathf.Abs(canvasGroup.alpha - targetAlpha) < 0.05f)
            {
                canvasGroup.alpha = targetAlpha;
            }
        }
    }

    public void Show(string text)
    {
       
        targetAlpha = 1;
        NameText.text = text;
        UpText.text = text;
    }
    public void Hide()
    {
        targetAlpha = 0;
        canvasGroup.alpha = 0;
        //Debug.Log("chuqu1");
    }
    public void SetLocalPosition(Vector3 position)
    {
        transform.localPosition = position;
    }
}
