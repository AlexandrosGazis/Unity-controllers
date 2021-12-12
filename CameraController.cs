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

    // Start is called before the first frame update
    void Start()
    {

        if (!useOffsetValues)
        {
            //when game starts, initialize the camera's position 
            offset = target.position - transform.position;//target.Trasform.position
        }

        pivot.position = target.transform.position;
        pivot.transform.parent = target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X")*rotateSpeed; //get x position (mouse) and rotate based on target. Mouase X=mouse movement->mouse move left/right
        target.Rotate(0, horizontal, 0);

        //get Y position (mouse) and rotate pivot //MOVE CAMERA based on mouse for up and down
        float vertical = Input.GetAxis("Mouse Y")* rotateSpeed;
       // pivot.Rotate(-vertical,0,0);
        target.Rotate(-vertical, 0, 0);

        //move camera based on target rotation and original offset 
        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = target.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle,0);//z axis: - , x and y axis:angle of the player
        transform.position = target.position - rotation * offset;
        

       // transform.position = target.position - offset ;//camera moves when target moves
        transform.LookAt(target);

    }
}
