using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TinyTeam.UI;
using UnityEditor;

public class SHUIXNPanel : TTUIPage {
    public SHUIXNPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "UIPrefab/SHUXING";
    }

    Text HP, MP, ATK, DEF, SPEDD;
    DataMgr.Item S;
    public override void Awake(GameObject go)
    {
        base.Awake(go);

       
       
       
            
   //         Analysis.GoodsEquip();
        HP = transform.GetChild(1).GetComponent<Text>();
        MP = transform.GetChild(2).GetComponent<Text>();
        ATK = transform.GetChild(3).GetComponent<Text>();
        DEF = transform.GetChild(4).GetComponent<Text>();
        SPEDD = transform.GetChild(5).GetComponent<Text>();

        if (Save.Equiplist == null)
        {


            HP.text = "HP:   " + (hp).ToString();
            MP.text = "MP:   " + (mp).ToString();
            ATK.text = "ATK:   " + (atk).ToString();
            DEF.text = "DEF:   " + (def).ToString();
            SPEDD.text = "SPEDD:   " + (speed).ToString();

        }
    }
    int hp = 1000, mp = 1000, atk = 10, def = 10, speed = 10;
    public override void Refresh()
    {
       
        //base.Refresh();
       // AssetDatabase.Refresh();
       
      
        if (Save.Equiplist==null)
        {


            HP.text = "HP:   " + (hp).ToString();
            MP.text = "MP:   " + (mp).ToString();
            ATK.text = "ATK:   " + (atk).ToString();
            DEF.text = "DEF:   " + (def).ToString();
            SPEDD.text = "SPEDD:   " + (speed).ToString();

        }
        else
        {
            DataMgr dataMgr = DataMgr.GetInstance();
            for (int i = 0; i < Save.Equiplist.Count; i++)
            {

                S = DataMgr.instance.GetItemID(Save.Equiplist[i].Id);

                HP.text = "HP:   " + (hp += dataMgr.GetItemID(S.item_ID).hp).ToString();
                MP.text = "MP:   " + (mp += dataMgr.GetItemID(S.item_ID).mp).ToString();
                ATK.text = "ATK:   " + (atk += dataMgr.GetItemID(S.item_ID).atk).ToString();
                DEF.text = "DEF:   " + (def += dataMgr.GetItemID(S.item_ID).def).ToString();
                SPEDD.text = "SPEDD:   " + (speed += dataMgr.GetItemID(S.item_ID).spd).ToString();
            }
        }
        
    }
}
