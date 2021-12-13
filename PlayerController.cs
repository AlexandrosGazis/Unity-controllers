using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    ///public vs private--> private value cannot be edited in unity

    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

    public Transform pivot;
    public float rotateSpeed;

    public GameObject playerModel;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //  moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        float yStore = moveDirection.y;
        moveDirection = (transform.forward*Input.GetAxis("Vertical"))+ (transform.right * Input.GetAxis("Horizontal"));//apply the direction of the game object that is facing for: WS i.e. up down + AS i.e. right left
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;//after finishing movement
        if (controller.isGrounded)
        {//check if controller is attached
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        moveDirection.y = moveDirection.y + (gravityScale * Physics.gravity.y);// * Time.deltaTime); //added gravity
        controller.Move(moveDirection * Time.deltaTime);//move player

        // Move player to different direction based on camera's direction
        if (Input.GetAxis("Horizontal") !=0  || Input.GetAxis("Vertical") != 0) //vertical and input axis are not zero, move the player thus rotate
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation,rotateSpeed* Time.deltaTime) ;//apply rotation to the player 
        }
    }
}
