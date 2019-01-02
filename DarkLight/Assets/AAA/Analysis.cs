using UnityEngine;
using System.Collections;
using LitJson;
using Newtonsoft.Json;
using System.Collections.Generic;
/// <summary>
/// 解析数据
/// </summary>
public class Analysis : MonoBehaviour {

	void Awake () {
        // 用户数据解析
        UserAnalysis();
        // 物品数据解析
        GoodsAnalysis();
        
    }
    /// <summary>
    /// 用户数据解析
    /// </summary>
	void UserAnalysis()
    {
        TextAsset u = Resources.Load("Setting/UserJson") as TextAsset;
        if (!u)
        {
            return;
        }
    //    Save.SaveUser = JsonMapper.ToObject<UserModelList>(u.text);
        print(u.text);
    }

    /// <summary>
    /// 物品数据解析
    /// </summary>

    public static  void GoodsAnalysis()
    {
        
            TextAsset g = Resources.Load("Setting/GoodsList") as TextAsset;
            Debug.Log(g);

            // TextAsset g = Resources.Load("Setting/GoodsList") as TextAsset;
            if (!g)
            {
                return;
            }
            Save.Goodlist = JsonConvert.DeserializeObject<List<GoodsModel>>(g.text);
        if (Save.Goodlist==null)
        {

        }
        else
        {
            for (int i = 0; i < Save.Goodlist.Count; i++)
            {
                if (Save.Goodlist[i].Num == 0)
                {
                    Save.Goodlist.Remove(Save.Goodlist[i]);
                }
            }
        }
            
       
        
    }
    public static void GoodsEquip() 
    {
        TextAsset n = Resources.Load("Setting/EquipList") as TextAsset;
        Debug.Log(n);

        // TextAsset g = Resources.Load("Setting/GoodsList") as TextAsset;
        if (!n)
        { 
            return;
        }
        Save.Equiplist = JsonConvert.DeserializeObject<List<GoodsModel>>(n.text);
    }

}
