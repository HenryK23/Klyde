using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour

{
    public GameObject Cannonball;
    public GameObject LftCannonball;
    public GameObject RedCannonball;
    public GameObject LftRedCannonball;
    public GameObject YlwCannonball;
    public GameObject LftYlwCannonball;
    public walrusBackground PartyTime;
    public Transform LaunchPoint;
    public float ShotTimer;
    private float PShotTimer;
    public bool left;
    public bool Disco;
    public GameObject DiscoBall;
    public bool red;
    public bool yellow;
    public bool blue;
    public bool white;
    public GameObject[] RightCannonballs;
    public GameObject[] LeftCannonBalls;
    public AudioClip Cfire;
    AudioSource audio;





    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        PShotTimer = ShotTimer;
        if (transform.localScale.x < 0)
        {
            left = true;
        }
        else
        {
            left = false;
        }



    }

    // Update is called once per frame
    void Update()
    {
        if (!blue && !red && !yellow && !white)
        {
            Disco = PartyTime.DiscoTime;
        }
        PShotTimer -= Time.deltaTime;

        if (blue)
        {
            if (PShotTimer < 0 && left)
            {
                Instantiate(RightCannonballs[0], LaunchPoint.position, LaunchPoint.rotation);
                PShotTimer = ShotTimer;
                audio.Play();
            }

            if (PShotTimer < 0 && !left)
            {
                Instantiate(LeftCannonBalls[0], LaunchPoint.position, LaunchPoint.rotation);
                PShotTimer = ShotTimer;
                audio.Play();
            }

        }
        if (red)
        {
            if (PShotTimer < 0 && left)
            {
                Instantiate(RightCannonballs[1], LaunchPoint.position, LaunchPoint.rotation);
                PShotTimer = ShotTimer;
                audio.Play();
            }

            if (PShotTimer < 0 && !left)
            {
                Instantiate(LeftCannonBalls[1], LaunchPoint.position, LaunchPoint.rotation);
                PShotTimer = ShotTimer;
                audio.Play();
            }
        }
        if (yellow)
        {
            if (PShotTimer < 0 && left)
            {
                Instantiate(RightCannonballs[2], LaunchPoint.position, LaunchPoint.rotation);
                PShotTimer = ShotTimer;
                audio.Play();
            }

            if (PShotTimer < 0 && !left)
            {
                Instantiate(LeftCannonBalls[2], LaunchPoint.position, LaunchPoint.rotation);
                PShotTimer = ShotTimer;
                audio.Play();
            }

        }
        if (Disco)
        {

            if (PShotTimer < 0 && !left)
            {
                Instantiate(RightCannonballs[UnityEngine.Random.Range(0, RightCannonballs.Length)], LaunchPoint.position, LaunchPoint.rotation);
                PShotTimer = ShotTimer;
            }
            
        }
    }

    void FixedUpdate()
    {
        if (Disco)
        {
            transform.RotateAround(Vector3.zero, Vector3.forward, Time.deltaTime * 200);
        }
    }
}
