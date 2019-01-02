using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desytory : MonoBehaviour {
    public LayerMask _layerMask;
    void Update()
    {
        //检测在当前位置发射0.5半径大小的球内是否有物体相交
        //检测LayerMask层级上的物体(相同层级)
        Collider[] cs = Physics.OverlapSphere(transform.position, 5f, _layerMask);

        if (cs.Length != 0)
        {
            foreach (Collider csCell in cs)
            {
                Debug.Log(csCell.gameObject.name);
                Destroy(csCell.gameObject);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 5f);
    }
}
