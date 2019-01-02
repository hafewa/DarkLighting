using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class DataMgr
{

    public static DataMgr instance = null;
  public static  List<Item> itemList = new List<Item>();

    //public List<Item> item_usable_set = new List<Item>();
    //public List<Item> item_etc_set = new List<Item>();
    //public Item[] item_gold = new Item[1];
    // Start is called before the first frame update

    /// <summary>
    /// 根据id获取物品信息
    /// </summary>
    /// <param name="_id"></param>
    /// <returns></returns>
  public delegate bool Predicate<in T>(T obj);
    public Item GetItemID(int _id)
    {


        return itemList.Find(x => x.item_ID==_id);
    }

    

    private DataMgr()
    {

        TextAsset ta = Resources.Load("ItemData/ItemData1") as TextAsset;
        itemList = JsonConvert.DeserializeObject<List<Item>>(ta.text);
        Debug.Log(itemList.Count);
    }
    static public DataMgr GetInstance()
    {
        if (instance==null)
        {
            instance = new DataMgr();

        }
        return instance;
    }
    /// <summary>
    /// 物品类
    /// </summary>
    [System.Serializable]
    public class Item
    {
        public string item_Name = "Item Name";
        public string item_Type = "Item Type";
        [Multiline]
        public string description = "Description Here";
        public int item_ID;
        public string item_Img;//图片名字
        public string item_Effect;//特效名字
        public string item_Sfx;//音效名字
        public Equipment_Type equipment_Type;
        public int price;
        public int hp, mp, atk, def, spd, hit;
        public float criPercent, atkSpd, atkRange, moveSpd;
    }
    public enum Equipment_Type
    {
        Null = 0, Head_Gear = 1, Armor = 2, Shoes = 3, Accessory = 4, Left_Hand = 5, Right_Hand = 6, Two_Hand = 7
    }
}
