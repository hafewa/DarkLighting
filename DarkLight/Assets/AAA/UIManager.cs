using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;
using UnityEditor;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider slider;
    public GameObject MainPanel;//主界面
    public Text Hp, MaxHp, Attack, Speed;
    public GameObject GoodsPrefab;//物品预设物
   
    public Transform Grid;//背包空格
    public GameObject[] GridArray;
    void Start()
    {
        slider.maxValue = Nature.Instance.MaxHp;
        slider.minValue = 0;
        Grid = GameObject.Find("MainPanel").transform.Find("Scroll View").transform.Find("Viewport").transform.Find("Content").transform;
     //Image[] s=   Grid.GetComponentInChildren<Image>();
        GameObject.Find("MainPanel").transform.Find("Scroll View").gameObject.SetActive(false);//隐藏主界面，显示出登录按钮
        GameObject.Find("MainPanel").transform.Find("showinfo").gameObject.transform.localScale=new Vector3(0,0,0);
        GameObject.Find("user").gameObject.transform.localScale = new Vector3(0, 0, 0);
        //  GoodsAnimation.PlayReverse();
    }
    bool s=true;
    public void Update()  
    {
        slider.value = Nature.Instance.Hp;
            Hp.text = Nature.Instance.Hp + "";
            MaxHp.text = Nature.Instance.MaxHp + "";
            Attack.text = Nature.Instance.Attack + "";
            Speed.text = Nature.Instance.Speed + "";
           
      
        
       
        // 吃药的方法   使用物品后 属性改变
        Nature.Instance.Eat();
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject gg = Instantiate(GoodsPrefab); 
            gg.GetComponent<Image>().sprite= Resources.Load<Sprite>("30000007");
            for (int j = 4; j < GridArray.Length; j++)
            {
                GridArray[j].AddChild(gg);
                
            }
        }
            if (Input.GetKeyDown(KeyCode.Z))
        {
            int temp=0;
            for (int i = 0; i < GridArray.Length; i++)
            {

                temp += GridArray[i].transform.childCount;
                if (temp==16)
                {
                    Debug.Log("背包满了");
                }
                else
                {
                    Debug.Log("背包没满");
                }
            }
        }
    }

    /// <summary>
    /// 点击背包按钮
    /// </summary>
    int temp = 0;
    public void message()
    {
       
        if (s==true)
        {
            GameObject.Find("user").gameObject.transform.localScale = new Vector3(1, 1, 1);
           
        }
        else
        {
            GameObject.Find("user").gameObject.transform.localScale = new Vector3(0, 0, 0);
        }

        s = !s;
    }
    public void BagBtnClick()
    {
        if (temp % 2 == 0)
        {
            //显示背包数据
            GameObject.Find("MainPanel").transform.Find("Scroll View").gameObject.SetActive(true);
            ShowBag();
        }
        else
        {
            // 清除背包数据
            GameObject.Find("MainPanel").transform.Find("Scroll View").gameObject.SetActive(false);
            //隐藏背包动画


        }
        temp++;
    }
    /// <summary>
    /// 显示背包数据
    /// </summary>
    public void ShowBag()
    {//清除背包
        ClearBag();

        //遍历物品信息
        int j = 0;
        //foreach (GoodsModel item in Save.SaveGoods.GoodsList)
        //{
        //    if (Save.SaveGoods.GoodsList[j].Num !=0)
        //    if (item.Num != 0)//物品数量不等于零时
        //    {
        //        //创建物品 NGUITools.AddChild(父物体，预设物);
        //        GameObject go = Instantiate(GoodsPrefab);
        //        go.transform.SetParent(Grid.transform.GetChild(j));
        //        go.transform.position = go.transform.parent.transform.position;
        //        //显示物体的图片及数量
        //        go.GetComponent<Image>().sprite =Resources.Load<Sprite>(item.Nature);
        //        go.transform.GetChild(0).GetComponent<Text>().text = item.Num + ""; 
        //        j++;
        //    }
        //}
    }
    /// <summary>
   // / 清除背包数据
   // / </summary>
    public void ClearBag()
    {
        //删除之前创建物品的预设物
        for (int i = 0; i < GridArray.Length; i++)
        {
            if (GridArray[i].transform.childCount != 0)
            {                                  
                       GridArray[i].transform.DestroyChildren();             
            }
        }
    }
    /// <summary>
    ///提示框的返回按钮
    /// </summary>
    public void ShowInfo_BackBtnClick()
    {
        GameObject.Find("MainPanel").transform.Find("showinfo").gameObject.transform.localScale = new Vector3(0, 0, 0);
    }
    /// <summary>
    /// 提示框中的使用物品按钮方法
    /// </summary>
    //当前使用的物品
    public GoodsModel CurrentGoods;
   public void ShowInfo_UseGoods(int id)
    {
        id = ItemButton.CurrentGoodsId;
        //for (int i = 0; i <Save.SaveGoods.GoodsList.Count ; i++)
        //{
        //    if (id== Save.SaveGoods.GoodsList[i].Id)
        //    {
        //        CurrentGoods = Save.SaveGoods.GoodsList[i];
        //    }
        //}
        //使用物品  类型
        switch (id)
        {
            case 0:
                Nature.Instance.Hp += CurrentGoods.Value;
                if (Nature.Instance.Hp>= Nature.Instance.MaxHp)
                {
                    Nature.Instance.Hp = Nature.Instance.MaxHp;
                }
                break;
            case 1:
                Nature.Instance.MaxHp += CurrentGoods.Value;
                break;
            case 2:
                Nature.Instance.Attack += CurrentGoods.Value;
                break;
            case 3:
                Nature.Instance.Speed += CurrentGoods.Value;
                break;
            case 4:
                Nature.Instance.Hp-= CurrentGoods.Value;
                break;
            default:
                break;      
        }
        CurrentGoods.Num--;
        if (CurrentGoods.Num <= 0)
        {
           
            CurrentGoods.Num = 0;
        }
        //刷新属性界面数据
        
        //刷新背包界面数据
        ShowBag();

        //for (int i = 0; i < Save.SaveGoods.GoodsList.Count; i++)
        //{
        //    if (Save.SaveGoods.GoodsList[i].Id ==CurrentGoods.Id)
        //    {
        //        Save.SaveGoods.GoodsList[i] = CurrentGoods;
        //    }
        //}
    }
    /// <summary>
    /// 点击保存按钮
    /// </summary>
    //public void SaveBtnClick()
    //{
    //    string path = Application.dataPath + @"/Resources/Setting/UserJson.txt";
    //    FileInfo info = new FileInfo(path);
    //    StreamWriter sw = info.CreateText();
    //    string json = JsonMapper.ToJson(Save.SaveUser);
    //    sw.Write(json);
    //    sw.Close();
    //    sw.Dispose();
    //    AssetDatabase.Refresh();

    //    string path1 = Application.dataPath + @"/Resources/Setting/GoodsList.json";
    //    FileInfo info1 = new FileInfo(path1);
    //    StreamWriter sw1 = info1.CreateText();
    //    string json1 = JsonMapper.ToJson(Save.SaveGoods);
    //    sw1.Write(json1);
    //    sw1.Close();
    //    sw1.Dispose();
    //    AssetDatabase.Refresh();
    //}
}
