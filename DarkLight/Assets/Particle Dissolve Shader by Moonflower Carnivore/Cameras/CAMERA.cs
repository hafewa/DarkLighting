using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMERA : MonoBehaviour {
    public float distance;
    Vector3 offect;
    Transform player;
	// Use this for initialization
	void Start () {
        offect = transform.forward * distance;
        player = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position - offect,0.5F);
    }


    public  void add()
    {
        gameObject.GetComponent<Camera>().orthographicSize+=3;
        if (gameObject.GetComponent<Camera>().orthographicSize>30)
        {
            gameObject.GetComponent<Camera>().orthographicSize = 30;
        }
        else
        {
           
        }

    }

    public void min()
    {
        gameObject.GetComponent<Camera>().orthographicSize--;
        if (gameObject.GetComponent<Camera>().orthographicSize<5)
        {
            gameObject.GetComponent<Camera>().orthographicSize =5;
        }
    }
}
