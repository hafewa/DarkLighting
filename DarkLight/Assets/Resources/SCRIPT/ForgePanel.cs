using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using UnityEditor;

public class ForgePanel :TTUIPage{
     
    Button DuanZao, zuo, you;
    Image Newgame, c1, c2;
    public ForgePanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    { 
        uiPath = "UIPrefab/ForgePanel";
    }
    
    public override void Awake(GameObject go)
    {
        base.Awake(go);
        DuanZao = transform.Find("duanzao").GetComponent<Button>();
        zuo = transform.Find("ZUO").GetComponent<Button>();
        you = transform.Find("YOU").GetComponent<Button>();
        Newgame= transform.Find("newgame").GetComponent<Image>();
        c1 = transform.Find("c1").GetComponent<Image>();
        c2 = transform.Find("c2").GetComponent<Image>();
        Newgame.sprite = Resources.Load<Sprite>(2003.ToString());
        c1.sprite = Resources.Load<Sprite>(3001.ToString());
        c2.sprite = Resources.Load<Sprite>(2005.ToString());
        c1.transform.GetChild(0).GetComponent<Text>().text = 5.ToString();
        c2.transform.GetChild(0).GetComponent<Text>().text = 3.ToString();
        if (Newgame.sprite.name == "2003")
        {
            for (int i = 0; i < Save.Goodlist.Count; i++)
            {
                if (Save.Goodlist[i].Id == 3001)
                {
                    c1.transform.GetChild(2).GetComponent<Text>().text = Save.Goodlist[i].Num.ToString();

                }
            }
            for (int i = 0; i < Save.Goodlist.Count; i++)
            {
                if (Save.Goodlist[i].Id == 2005)
                {
                    c2.transform.GetChild(2).GetComponent<Text>().text = Save.Goodlist[i].Num.ToString();

                }
            }
        }
    }
    string s;
    public override void Refresh()
    {
        base.Refresh();
      //  Analysis.GoodsAnalysis();
        zuo.onClick.AddListener(() =>
        {
            Newgame.sprite = Resources.Load<Sprite>(2003.ToString());
            s = Newgame.sprite.ToString();
            c1.sprite = Resources.Load<Sprite>(3001.ToString());
            c2.sprite = Resources.Load<Sprite>(2005.ToString());
            c1.transform.GetChild(0).GetComponent<Text>().text = 5.ToString();
            c2.transform.GetChild(0).GetComponent<Text>().text = 3.ToString();
            if (Newgame.sprite.name == "2003")
            {
                for (int i = 0; i < Save.Goodlist.Count; i++)
                {
                    if (Save.Goodlist[i].Id == 3001)
                    {
                        c1.transform.GetChild(2).GetComponent<Text>().text = Save.Goodlist[i].Num.ToString();

                    }
                }
                for (int i = 0; i < Save.Goodlist.Count; i++)
                {
                    if (Save.Goodlist[i].Id == 2005)
                    {
                        c2.transform.GetChild(2).GetComponent<Text>().text = Save.Goodlist[i].Num.ToString();

                    }
                }
            }
            if (Newgame.sprite.name == "2021")
            {
                for (int i = 0; i < Save.Goodlist.Count; i++)
                {
                    if (Save.Goodlist[i].Id == 3002)
                    {
                        c1.transform.GetChild(2).GetComponent<Text>().text = Save.Goodlist[i].Num.ToString();

                    }
                }
                for (int i = 0; i < Save.Goodlist.Count; i++)
                {
                    if (Save.Goodlist[i].Id == 3001)
                    {
                        c2.transform.GetChild(2).GetComponent<Text>().text = Save.Goodlist[i].Num.ToString();

                    }
                }
            }

        });
        you.onClick.AddListener(() =>
        {
            Newgame.sprite = Resources.Load<Sprite>(2021.ToString());
            c1.sprite = Resources.Load<Sprite>(3001.ToString());
            c2.sprite = Resources.Load<Sprite>(3002.ToString());
            c1.transform.GetChild(0).GetComponent<Text>().text = 2.ToString();
            c2.transform.GetChild(0).GetComponent<Text>().text = 1.ToString();
            if (Newgame.sprite.name == "2003")
            {
                for (int i = 0; i < Save.Goodlist.Count; i++)
                {
                    if (Save.Goodlist[i].Id == 3001)
                    {
                        c1.transform.GetChild(2).GetComponent<Text>().text = Save.Goodlist[i].Num.ToString();

                    }
                }
                for (int i = 0; i < Save.Goodlist.Count; i++)
                {
                    if (Save.Goodlist[i].Id == 2005)
                    {
                        c2.transform.GetChild(2).GetComponent<Text>().text = Save.Goodlist[i].Num.ToString();

                    }
                }
            }
            if (Newgame.sprite.name == "2021")
            {
                for (int i = 0; i < Save.Goodlist.Count; i++)
                {
                    if (Save.Goodlist[i].Id == 3002)
                    {
                        c1.transform.GetChild(2).GetComponent<Text>().text = Save.Goodlist[i].Num.ToString();

                    }
                }
                for (int i = 0; i < Save.Goodlist.Count; i++)
                {
                    if (Save.Goodlist[i].Id == 3001)
                    {
                        c2.transform.GetChild(2).GetComponent<Text>().text = Save.Goodlist[i].Num.ToString();

                    }
                }
            }

        });


        


      

        DuanZao.onClick.AddListener(()=> {

            if (Newgame.sprite.name == "2003")
            {
                Analysis.GoodsAnalysis();
                bool s = false;
                for (int i = 0; i < Save.Goodlist.Count; i++)
                {
                    if (Save.Goodlist[i].Id == 3001)
                    {
                        c1.transform.GetChild(2).GetComponent<Text>().text = Save.Goodlist[i].Num.ToString();
                        if (Save.Goodlist[i].Num >= 5)
                        {
                            s = true;
                        }
                    }
                }
                for (int i = 0; i < Save.Goodlist.Count; i++)
                {
                    if (Save.Goodlist[i].Id == 2005)
                    {
                        c2.transform.GetChild(2).GetComponent<Text>().text = Save.Goodlist[i].Num.ToString();
                        if (Save.Goodlist[i].Num >= 3 && s == true)
                        {
                            GoodsModel ssss = new GoodsModel();
                            ssss.Id = 2003;
                            ssss.Num = 1;

                           
                            for (int k = 0; k < Save.Goodlist.Count; k++)
                            {
                                if (Save.Goodlist[k].Id==3001)
                                {
                                    Save.Goodlist[k].Num -= 5;
                                }
                                if ( Save.Goodlist[k].Id == 2005)
                                {
                                    Save.Goodlist[k].Num -= 3;
                                }
                            }
                            Save.Goodlist.Add(ssss);
                            // Save.SaveGoods();

                        }
                    }
                }
                s = false;
            }
            if (Newgame.sprite.name =="2021")
            {
  //            Analysis.GoodsAnalysis();
                bool s = false;
                for (int i = 0; i < Save.Goodlist.Count; i++)
                {
                    if (Save.Goodlist[i].Id == 3001)
                    {
                        c1.transform.GetChild(2).GetComponent<Text>().text = Save.Goodlist[i].Num.ToString();
                        if (Save.Goodlist[i].Num >= 2)
                        {
                            s = true;
                        }
                    }
                }
                for (int i = 0; i < Save.Goodlist.Count; i++)
                {
                    if (Save.Goodlist[i].Id == 3002)
                    {
                        c2.transform.GetChild(2).GetComponent<Text>().text = Save.Goodlist[i].Num.ToString();
                        if (Save.Goodlist[i].Num >= 1 && s == true)
                        {
                                    GoodsModel ssss = new GoodsModel();
                                    ssss.Id = 2021;
                                    ssss.Num = 1;
                            for (int k = 0; k < Save.Goodlist.Count; k++)
                            {
                                if (Save.Goodlist[k].Id == 3001)
                                {
                                    Save.Goodlist[k].Num -= 2;
                                }
                                if (Save.Goodlist[k].Id == 3002)
                                {
                                    Save.Goodlist[k].Num -= 1;
                                }
                            }
                            Save.Goodlist.Add(ssss);
                                  
                                   // Save.SaveGoods();
                              
                        }
                    }
                }
                s = false;
            }









        });
      //  Save.SaveGoods();
    }

    

}

