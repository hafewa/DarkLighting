using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Test : MonoBehaviour {

    public GameObject taskPanel;

    //public Image testImage;

    void Start()
    {
      GameObject ga=  GameObject.Find("Tsk").transform.GetChild(0).GetChild(0).gameObject;
        ga.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => {
            DataManager DA = new DataManager();

            float s = PlayerPrefs.GetFloat("statue1");
            if (s==1)
            {
                print("该任务已完成，无法重复接取");
            }
            else
            {
               
                TaskManager.Instance.AcceptTask("T001");
            }

        });
        ga.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => {
        DataManager DA = new DataManager();

        float s = PlayerPrefs.GetFloat("statue2");
            if (s == 1)
            {
                print("该任务已完成，无法重复接取");
            }
            else
            {
                TaskManager.Instance.AcceptTask("T002");
            }
        });
        ga.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => {
        DataManager DA = new DataManager();

        float s = PlayerPrefs.GetFloat("statue3");
            if (s == 1)
            {
                print("该任务已完成，无法重复接取");
            }
            else
            {
                TaskManager.Instance.AcceptTask("T003");
            }
        });
        ga.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() => {

            TaskEventArgs e = new TaskEventArgs();
            e.id = "Enemy1";
            e.amount = 1;
            MesManager.Instance.Check(e);
        });
        ga.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(() => {
            TaskEventArgs e = new TaskEventArgs();
            e.id = "Enemy2";
            e.amount = 1;
            MesManager.Instance.Check(e);
        });
        ga.transform.GetChild(5).GetComponent<Button>().onClick.AddListener(() => {
            TaskEventArgs e = new TaskEventArgs();
            e.id = "Item1";
            e.amount = 1;
            MesManager.Instance.Check(e);
        });
        ga.transform.GetChild(6).GetComponent<Button>().onClick.AddListener(() => {
            TaskEventArgs e = new TaskEventArgs();
            e.id = "Item2";
            e.amount = 1;
            MesManager.Instance.Check(e);
        });
        ga.transform.GetChild(7).GetComponent<Button>().onClick.AddListener(() => {
            TaskEventArgs e = new TaskEventArgs();
            e.id = "Item1";
            e.amount = -1;
            MesManager.Instance.Check(e);
        });
        ga.transform.GetChild(8).GetComponent<Button>().onClick.AddListener(() => {
            TaskEventArgs e = new TaskEventArgs();
            e.id = "Item2";
            e.amount = -1;
            MesManager.Instance.Check(e);
        });
       
    }bool s=true;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject gg = GameObject.Find("Tsk").transform.Find("renwu").gameObject;
            
           
            if (s==true)
            {
                gg.SetActive(true);

            }
            else
            {
                gg.SetActive(false);
            }
            s = !s;
        }
    }
    //void OnGUI()
    //{
    //    if (GUILayout.Button("接受任务Task1"))
    //    {
    //        TaskManager.Instance.AcceptTask("T001");
    //    }

    //    if (GUILayout.Button("接受任务Task2"))
    //    {
    //        TaskManager.Instance.AcceptTask("T002");
    //    }

    //    if (GUILayout.Button("接受任务T003"))
    //    {
    //        TaskManager.Instance.AcceptTask("T003");
    //    }

    //    if (GUILayout.Button("打怪Enemy1"))
    //    {
    //        TaskEventArgs e = new TaskEventArgs();
    //        e.id = "Enemy1";
    //        e.amount = 1;
    //        MesManager.Instance.Check(e);
    //    }

    //    if (GUILayout.Button("打怪Enemy2"))
    //    {
    //        TaskEventArgs e = new TaskEventArgs();
    //        e.id = "Enemy2";
    //        e.amount = 1;
    //        MesManager.Instance.Check(e);
    //    }

    //    if (GUILayout.Button("获取物体Item1"))
    //    {
    //        TaskEventArgs e = new TaskEventArgs();
    //        e.id = "Item1";
    //        e.amount = 1;
    //        MesManager.Instance.Check(e);
    //    }

    //    if (GUILayout.Button("获取物体Item2"))
    //    {
    //        TaskEventArgs e = new TaskEventArgs();
    //        e.id = "Item2";
    //        e.amount = 1;
    //        MesManager.Instance.Check(e);
    //    }

    //    if (GUILayout.Button("丢弃物体Item1"))
    //    {
    //        TaskEventArgs e = new TaskEventArgs();
    //        e.id = "Item1";
    //        e.amount = -1;
    //        MesManager.Instance.Check(e);
    //    }

    //    if (GUILayout.Button("丢弃物体Item2"))
    //    {
    //        TaskEventArgs e = new TaskEventArgs();
    //        e.id = "Item2";
    //        e.amount = -1;
    //        MesManager.Instance.Check(e);
    //    }

    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        taskPanel.SetActive(true);
    //    }

    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        taskPanel.SetActive(false);
    //    }
    //}

}
