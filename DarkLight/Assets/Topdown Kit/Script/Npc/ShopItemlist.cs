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
    public static event Action<bool, List<int>> OnNpcTrigger;//������NPC�������й�

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
            //�����ť
            //���̵�
            //�����̵������Ʒ
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



