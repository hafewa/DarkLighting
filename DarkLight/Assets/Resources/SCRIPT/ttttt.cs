using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using UnityEditor;

public class ttttt : TTUIPage {

    public ttttt() : base(UIType.PopUp, UIMode.DoNothing, UICollider.Normal)
    {
        uiPath = "UIPrefab/ttttt";
    }
    GameObject t;

    Button s;
    Button s1;
    public override void Awake(GameObject go)
    { 
        base.Awake(go);
        t = GameObject.Find("ttttt(Clone)");
        Debug.Log(t.name + "12345");
        s = GameObject.Find("ttttt(Clone)").transform.Find("Back").GetComponent<Button>();
        s1  = GameObject.Find("ttttt(Clone)").transform.Find("Buy").GetComponent<Button>();
        re = GameObject.Find("UIRoot").gameObject;
    }
    GameObject re;
    public override void Refresh()
    {
        base.Refresh();
        
        DataMgr.Item item = (DataMgr.Item)data;
        s.onClick.AddListener(() => { TTUIPage.ClosePage<ttttt>(); });
        s1.onClick.AddListener(() =>
        {




            switch (item.item_Type)

            {
                case "Weapon":
                    // TTUIPage.ShowPage<Equip>(item);
                    break;
                case "Headgear":
                    //  TTUIPage.ShowPage<Equip>(item);
                    break;
                case "Armor":
                    // TTUIPage.ShowPage<Equip>(item);
                    break;
                case "Shose":
                    //  TTUIPage.ShowPage<Equip>(item);
                    break;
                case "Shield":
                    // TTUIPage.ShowPage<Equip>(item);
                    break;
                case "Accessory":
                    //
                    break;
                default:
                    Debug.Log("使用物品类型错误");
                    break;
            };
          
            #region
            //TTUIPage.ClosePage<Equip>();
            DataMgr.Item te = DataMgr.instance.GetItemID(item.item_ID);

            if (Save.Equiplist.Count == 0)
            {
                GoodsModel SS = new GoodsModel();
                SS.Id = te.item_ID;
                SS.Num = 1;
                Save.Equiplist = new List<GoodsModel>();
                Save.Equiplist.Add(SS);
                for (int i = 0; i < Save.Goodlist.Count; i++)
                {
                    if (Save.Goodlist[i].Id == item.item_ID)
                    {
                        if (Save.Goodlist[i].Num <= 1)
                        {
                            Save.Goodlist.Remove(Save.Goodlist[i]);
                        }
                        else
                        {
                            Save.Goodlist[i].Num -= 1;
                        }
                    }
                }
            }
            if(Save.Equiplist.Count != 0)
            { for (int i = 0; i < Save.Equiplist.Count; i++)
                {

                    if (item.equipment_Type == DataMgr.instance.GetItemID(Save.Equiplist[i].Id).equipment_Type)
                    {

                        Save.Goodlist.Add(Save.Equiplist[i]);
                        Save.Equiplist.Remove(Save.Equiplist[i]);
                        //Save.Equiplist.Remove(Save.Equiplist[i]);
                        GoodsModel SS = new GoodsModel();
                        //SS.Id = item.item_ID;
                        //SS.Num = 1;
                        //Save.Equiplist.Add(SS);



                    }
                    else
                    {
                        GoodsModel SS = new GoodsModel();
                        SS.Id = item.item_ID;
                        SS.Num = 1;
                        Save.Equiplist.Add(SS);
                        for (int m = 0; m < Save.Goodlist.Count; m++)
                        {
                            if (Save.Goodlist[m].Id == item.item_ID)
                            {
                               
                                    Save.Goodlist.Remove(Save.Goodlist[m]);
                                Debug.Log("YIJINGYICHULE");
                            }
                        }
                    }
                }

            }
            #endregion

            //  Save.chuanItem(item);
            TTUIPage.ShowPage<BagPanel>();
            TTUIPage.ShowPage<Equip>(item);
            TTUIPage.ClosePage<Equip>();
        });
         item = (DataMgr.Item)data;
        t.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(item.item_Img);
        t.transform.GetChild(1).GetComponent<Text>().text = "名字 :" + item.item_Name;
        t.transform.GetChild(2).GetComponent<Text>().text = "类型 :" + item.item_Type;
        t.transform.GetChild(3).GetComponent<Text>().text = "描述 :" + item.description;
        t.transform.GetChild(4).GetComponent<Text>().text = "价格 :" +item.price ;
        TTUIRoot ttui = new TTUIRoot();
        Vector3 ee;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(TTUIRoot.Instance.root.transform as RectTransform, Input.mousePosition, TTUIRoot.Instance.uiCamera, out ee))
        {
            Debug.Log(ee);
            t.transform.position = ee;
        } 
    }
}

