using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading;

public class move : MonoBehaviour {
    public GameObject span;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.Translate(span.transform.forward);
        Destroy(gameObject, 3f);
	}
}
