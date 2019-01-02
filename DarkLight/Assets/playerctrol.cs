using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TinyTeam.UI;
using TinyTeam;

public class playerctrol : MonoBehaviour {

    public GameObject go;
    public CharacterController m_CharacterController;
    public float speed;
    public Rigidbody rigidbody;
    Animator myanimator;
    public GameObject effect;
    public GameObject effect1;
    public GameObject span;
    // Use this for initialization
    void Start()
    {
        myanimator = GetComponent<Animator>();
    }
    RaycastHit hit;
    Vector3 target;
    // Update is called once per frame
    bool s = false;
    Vector3 move = Vector3.zero;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TTUIPage.ShowPage<ForgePanel>();
        }


        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            myanimator.SetBool("iswalk", true);
            m_CharacterController.SimpleMove(transform.forward * Input.GetAxis("Vertical") * speed);
            transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * 3, 0));

            //rigidbody.MovePosition(go.transform.position + transform.forward * Input.GetAxis("Vertical"));
            //rigidbody.MoveRotation(go.transform.rotation * Quaternion.Euler(0, Input.GetAxis("Horizontal") * 3, 0));
            //Quaternion quaternion = Quaternion.Euler(0, Camera.main.transform.rotation.y, 0);
            //m_CharacterController.SimpleMove(quaternion*  new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical")));
        }
        else
        {
            myanimator.SetBool("iswalk", false);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            myanimator.SetTrigger("skill2");
           
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myanimator.SetTrigger("skill1");

        }
    }
    void myskill1()
    {
       
        Instantiate(effect, transform.position,transform.rotation);
        
       
    }
    void myskill2() 
    {
     //   Instantiate(effect1, transform.position, Quaternion.identity);

    }

}