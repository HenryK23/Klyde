using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{ 
    //initialising variables
    public float backgroundSize;
    public float parallaxSpeed;
    public bool scrolling, parallax;

private Transform cameraTransform;
private Transform[] layers;
private float viewZone = 12f;
private int leftIndex;
private int rightIndex;
private float lastCameraX;

private void Start()
{
    cameraTransform = Camera.main.transform; // transforms main camera
    layers = new Transform[transform.childCount]; // counts how many children or tabs inside the object has. all of mine have 3 but just incase it counts.
    for(int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }
        leftIndex = 0; // left index is equal to 0 as that where it starts counting
        rightIndex = layers.Length - 1; // length starts counting at 1 so you need to take away 1 to have it work with index's
}
    private void Scrollleft() // script to scroll left
    {
        int lastRight = rightIndex; // the last right int gets filled with right index
        layers[rightIndex].position = Vector2.right * (layers[leftIndex].position.x - backgroundSize); // the x co-ord of the far right layer is changed to the far left one minus the width of the background taking it to exactly 1 background size ahead of the left one making it scroll
        leftIndex = rightIndex; // the left index now becomes the right one
        rightIndex--; // the right index the takes away one as it is in the middle not on the right
        if(rightIndex < 0) // if the right index falls below zero
            rightIndex = layers.Length-1; // set it back to its original number
    }
    private void Scrollright() // script to scroll right same as above but inversed. 
    {
        int lastleft = leftIndex;
        layers[leftIndex].position = Vector2.right * (layers[rightIndex].position.x + backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
            leftIndex = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (parallax) // public bool so can be easily disabled without touching code
        {
            float deltaX = cameraTransform.position.x - lastCameraX; // gets the position inbetween the two cameras x's 
            transform.position += Vector3.right * (deltaX * parallaxSpeed); // move the background to the left or right depending on the movement of the camera, if the parallax speed is 1 the background will move at the same speed at the camera, so its default in the minuses to make it look like the player is moving faster than he is
        }
        lastCameraX = cameraTransform.position.x;


        if (scrolling) // public bool so can be easily disabled without touching code
        {


            if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone)) // if the x co-ord of the camera is less than the x co-ord of the furthest left background + the viewzone then start scrolling left
            {
                Scrollleft();
            }
            if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone)) // same above but for the right
            {
                Scrollright();
            }
        }
    }
}
