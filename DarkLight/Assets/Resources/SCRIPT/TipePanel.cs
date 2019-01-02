using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;

public class TipePanel : TTUIPage {

    // Use this for initialization

    private Button okButton; 
    public TipePanel() : base(UIType.PopUp, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "UIPrefab/TipePanel";
    }

    public override void Awake(GameObject go)
    {
        base.Awake(go);
        okButton = GameObject.Find("Buttonok").GetComponent<Button>();
        okButton.onClick.AddListener(() => { TTUIPage.ClosePage<TipePanel>(); });
        
    }

}
