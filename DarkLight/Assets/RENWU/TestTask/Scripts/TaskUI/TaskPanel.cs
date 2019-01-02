using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 任务面板
/// </summary>
public class TaskPanel : MonoSingletion<TaskPanel> 
{
    private Dictionary<string, TaskItemUI> taskUIDic = new Dictionary<string, TaskItemUI>();//id,taskItem

    [SerializeField]
    private GameObject content;//内容

    [SerializeField]
    private GameObject item;//列表项

    void Start()
    {
        if(!content)
        {
            content = transform.Find("Scroll View/Viewport/Content").gameObject;
        }
        if(!item)
        {
            item = Resources.Load("Item") as GameObject;
        } 

        TaskManager.Instance.OnGetEvent += AddItem;
        TaskManager.Instance.OnRewardEvent += RemoveItem;
        TaskManager.Instance.OnFinishEvent += FinishTaskItem;
        TaskManager.Instance.OnCancelEvent += RemoveItem;
        TaskManager.Instance.OnCheckEvent += CheckTaskItem;
    }

    /// <summary>
    /// 更新任务UI
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void CheckTaskItem(TaskEventArgs e)
    {
        string tempTaskId = e.taskID;
        if(taskUIDic.ContainsKey(tempTaskId))
        {
            taskUIDic[tempTaskId].Modify(e);
        }
    }

    public void FinishTaskItem(TaskEventArgs e)
    {
        string tempTaskId = e.taskID;
        if (taskUIDic.ContainsKey(tempTaskId))
        {
            taskUIDic[tempTaskId].Finish(true);
        }
    }

    /// <summary>
    /// 添加列表项
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void AddItem( TaskEventArgs e)
    {
        if(taskUIDic.ContainsKey(e.taskID))
        {
            Debug.LogError("已经接受了这个任务！");
            return;
        }
        GameObject taskGobj = Instantiate(item) as GameObject;
        taskGobj.transform.SetParent(content.transform);

        TaskItemUI t = taskGobj.GetComponent<TaskItemUI>();
        taskUIDic.Add(e.taskID,t);
        t.Init(e);
    }

    /// <summary>
    /// 移除列表项
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void RemoveItem( TaskEventArgs e)
    {
        if (taskUIDic.ContainsKey(e.taskID))
        {
            TaskItemUI t = taskUIDic[e.taskID];
            taskUIDic.Remove(e.taskID);
            Destroy(t.gameObject);
        }      
    }
}
