using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale : MonoBehaviour {

    // Use this for initialization
    public GameObject ss;
    public GameObject skill;
    public GameObject shop;
    void Start () {
        ss.transform.localScale = Vector3.zero;
        skill.transform.localScale = Vector3.zero;
       // shop.transform.localScale = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    bool s = true;
    bool sss = true;
    bool ssss = true;
    public void equip()

    {
        if (s==true)
        {
            ss.transform.localScale = Vector3.one;
        }
        else
        {
            ss.transform.localScale = Vector3.zero;
        }
        s = !s;
    } 
    public void skill1()

    {
        if (sss == true)
        {
            skill.transform.localScale = Vector3.one;
        }
        else
        {
            skill.transform.localScale = Vector3.zero;
        }
        sss = !sss;
    }
    public void shopp()

    {
        if (ssss == true)
        {
            shop.transform.localScale = Vector3.one;
        }
        else
        {
            shop.transform.localScale = Vector3.zero;
        }
        ssss = !ssss;
    }
}
