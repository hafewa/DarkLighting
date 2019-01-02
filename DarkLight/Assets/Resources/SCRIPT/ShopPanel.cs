using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopPanel : TTUIPage, IPointerClickHandler
{

    ToggleGroup g;
    // public GameObject im;
    public ShopPanel() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        uiPath = "UIPrefab/ShopPanel";
    }
    public override void Awake(GameObject go)
    {
        base.Awake(go);
        GameObject Me = GameObject.Find("Message");
        Me.transform.localScale = Vector3.zero;
        


    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
    public static bool statue;
    public DataMgr.Item dat;
    public override void Refresh()
    {
        base.Refresh();
        DataMgr dataMgr = DataMgr.GetInstance();
        List<GameObject> gameObjects = new List<GameObject>();
        dataMgr.GetItemID(DataMgr.itemList[3].item_ID);
        Debug.Log(dataMgr.GetItemID(DataMgr.itemList[3].item_ID));
        g = GameObject.Find("Content").transform.GetComponent<ToggleGroup>();
       
        GameObject game = GameObject.Find("Content");          
        //for (int i = 0; i < game.transform.childCount; i++)
        //{
        //    gameObjects.Add(game.transform.GetChild(i).gameObject);
        //}
        //Debug.Log(gameObjects.Count);
        Debug.Log(ShopItemlist.tag1);
        if (ShopItemlist.tag1=="W")
        {
            for (int i = 3; i < DataMgr.itemList.Count; i++)
            {
                //创建物品 NGUITools.AddChild(父物体，预设物);
                GameObject ga = GameObject.Instantiate(Resources.Load<GameObject>("Weapon"));

                ga.transform.SetParent(game.transform);
                ga.transform.position = ga.transform.parent.transform.position;
                ga.transform.localScale = Vector3.one;
                ga.transform.localPosition = new Vector3(117.5f, 0, 0);

               
                //显示物体的图片及数量
                int S = int.Parse(dataMgr.GetItemID(DataMgr.itemList[i].item_ID).item_Img);
               
                Debug.Log(dataMgr.GetItemID(DataMgr.itemList[i].item_ID).item_Img + "11111");
                ga.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>((dataMgr.GetItemID(DataMgr.itemList[i].item_ID).item_Img).ToString());
                ga.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = dataMgr.GetItemID(DataMgr.itemList[i].item_ID).item_Name;
                ga.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = dataMgr.GetItemID(DataMgr.itemList[i].item_ID).item_Type;
                ga.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = (dataMgr.GetItemID(DataMgr.itemList[i].item_ID).price).ToString();
                ga.transform.GetChild(0).GetChild(5).GetComponent<Tipe>().tipe(dataMgr.GetItemID(DataMgr.itemList[i].item_ID));
                Debug.Log("执行了");
                ga.transform.GetChild(0).GetChild(6).GetComponent<Toggle>().group = g;
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                //创建物品 NGUITools.AddChild(父物体，预设物);
                GameObject ga = GameObject.Instantiate(Resources.Load<GameObject>("Weapon"));

                ga.transform.SetParent(game.transform);
                ga.transform.position = ga.transform.parent.transform.position;
                ga.transform.localScale = Vector3.one;
                ga.transform.localPosition = new Vector3(117.5f, 0, 0);

                //显示物体的图片及数量
                int S = int.Parse(dataMgr.GetItemID(DataMgr.itemList[i].item_ID).item_Img);

                Debug.Log(dataMgr.GetItemID(DataMgr.itemList[i].item_ID).item_Img + "11111");
                ga.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>((dataMgr.GetItemID(DataMgr.itemList[i].item_ID).item_Img).ToString());
                ga.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = dataMgr.GetItemID(DataMgr.itemList[i].item_ID).item_Name;
                ga.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = dataMgr.GetItemID(DataMgr.itemList[i].item_ID).item_Type;
                ga.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = (dataMgr.GetItemID(DataMgr.itemList[i].item_ID).price).ToString();
                ga.transform.GetChild(0).GetChild(5).GetComponent<Tipe>().tipe(dataMgr.GetItemID(DataMgr.itemList[i].item_ID));
                Debug.Log("执行了");
                ga.transform.GetChild(0).GetChild(6).GetComponent<Toggle>().group = g;
            }
        }
        statue = true;
        
    }

   
}
