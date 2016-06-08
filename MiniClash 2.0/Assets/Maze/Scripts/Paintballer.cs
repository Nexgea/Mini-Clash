using UnityEngine;
using System.Collections;

public class Paintballer : MonoBehaviour {
    public bool isPressed;
    public float rotateSpeed;
    public float movementSpeed;
    public int direction;
    public float rateOfFire;
    public float currentRateOfFire;
    public Transform ballSocket;
    public GameObject ball;
    public bool isDead;
    public GameControlManager GCM;

    public bool hasShotgun;
    public bool hasAgility;
    public bool isGhost;
    public int shotgunAngels;
    private float sinCounter;
    void Start()
    {
        GCM = GameObject.Find("GameManager").GetComponent<GameControlManager>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.gameObject.tag == "Shotgun")
        {
            hasShotgun = true;
            Destroy(col.transform.gameObject);
        }
         if(col.transform.gameObject.tag == "Ghost")
        {
            isGhost = true;
            Destroy(col.transform.gameObject);
            transform.gameObject.layer = 10;
          
        }
        if(col.transform.gameObject.tag == "Boots")
        {
            hasAgility = true;
            movementSpeed = 12;
            rotateSpeed = 3;
            Destroy(col.transform.gameObject);
        }
    }
	public void Dead()
    {
        if (!isDead)
        {
            isDead = true;
            if (direction == -1)
            {
                GCM.AddPlayer1();
            }
            if (direction == 1)
            {
                GCM.AddPlayer2();
            }
        }
    }
    public static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    public static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }
	// Update is called once per frame
	void Update () {
        if(isGhost)
        {
        sinCounter += 0.05f;
            transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1,  0.33f + Mathf.Abs(Mathf.Sin(sinCounter))/3);
            
        }
        currentRateOfFire += Time.deltaTime;
	    if(isPressed)
        {
            Vector2 dir = DegreeToVector2(transform.eulerAngles.z);
            GetComponent<Rigidbody2D>().velocity = new Vector2(dir.x * movementSpeed*direction,  dir.y * movementSpeed*direction);
            if (currentRateOfFire > rateOfFire)
            {
                if(hasShotgun)
                {
                ShootTriple();
                }
                else
                {
                    Shoot();
                }
                currentRateOfFire = 0;
            }
        }
        if (!isPressed) 
        {

            transform.Rotate(new Vector3(0, 0, 1*rotateSpeed)*Time.timeScale);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        }
	}
    void Shoot()
    {
        Instantiate(ball, ballSocket.position, ballSocket.rotation);
    }
    void ShootTriple()
    {
        
        Instantiate(ball, ballSocket.position, ballSocket.rotation);
        Instantiate(ball, ballSocket.position, Quaternion.Euler(new Vector3(ballSocket.eulerAngles.x, ballSocket.eulerAngles.y, ballSocket.eulerAngles.z - shotgunAngels)));
        Instantiate(ball, ballSocket.position, Quaternion.Euler(ballSocket.eulerAngles.x, ballSocket.eulerAngles.y, ballSocket.eulerAngles.z + shotgunAngels));
    }
    public void Pressed ()
    {
        isPressed = true;
    }
    public void Released()
    {
        isPressed = false;
    }
}
