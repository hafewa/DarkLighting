using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// 挂载在预设物上  
/// </summary>
public class ItemButton : MonoBehaviour {
    //当前物品的图片
    public  Sprite Sprite;
    //当前物品
    public GoodsModel CurrentGoods;
    //选中物品的Id
    public static int CurrentGoodsId;
    //物品信息显示框
    public   GameObject GoodsInfo;
    // Use this for initialization
    void Start () {
        Sprite = GetComponent<Image>().sprite;
        
       // GetComponent<Button>().onClick.AddListener(Show); 
        GoodsInfo = GameObject.Find("showinfo");
        GoodsInfo.transform.localScale = new Vector3(0, 0, 0);
        //获取预设物图片的名字
        //for (int i = 0; i < Save.SaveGoods.GoodsList.Count; i++)
        //{
        //    if (Sprite.name== Save.SaveGoods.GoodsList[i].Nature)
        //    {
        //        CurrentGoods = Save.SaveGoods.GoodsList[i];
        //        break;
        //    }
        //}
	}
    public  void  Show()
    {
        GoodsInfo.transform.localScale = new Vector3(1, 1, 1);
        GoodsInfo.transform.GetChild(0).GetComponent<Image>().sprite = Sprite;
        GoodsInfo.transform.GetChild(1).GetComponent<Text>().text = CurrentGoods.Name;
        GoodsInfo.transform.GetChild(2).GetComponent<Text>().text = CurrentGoods.Function;

        CurrentGoodsId = CurrentGoods.Id;
    }
}
