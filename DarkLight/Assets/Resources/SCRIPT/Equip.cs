using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using UnityEditor;

public class Equip : TTUIPage {
    public Equip() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "UIPrefab/EquipPanel";
    }
    //6个格子
    private Transform head, armor, lefthand, righthand, shose, accessory;
    GameObject go;
    public override void Awake(GameObject go)
    {
        base.Awake(go);

    }
    public static void showequip()
    {
        AssetDatabase.Refresh();
       // Analysis.GoodsEquip();
       // Save.SaveEquip();
        
        if (Save.Equiplist==null)
        {

        }
        else
        {
            for (int i = 0; i < Save.Equiplist.Count; i++)
            {
                GameObject ga = GameObject.Instantiate(Resources.Load<GameObject>("zhuangbei"));

                DataMgr.Item tt1 = DataMgr.GetInstance().GetItemID(Save.Equiplist[i].Id);
                GameObject go = GameObject.Find("NormalRoot").transform.Find("EquipPanel(Clone)").gameObject;
                switch (tt1.equipment_Type)
                {

                    case DataMgr.Equipment_Type.Head_Gear:
                        ga.transform.SetParent(go.transform.GetChild(0));
                        ga.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(tt1.item_Img);
                        ga.transform.localScale = Vector3.one;
                        ga.transform.GetComponent<RectTransform>().localPosition = Vector3.zero;
                        ga.GetComponent<Button>().onClick.AddListener(() => { TTUIPage.ShowPage<tipequ>(tt1); });
                        break;
                    case DataMgr.Equipment_Type.Armor:
                        ga.transform.SetParent(go.transform.GetChild(1));
                        ga.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(tt1.item_Img);
                        ga.transform.localScale = Vector3.one;
                        ga.transform.GetComponent<RectTransform>().localPosition = Vector3.zero;
                        ga.GetComponent<Button>().onClick.AddListener(() => { TTUIPage.ShowPage<tipequ>(tt1); });
                        break;
                    case DataMgr.Equipment_Type.Shoes:
                        ga.transform.SetParent(go.transform.GetChild(4));
                        ga.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(tt1.item_Img);
                        ga.transform.localScale = Vector3.one;
                        ga.transform.GetComponent<RectTransform>().localPosition = Vector3.zero;
                        ga.GetComponent<Button>().onClick.AddListener(() => { TTUIPage.ShowPage<tipequ>(tt1); });
                        break;
                    case DataMgr.Equipment_Type.Accessory:
                        ga.transform.SetParent(go.transform.GetChild(5));
                        ga.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(tt1.item_Img);
                        ga.transform.localScale = Vector3.one;
                        ga.transform.GetComponent<RectTransform>().localPosition = Vector3.zero;
                        ga.GetComponent<Button>().onClick.AddListener(() => { TTUIPage.ShowPage<tipequ>(tt1); });
                        break;
                    case DataMgr.Equipment_Type.Left_Hand:
                        ga.transform.SetParent(go.transform.GetChild(3));
                        ga.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(tt1.item_Img);
                        ga.transform.localScale = Vector3.one;
                        ga.transform.GetComponent<RectTransform>().localPosition = Vector3.zero;
                        ga.GetComponent<Button>().onClick.AddListener(() => { TTUIPage.ShowPage<tipequ>(tt1); });
                        break;
                    case DataMgr.Equipment_Type.Right_Hand:
                        ga.transform.SetParent(go.transform.GetChild(2));
                        ga.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(tt1.item_Img);
                        ga.transform.localScale = Vector3.one;
                        ga.transform.GetComponent<RectTransform>().localPosition = Vector3.zero;
                        ga.GetComponent<Button>().onClick.AddListener(() => { TTUIPage.ShowPage<tipequ>(tt1); });
                        break;
                    case DataMgr.Equipment_Type.Two_Hand:
                        ga.transform.SetParent(go.transform.GetChild(2));
                        ga.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(tt1.item_Img);
                        ga.transform.localScale = Vector3.one;
                        ga.transform.GetComponent<RectTransform>().localPosition = Vector3.zero;
                        ga.GetComponent<Button>().onClick.AddListener(() => { TTUIPage.ShowPage<tipequ>(tt1); });
                        //GameObject clone = GameObject.Instantiate(Resources.Load<GameObject>("zhuangbei")); 
                        //clone.transform.SetParent(go.transform.GetChild(3));
                        //clone.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(tt1.item_Img);
                        //clone.transform.localPosition = Vector3.zero;
                        //clone.transform.localScale = Vector3.one;
                        break;
                    default:
                        break;
                }

            }
        }
        
    }
    public static void clearequip()
    {
        
        if (Save.Equiplist == null)
        {

        }
        else
        {
            GameObject ba = GameObject.Find("NormalRoot").transform.Find("EquipPanel(Clone)").gameObject;
            
            for (int i = 0; i < ba.transform.childCount; i++)
            {



                for (int j = 0; j < ba.transform.GetChild(i).childCount; j++)
                 {
                    if (ba.transform.GetChild(i).childCount == 0)
                    {

                    }
                    else
                    {
                        GameObject vv = ba.transform.GetChild(i).GetChild(j).gameObject;
                        vv.transform.parent = null;
                        GameObject.Destroy(vv);
                    }
                 }
                
                    
               

                
                    
                   
                

            }
        }

    }
    public override void Refresh()
    {
        base.Refresh();

        
        base.Awake(go);
       
        
        if (Save.Equiplist==null)
        {

        }
        else
        {

            //showequip();
            //clearequip();
            //showequip();




        }
           
        
    }
}
