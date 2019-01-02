using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanc : MonoBehaviour {
    public  GameObject aa;
    // Use this for initialization
    void Start()
    {
    }
    public  void aaa()
    {
            List<GameObject> gameObjects = new List<GameObject>();
           
            Debug.Log(aa.transform.childCount);
            for (int i = 0; i < aa.transform.childCount; i++)
            {
                gameObjects.Add(aa.transform.GetChild(i).gameObject);
            }




            for (int i = 1; i < gameObjects.Count; i++)
            {

                if( aa.transform.childCount != 0)//物品数量不等于零时
                {
                    //创建物品 NGUITools.AddChild(父物体，预设物);
                    GameObject ga = Instantiate(Resources.Load<GameObject>("WeaponImage").gameObject);

                    ga.transform.SetParent(gameObjects[i].transform);
                    ga.transform.position = gameObjects[i].transform.parent.transform.position;
                    // go.transform.localPosition = new Vector3(-90.89f, 0, 0);
                    //显示物体的图片及数量
                    // go.GetComponent<Image>().sprite = Resources.Load<Sprite>();
                    // go.transform.GetChild(0).GetComponent<Text>().text = item.Num + "";
                    // j++;
                }
            }
        }
    
    // Update is called once per frame
    void Update () {
		
	}
}
