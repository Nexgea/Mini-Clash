using UnityEngine;
using System.Collections;

public class Swimmer : MonoBehaviour {
    public int state;
    //0 jump
    //1 underwater swim
    //2 normal swim
    public float jumpSpeed;
    public float jumpDistance;
    public bool Player1;
    public GameControlManager GCM;

    public bool gameStarted;

    private float jumpOffset;
    public bool isJumping;
    private bool firstClick;

    public float underWaterSpeed;
    public float slowingSpeed;

    public int clickSpeed;
    private float emergeLocation;
    public float multipliedSpeed;
    private bool reverseDirection;
    private SwimAnimations swimAnimations;
    private SpriteRenderer graphic;
    private SpriteRenderer graphic2;
    private bool firstTouch;
   
    // Use this for initialization
	void Start () {
        jumpOffset = transform.position.x + jumpDistance;
        slowingSpeed = underWaterSpeed;
        emergeLocation = transform.position.x;
        swimAnimations = gameObject.GetComponent<SwimAnimations>();
        graphic = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>() ;
        graphic2 = transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
        GCM = GameObject.Find("GameManager").GetComponent<GameControlManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if (isJumping)
        {
           // transform.position = new Vector3(Mathf.Lerp(transform.position.x, jumpOffset, jumpSpeed * Time.deltaTime), transform.position.y, 0);
            transform.Translate(0.2f, 0, 0);
        }
        if(transform.position.x>=55)
        {
            reverseDirection = true;
            if(Player1)
            graphic.flipX = true;
            if(!Player1)
            graphic2.flipX = true;
        }
        if(!reverseDirection)
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, emergeLocation + multipliedSpeed,Time.deltaTime), transform.position.y, 0);
        if (reverseDirection)
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, 55 -multipliedSpeed+105,  Time.deltaTime), transform.position.y, 0);
        if(reverseDirection)
        {
            if(transform.position.x<=-55)
            {
                if(Player1)
                {
                GCM.AddPlayer1();
                }
                else
                {
                    GCM.AddPlayer2();
                }
            }
        }
	
	}

    public void Pressed()
    {
        if (gameStarted)
        {
            if (!firstClick)
            {
                JumpIntoWater();
                firstClick = true;
            }
        }
    }
    
    public void JumpIntoWater()
    {
        swimAnimations.Jump();
        isJumping = true;
        Invoke("StopJumping", 1f);
    }
    void StopJumping()
    {
        isJumping = false;
        state = 1;
      
    }
    public void MakeTempo(float diference)
    {
        if(firstTouch)
        {
        swimAnimations.Tempo();
        }
        firstTouch = true;
     
        clickSpeed++;
        multipliedSpeed=clickSpeed * 15;
    }
}
