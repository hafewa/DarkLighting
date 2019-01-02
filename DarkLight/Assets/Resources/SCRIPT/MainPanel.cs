using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using UnityEditor;
using Newtonsoft.Json;

public class MainPanel :TTUIPage {

    private Button StatusButton, BagButton, EquipButton, SkillButton, TipsButton, TipsButton1 ;
    public MainPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "UIPrefab/MainPanel";
    }
    public override void Awake(GameObject go)
    {
        //AssetDatabase.Refresh();
        //TextAsset u = Resources.Load("Setting/GoodsList") as TextAsset;
        //Debug.Log(u);
        //Save.Goodlist = JsonConvert.DeserializeObject<List<GoodsModel>>(u.text);
        Analysis.GoodsAnalysis();
        Analysis.GoodsEquip();
        base.Awake(go);
        StatusButton = transform.Find("StatusButton").GetComponent<Button>();
        BagButton = transform.Find("BagButton").GetComponent<Button>();
        EquipButton = transform.Find("EquipButton").GetComponent<Button>();
        SkillButton = transform.Find("SkillButton").GetComponent<Button>();
        TipsButton = transform.Find("TipsButton").GetComponent<Button>();

        TipsButton.gameObject.SetActive(false);
        TipsButton1 = transform.Find("TipsButton1").GetComponent<Button>();

        TipsButton.gameObject.SetActive(false);
        Debug.Log(TipsButton.gameObject.name);
        ShopItemlist.OnNpcTrigger += ShowTips;//提示按钮在靠近NPC时出现
        duanzaoItemLIST.OnNpcTrigger1 += ShowTips1;
    }
    /// <summary>
    /// 是否显示提示按钮
    /// </summary>
    /// <param name="isShow">按钮是否显示</param>
    /// <param name="_itemLIst">NPC传来的物品列表</param>
    public void ShowTips(bool isShow, List<int> _itemLIst)
    {

        
        TipsButton.gameObject.SetActive(isShow);//提示按钮默认隐藏
        if (isShow)
        {
            TipsButton.onClick.AddListener(() => { TTUIPage.ShowPage<ShopPanel>(_itemLIst); });
        }
        if (!isShow)
        {           
            TTUIPage.ClosePage<ShopPanel>();
            if (ShopPanel.statue==true)
            {
                GameObject SS = GameObject.Find("NormalRoot");
               
                if (SS.transform.childCount<3)
                {

                }
                else
                {
                    GameObject game = GameObject.Find("NormalRoot").transform.Find("ShopPanel(Clone)").gameObject;

                    GameObject.Destroy(game);
                }
               
            }
            TipsButton.onClick.RemoveAllListeners();
        }
    }
    public void ShowTips1(bool isShow, List<int> _itemLIst)
    {


        TipsButton.gameObject.SetActive(isShow);//提示按钮默认隐藏
        if (isShow)
        {
            TipsButton.onClick.AddListener(() => { TTUIPage.ShowPage<ForgePanel>(_itemLIst); });
        }
        if (!isShow)
        {
            TTUIPage.ClosePage<ForgePanel>();
            
            TipsButton.onClick.RemoveAllListeners();
        }
    }
    public override void Refresh()
    {
        base.Refresh();
        bool sta = true;
        BagButton.onClick.AddListener(showpage1);
        StatusButton.onClick.AddListener(() =>
       {
        //   Analysis.GoodsEquip();
           if (sta == true)
           {
               TTUIPage.ShowPage<SHUIXNPanel>();            
           }
           else
           {
               TTUIPage.ClosePage<SHUIXNPanel>();            
           }
           sta = !sta;
       });
        EquipButton.onClick.AddListener(() =>
        {
           // Equip.showequip();
           
            if (isquip == true)
            {
                
                TTUIPage.ShowPage<Equip>();
               

                Equip.showequip();
            }
            else
            {
                
                TTUIPage.ClosePage<Equip>();
                Equip.clearequip();

            }
            isquip = !isquip;
        }
        );
    }

    bool ISTRUE=true;
    bool isquip = true;
    public void showpage1()
    {
  //      Analysis.GoodsAnalysis();
        if (ISTRUE==true)
        {
            TTUIPage.ShowPage<BagPanel>();
            
        }
        else
        {
           
            TTUIPage.ClosePage<BagPanel>();

            BagPanel.clear();
        }
        ISTRUE = !ISTRUE;
       
        TTUIPage.ClosePage<ttttt>();
        
    }
}
