using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // initilising variables
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;


    private void FixedUpdate()// normally i would put lateupdate so it runs after all movement is finished but for some reason that makes the camera jitter so i used fixed update which somehow works...
    {
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, this.transform.position.z); // The desired position is just following the character plus an inputted offset, its set to 0 as standard

        if (target.position.y < -3)
        {
            desiredPosition = new Vector3(target.position.x, (float)-3, this.transform.position.z);
        }

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); //using linear interpoliation(lerp) we can transform our current position to our 
                                                                                                   //desired position smoothly as it will not instantly snap the camera to the target 
                                                                                                   //but it will move a 10 /th of the way there every frame, althought this is depending
                                                                                                   // on our smooth speed variable. e.g if smooth speed was 1 you would move the entire
                                                                                                   // distance in 1 frame, if smooth speed was .5 you would move half the way in 1 frame. 
        transform.position = smoothedPosition; // update transform position so it knows where to go after desired position is updated again.
    }
}
