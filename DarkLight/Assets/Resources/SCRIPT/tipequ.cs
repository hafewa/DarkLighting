using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using UnityEditor;


public class tipequ : TTUIPage {

    public tipequ() : base(UIType.PopUp, UIMode.DoNothing, UICollider.Normal)
    {
        uiPath = "UIPrefab/tipequ";
    }


    Image tu;
    Text name, type, des, price;
    Button ok, tuo;
    public override void Awake(GameObject go)
    {
        base.Awake(go);

        tu = transform.GetChild(0).GetComponent<Image>();
        name=transform.GetChild(1).GetComponent<Text>();
        type = transform.GetChild(2).GetComponent<Text>();
        des = transform.GetChild(3).GetComponent<Text>();
        price = transform.GetChild(4).GetComponent<Text>();
        ok = transform.GetChild(6).GetComponent<Button>();
        tuo = transform.GetChild(7).GetComponent<Button>();


    }
    public DataMgr.Item itt1;
    public void tipe1(DataMgr.Item _itt)
    {
         


        Debug.Log("执行了遍");
        itt1 = _itt; 

         

    }
    public override void Refresh()
    {
        base.Refresh();
        DataMgr.Item item = (DataMgr.Item)data;
        tu.sprite = Resources.Load<Sprite>(item.item_ID.ToString());
        name.text = item.item_Name;
        type.text = item.item_Type;
        des.text = item.description;
        price.text = item.price.ToString();
        ok.onClick.AddListener(() =>
        {
            TTUIPage.ClosePage<tipequ>();
        });
        tuo.onClick.AddListener(() => 
        { 
             DataMgr.Item vv = new DataMgr.Item();
            vv.item_ID = ((DataMgr.Item)data).item_ID;
            //   TTUIPage.ShowPage<Equip>();

            bool ss = false;
            for (int j = 0; j < Save.Equiplist.Count; j++)
            {

                if (Save.Equiplist[j].Id == item.item_ID)
                {


                    for (int i = 0; i < Save.Goodlist.Count; i++)
                    {
                        Debug.Log(Save.Goodlist[i].Id + "=============" + item.item_ID);
                        if (Save.Goodlist[i].Id == item.item_ID)
                        {
                            Save.Goodlist[i].Num += 1;
                            Save.Equiplist.Remove(Save.Equiplist[j]);
                            ss = true;
                            break;

                        }
                        else
                        {


                            if (Save.Goodlist[Save.Goodlist.Count - 1].Id != item.item_ID)
                            {
                                Save.Goodlist.Add(Save.Equiplist[j]);
                                Save.Equiplist.Remove(Save.Equiplist[j]);
                                break;

                            }

                        }
                    }

                    if (ss == true)
                    {
                        break;
                    }

                }

            }





            Save.chuanItem(item);
            TTUIPage.ClosePage<Equip>();
            TTUIPage.ShowPage<Equip>();
            //TTUIPage.ClosePage<BagPanel>();
            //TTUIPage.ShowPage<BagPanel>();

        });
        Vector3 ee;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(TTUIRoot.Instance.root.transform as RectTransform, Input.mousePosition, TTUIRoot.Instance.uiCamera, out ee))
        {
            Debug.Log(ee);
            transform.position = ee;
        }
    }
}
