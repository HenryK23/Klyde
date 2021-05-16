using UnityEngine;
using System.Collections;

public class PP : MonoBehaviour
{

    public float distance = 1f;
    public LayerMask boxMask;
    GameObject box;
    AudioSource audio;
    public bool a = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (hit.collider.gameObject.name.Contains("PP") && hit.collider != null && Input.GetKeyDown(KeyCode.E))
        {
            if (hit.collider.gameObject.CompareTag(this.tag))
            {
                box = hit.collider.gameObject;
                box.GetComponent<FixedJoint2D>().enabled = true;
                box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
                audio  = box.GetComponent<AudioSource>();
                audio.Play();
            }
        }

        else if (Input.GetKeyUp(KeyCode.E))
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
            audio = box.GetComponent<AudioSource>();
            audio.Pause();
        }

    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + (Vector2.right * transform.localScale.x) * distance);



    }
}