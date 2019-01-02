using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using UnityEditor;
using TinyTeam.UI;

using System.Threading;
using UnityEngine.UI;

public class UserModel {
    /* {"UserList":[{"Hp":80,"MaxHp":120,"Attack":35,"Speed":25}]}  */
    public int Hp;
    public int MaxHp;
    public int Attack;
    public int Speed;
}
public  class UserModelList
{
    public List<UserModel> UserList = new List<UserModel>();
}
public class GoodsModel //商品信息
{
    public int Id;
    public string Name;
    public string Nature;//图片种类(图片名)
    public string Function;
    public int Value;//值
    public int Num;//数量
}
//public class GoodsModelList
//{
//    public List<GoodsModel> GoodsList;
//}
 
public  class Save: UserModelList
{
    public static List< GoodsModel> Goodlist;
    public static List<UserModelList> Userlist;
    public static List<GoodsModel> Equiplist;
     

    public static  void BuyItem(DataMgr.Item _item)
    {
        Debug.Log("买买买");
        Debug.Log(_item.item_ID);
        if (Goodlist==null)
        {
            Goodlist = new List<GoodsModel>();
           
        }

        GoodsModel gm = Goodlist.Find(x => x.Id == _item.item_ID);
        if (gm!=null)
        {
            gm.Num += 1;

        }
        else
        {
            Goodlist.Add(new GoodsModel() { Id = _item.item_ID, Num = 1 });
        }
       // SaveGoods();
        TTUIPage.ShowPage<TipePanel>(_item.item_ID);


    }
   
    public static void chuanItem(DataMgr.Item _item)
    {


       

    }

    public static  void SaveGoods()
    {//指向Assets根目录
        string path = @"E:\feiq\Recv Files\DarkLight\Assets\Resources\Setting\GoodsList.json";
       // TextAsset u = Resources.Load(path) as TextAsset;
        FileInfo info = new FileInfo(path);
        StreamWriter sw = info.CreateText();

        string s = JsonConvert.SerializeObject(Goodlist);
        sw.Write(s);
        sw.Close();
        sw.Dispose();
        AssetDatabase.Refresh();




    }
    public static void SaveEquip() 
    {//指向Assets根目录
        string path = @"E:\feiq\Recv Files\DarkLight\Assets\Resources\Setting\EquipList.json";
        // TextAsset u = Resources.Load(path) as TextAsset;
        FileInfo info = new FileInfo(path);
        StreamWriter sw = info.CreateText();

        string s = JsonConvert.SerializeObject(Equiplist);
        sw.Write(s);
        sw.Close();
        sw.Dispose();
        AssetDatabase.Refresh();




    }


}

