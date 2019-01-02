using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using TinyTeam.UI;
using UnityEditor;
using Newtonsoft.Json;

public class Tipe : MonoBehaviour, IPointerClickHandler
{
    GameObject ga;
    private void Awake()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
       ga= eventData.pointerEnter.gameObject;
        Debug.Log(ga.name);
        ga.transform.parent.GetChild(6).GetComponent<Toggle>().isOn = true;

        GameObject Me = GameObject.Find("Message");
        Me.transform.localScale = Vector3.one;
        Me.transform.GetChild(6).GetComponent<Button>().onClick.AddListener(close);
        Debug.Log(Me.transform.GetChild(6).name);
        List<GameObject> gameObjects = new List<GameObject>();
        DataMgr dataMgr = DataMgr.GetInstance();
       





        GameObject game = GameObject.Find("Content");
      

        for (int i = 0; i < game.transform.childCount; i++)
        {
            gameObjects.Add(game.transform.GetChild(i).gameObject);
        }
          Sprite s=    ga.transform.parent.GetChild(0).GetComponent<Image>().sprite;
        Me.transform.GetChild(1).GetComponent<Image>().sprite = s;
        if (ShopItemlist.tag1 == "W")
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite == s)
                {
                    Debug.Log(gameObjects[i].transform.GetChild(0).transform.GetChild(0).gameObject.name);
                    Me.transform.GetChild(2).GetComponent<Text>().text = "名字 :" + dataMgr.GetItemID(DataMgr.itemList[i + 3].item_ID).item_Name;
                    Me.transform.GetChild(3).GetComponent<Text>().text = "类型 :" + dataMgr.GetItemID(DataMgr.itemList[i + 3].item_ID).item_Type;
                    Me.transform.GetChild(4).GetComponent<Text>().text = "价格 :" + (dataMgr.GetItemID(DataMgr.itemList[i + 3].item_ID).price).ToString();
                    Me.transform.GetChild(5).GetComponent<Text>().text = "描述 :" + (dataMgr.GetItemID(DataMgr.itemList[i + 3].item_ID).description).ToString();
                   
                }
            }
        }
        else
        {
            for (int i = 0; i <3; i++)
            {
                if (gameObjects[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite == s)
                {

                    Me.transform.GetChild(2).GetComponent<Text>().text = "名字 :" + dataMgr.GetItemID(DataMgr.itemList[i].item_ID).item_Name;
                    Me.transform.GetChild(3).GetComponent<Text>().text = "类型 :" + dataMgr.GetItemID(DataMgr.itemList[i].item_ID).item_Type;
                    Me.transform.GetChild(4).GetComponent<Text>().text = "价格 :" + (dataMgr.GetItemID(DataMgr.itemList[i].item_ID).price).ToString();
                    Me.transform.GetChild(5).GetComponent<Text>().text = "描述 :" + (dataMgr.GetItemID(DataMgr.itemList[i].item_ID).description).ToString();
                }
            }
        }
        

       
    }

    void  close()
    {
        GameObject Me = GameObject.Find("Message");
        Me.transform.localScale = Vector3.zero;
        ga.transform.parent.GetChild(6).GetComponent<Toggle>().isOn = false;
        ShopPanel.statue = false;
    }
    GameObject gaa;
    GameObject T;
    // Use this for initialization
    void Start () {
       
        transform.parent.GetChild(4).GetComponent<Button>().onClick.AddListener(() => { Save.BuyItem(itt); });
        ti = GameObject.Find("UICamera").GetComponent<Camera>();

        T = GameObject.Find("ttttt(Clone)");
    } 
  
    public DataMgr.Item itt;
    public void tipe(DataMgr.Item _itt)
    {


      
        Debug.Log("执行了遍");
        itt = _itt;
        

       
    }
    Camera ti;
    private void Update()
    {
        ////ti.transform.SetAsLastSibling();
        //Vector2 sw;
        ////RectTransformUtility.ScreenPointToLocalPointInRectangle(T.GetComponent<RectTransform>(), Input.mousePosition, ti, out sw);
        ////T.GetComponent<RectTransform>().position = sw;
        ////Debug.Log(T.GetComponent<RectTransform>().position);
    }




}
