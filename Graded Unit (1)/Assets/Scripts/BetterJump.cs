using UnityEngine;


public class BetterJump : MonoBehaviour
{
    public float jumpVelocity;
    public bool isSliding;
    public bool isJumping;
    int i = 0;
    public float Speed;
    private float Scale, x, y, ColX, ColY;
    public AudioClip walk, jump, slide; 
    Rigidbody2D rb;
    CapsuleCollider2D CapCol;
    Animator anim;
    ColourSwitch colour;
    BoxCollider2D BoxCol;
    AudioSource audio;
    

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        CapCol = GetComponent<CapsuleCollider2D>();
        BoxCol = GetComponent<BoxCollider2D>();
        Scale = this.transform.localScale.x;
        ColX = CapCol.size.x;
        ColY = CapCol.size.y;
        anim = GetComponent<Animator>();
        colour = GetComponent<ColourSwitch>();
        audio = GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if (isJumping == false)
            {

                if (isSliding == false)
                {                    
                    
                    GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
                    audio.PlayOneShot(jump,0.3f);
                    isJumping = true;                    
                }
            }
        }

        if (Input.GetButtonDown("Slide"))
        {
            if(isJumping == false)
            {
                if (move > 0 || move < 0)
                {
                    x = rb.position.x;
                    y = rb.position.y;
                    CapCol.size = new Vector2(ColY, ColX);
                    CapCol.direction = CapsuleDirection2D.Horizontal;
                    BoxCol.enabled = false;
                    isSliding = true;
                    audio.PlayOneShot(slide,0.7f);
                    this.gameObject.transform.position = new Vector2 (this.gameObject.transform.position.x, this.gameObject.transform.position.y - 0.6f);
                    rb.velocity = new Vector2(10 * move, rb.velocity.y);                    
                    Invoke("EndSlide", 0.7f);
                    
                }
            }
        }

        if (!isSliding)
        {
            {
                rb.velocity = new Vector2(Speed * move, rb.velocity.y);
            }
            if (move > 0f)
            {
                transform.localScale = new Vector2(Scale, Scale);
                if (isJumping == false)
                { 
                    if (i == 15)
                    {
                        audio.PlayOneShot(walk, 0.4f);
                        i = 0;
                    }
                    i++;
                }
            }
            if (move < 0f)
            {
                transform.localScale = new Vector2(-1 * Scale, Scale);

                if (isJumping == false)
                {
                    if (i == 15)
                    {
                        audio.PlayOneShot(walk, 0.4f);
                        i = 0;
                    }
                    i++;
                }

            }
            
        }

    }

    //Check for Collision with new object
    void OnTriggerEnter2D(Collider2D other)
    {
        //Checks for "Solid" tag to check for ability to jump
        if (other.gameObject.CompareTag("Solid") || other.gameObject.CompareTag(this.tag))
        {
            if (other.gameObject.tag != "Untagged")
            {
                isJumping = false;
                rb.velocity = Vector2.zero;
            }
        }
    }

    void OnTriggerEexit2D(Collider2D other)
    {
        //Checks for "Solid" tag to check for ability to jump
        if (other.gameObject.CompareTag("Solid") || other.gameObject.CompareTag(this.tag))
        {
            isJumping = true;
            rb.velocity = Vector2.zero;
        }
    }



    void EndSlide()
    {
        CapCol.size = new Vector2(ColX, ColY);
        CapCol.direction = CapsuleDirection2D.Vertical;
        BoxCol.enabled = true;
        isSliding = false;
    }
}
