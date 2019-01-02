using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class ShopItemlist : MonoBehaviour
{

    public  static string tag1;
    public static List<int> itemIDs = new List<int>();
    //public Button tipsBtn;
    public static event Action<bool, List<int>> OnNpcTrigger;//跟进入NPC触发器有关

    void Start()
    {
        if (this.gameObject.tag == "Untagged")
            this.gameObject.tag = "Npc_Shop";
        //tipsBtn.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            //tipsBtn.gameObject.SetActive(true);
            if (OnNpcTrigger != null)
            {
                OnNpcTrigger(true, itemIDs);

            }
            //ipBtn.onClick.AddListener()
            //点击按钮
            //打开商店
            //设置商店里的物品
            tag1 = this.gameObject.tag;
           // Debug.Log(tag1);
        } 
    }
    private void OnTriggerExit(Collider other)
    {
       
        if (OnNpcTrigger != null)
        {
            OnNpcTrigger(false, itemIDs);
          



           
        }
    }
}



