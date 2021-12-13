using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    public Vector3 offset; //store how far away from the player the camera will be placed

    public bool useOffsetValues; // when true:ON (checkbox in the Inspector)

    public float rotateSpeed; //camera move speed

    public Transform pivot;

    public float maxViewAngle; //how high can the camera go --> proposed values for VStudio code: 45
    public float minViewAngle; //how low can the camera go  --> proposed values for VStudio code: 315

    public bool invertY;

    // Start is called before the first frame update
    void Start()
    {

        if (!useOffsetValues)
        {
            //when game starts, initialize the camera's position 
            offset = target.position - transform.position;//target.Trasform.position
        }

        pivot.transform.position = target.transform.position;
        //pivot.transform.parent = target.transform;
        pivot.transform.parent = null;
         
        Cursor.lockState = CursorLockMode.Locked; //lock cursor to the center of the window's game
    }

    //Late Update is after update i.e. after the frame changes (so as to be OK with camera)
    void LateUpdate()
    {
        pivot.transform.position = target.transform.position;
        float horizontal = Input.GetAxis("Mouse X")*rotateSpeed; //get x position (mouse) and rotate based on target. Mouase X=mouse movement->mouse move left/right
        pivot.Rotate(0, horizontal, 0);

        //get Y position (mouse) and rotate pivot //MOVE CAMERA based on mouse for up and down
        float vertical = Input.GetAxis("Mouse Y")* rotateSpeed;
        if (invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.Rotate(-vertical, 0, 0);

        }
        //target.Rotate(-vertical, 0, 0);

        //Limit up-down camera rotation
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)//if x angle is more than 45 && les than 180, do not go higher than that
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0,0);//limit X rotation: 45 degrees to the left positive Real axis
        }

        if (pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 360f + minViewAngle)// check rotation angles
        {
            pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);//limit X rotation: -545 degrees to the  right positive Real axis(360-45)
        }

        //move camera based on target rotation and original offset 
        float desiredYAngle = pivot.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle,0);//z axis: - , x and y axis:angle of the player
        transform.position = target.position - rotation * offset;
        
        if(transform.position.y < target.position.y) //if camera goes bellow the height of the world, i.e. down the ground level fix it :)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - 10f, transform.position.z);// -5f or -10f so the camera goes a bit lower than the center of the player
        }

       // transform.position = target.position - offset ;//camera moves when target moves
        transform.LookAt(target);

    }
}
