using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    ///public vs private--> private value cannot be edited in unity

    public float moveSpeed;
    public float jumpForce;
    public Rigidbody theRB; //the Regid Body

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody>(); //get component of RigidBody type
       
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector3(Input.GetAxis("Horizontal")*moveSpeed, theRB.velocity.y,Input.GetAxis("Vertical") * moveSpeed); //x,y,z speed values
        if (Input.GetButtonDown("Jump"))
        {
            theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);// x axis is set form moveSpeed, here i change Y axis
        }

    }
}
