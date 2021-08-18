using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerTalk : MonoBehaviour
{
    [Header("Attribute")]
    [SerializeField] private Vector2 talkObjectOffSet = new Vector2(1.5f, 1.5f);
    [SerializeField] private float textSpeed = 0.1f;

    [Header("Components")]
    [SerializeField] private GameObject talkObject;
    [SerializeField] private Camera uiCamera;
    [SerializeField] private List<TextAsset> textAssets = new List<TextAsset>();

    private BoxCollider2D collider2d;
    private List<string> textList;
    private Text talkText;

    private bool isAbleToTalk = false;
    private bool isTextFinished = true;
    private int talkIndex = 0;
    private int assetIndex = 0;

    private void Awake()
    {
        //读取文本信息
        LoadText();
    }

    private void Start()
    {
        collider2d = GetComponent<BoxCollider2D>();
        talkText = talkObject.GetComponentInChildren<Text>();

        InputManager.Instance.StartListen(true);
        CenterEvent.Instance.AddListener(KeyTypeManager.EKeyDown, ShowTalk);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
            isAbleToTalk = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
        {
            if (talkIndex == textList.Count)
                talkIndex = 0;
            isAbleToTalk = false;
            talkObject.SetActive(false);
        }
    }

    void ShowTalk()
    {
        //没有进入到对话范围内
        if (!isAbleToTalk)
            return;
        CanNextText();
        //对话结束
        if (talkIndex == textList.Count)
        {
            talkObject.SetActive(false);
            talkIndex = 0;
            return;
        }
        //窗口还未打开
        if (!talkObject.activeSelf)
        {
            talkObject.SetActive(true);
            RectTransform rectTransform = talkObject.GetComponent<RectTransform>();
            rectTransform.position = uiCamera.WorldToScreenPoint(transform.position + new Vector3(talkObjectOffSet.x, collider2d.size.y + talkObjectOffSet.y, 0.0f));
            StartCoroutine(StartTalk());
        }
        //窗口已经打开
        else
            if (isTextFinished)
                StartCoroutine(StartTalk());
    }
    void CanNextText()
    {
        int storyType = BackPack.Instance.Item_Story();
        if (storyType == 0)
            return;
        else
            assetIndex = storyType;
        LoadText();
    }
    void LoadText()
    {
        textList = new List<string>();
        if (assetIndex < textAssets.Count)
        {
            string[] lineDatas = textAssets[assetIndex].text.Split('\n');
            foreach (var lineData in lineDatas)
            {
                textList.Add(lineData);
            }
        }
    }

    IEnumerator StartTalk()
    {
        isTextFinished = false;
        talkText.text = "";
        for (int i = 0; i < textList[talkIndex].Length; i++)
        {
            talkText.text += textList[talkIndex][i];
            yield return new WaitForSeconds(textSpeed);
        }
        isTextFinished = true;
        talkIndex++;
    }
}
