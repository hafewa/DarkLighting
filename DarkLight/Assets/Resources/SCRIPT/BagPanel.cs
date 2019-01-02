using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using Newtonsoft.Json;
using UnityEditor;

public class BagPanel : TTUIPage {

    public BagPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "UIPrefab/BagPanel";
    }
    public override void Awake(GameObject go)
    {
        base.Awake(go);

        #region     
        //Analysis.GoodsAnalysis();
        //AssetDatabase.Refresh();
        //GameObject pa = GameObject.Find("NormalRoot").transform.Find("BagPanel(Clone)").transform.GetChild(1).GetChild(0).gameObject;

        //for (int i = 0; i < Save.Goodlist.Count; i++)
        //{
        //    GameObject ga = GameObject.Instantiate(Resources.Load<GameObject>("bagga"));
        //    Debug.Log(Save.Goodlist.Count);
        //    AssetDatabase.Refresh();
        //    DataMgr.Item tt1 = DataMgr.GetInstance().GetItemID(Save.Goodlist[i].Id);
        //    ga.transform.SetParent(pa.transform.GetChild(i));
        //    ga.transform.position = ga.transform.parent.transform.position;
        //    ga.transform.localScale = Vector3.one;
        //    ga.transform.localPosition = new Vector3(0f, 0, 0);
        //    ga.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(tt1.item_Img);
        //    ga.transform.GetChild(1).GetComponent<Text>().text = Save.Goodlist[i].Num.ToString();
        //    ga.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => { TTUIPage.ShowPage<ttttt>(tt1); });
        //    ga.transform.GetComponent<Button>().onClick.AddListener(() => TTUIPage.ShowPage<ttttt>(Save.Goodlist[i]));

        //}
        //GameObject pa = GameObject.Find("BagPanel(Clone)").transform.GetChild(1).GetChild(0).gameObject;

        //for (int i = 0; i < Save.Goodlist.Count; i++)
        //{
        //    GameObject ga = GameObject.Instantiate(Resources.Load<GameObject>("bagga"));
        //    Debug.Log(Save.Goodlist.Count);
        //    DataMgr.Item tt1 = DataMgr.GetInstance().GetItemID(Save.Goodlist[i].Id);
        //    ga.transform.SetParent(pa.transform.GetChild(i));
        //    // ga.transform.position = ga.transform.parent.transform.position;
        //    ga.transform.localScale = Vector3.one;
        //    ga.transform.localPosition = new Vector3(0f, 0, 0);
        //    ga.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(tt1.item_Img);
        //    ga.transform.GetChild(1).GetComponent<Text>().text = Save.Goodlist[i].Num.ToString();
        //    ga.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => { TTUIPage.ShowPage<ttttt>(tt1); });

        //}
        // showbag();
        #endregion
        //Analysis.GoodsAnalysis();
        //AssetDatabase.Refresh();
        clear();
    }


    public static void clear()
    {
        if (Save.Goodlist==null)
        {

        }
        else
        {
            GameObject ba = GameObject.Find("NormalRoot").transform.Find("BagPanel(Clone)").transform.GetChild(1).GetChild(0).gameObject;
            int len = ba.transform.GetChild(2).childCount;
            
            for (int i = 0; i < ba.transform.childCount; i++)
            {
                if (ba.transform.GetChild(i).transform.childCount==0)
                {

                }
                else
                {
                    GameObject temp = ba.transform.GetChild(i).GetChild(0).gameObject;
                temp.transform.parent = null;
                    Debug.Log(temp.name+"==================================");
                GameObject.Destroy(temp);
                }
                
            }
        }
       
    }
    public static void showbag()
    {

        // AssetDatabase.Refresh();
        //Save.SaveGoods();
        //Analysis.GoodsAnalysis();
        //Analysis.GoodsAnalysis();

        GameObject pa = GameObject.Find("BagPanel(Clone)").transform.GetChild(1).GetChild(0).gameObject;
           
            for (int i = 0; i < Save.Goodlist.Count; i++)
            {
            if (Save.Goodlist[i].Num > 0)
            {


                DataMgr.Item tt1 = DataMgr.GetInstance().GetItemID(Save.Goodlist[i].Id);
                GameObject ga = GameObject.Instantiate(Resources.Load<GameObject>("bagga"));
                Debug.Log(Save.Goodlist.Count);

                ga.transform.SetParent(pa.transform.GetChild(i));
                // ga.transform.position = ga.transform.parent.transform.position;
                ga.transform.localScale = Vector3.one;
                ga.transform.localPosition = new Vector3(0f, 0, 0);
                ga.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(tt1.item_Img);
                ga.transform.GetChild(1).GetComponent<Text>().text = Save.Goodlist[i].Num.ToString();
                ga.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => { TTUIPage.ShowPage<ttttt>(tt1); });
                ga.transform.GetComponent<Button>().onClick.AddListener(() => TTUIPage.ShowPage<ttttt>(Save.Goodlist[i]));

            }



        }//
       
    }
    public override void Refresh()
    {
        

        if (Save.Goodlist==null)
        {
           
        }
        else
        {
            clear();
            showbag();
        }                               
                
    }   
}
