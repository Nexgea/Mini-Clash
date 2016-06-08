using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public bool Player1;
    public float distToGround;
    public bool started;
    public float speed;
    public float direction;
    private float starter;
    public GameControlManager GCM;
    public Spawner S;
    public int hp = 1;
    public GameObject VisualHP;
    public GameObject Graphics;

	// Use this for initialization
	void Start () {
        GCM = GameObject.FindGameObjectWithTag("GameControlManager").GetComponent<GameControlManager>();
        if (Player1)
            direction = 1;

        if (!Player1)
            direction = -1;
	}
	
	// Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * starter, 0, 0);
      
	}

  public  void ChangeDirection()
    {
        S.StartSpawning();
        if (!started)
        {
            started = true;
            starter = 1;
            Graphics.transform.localScale = new Vector3(1 * direction, 1, 1);
        }

        else
        {
            direction = -direction;

            Graphics.transform.localScale = new Vector3(1 * direction, 1, 1);
        }
        
    }
    void ChangeBumpDirection()
    {
        started = true;
        starter = 1;
        direction = -direction;
            Graphics.transform.localScale = new Vector3(1 * direction, 1, 1);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.transform.tag == "Player 1" || col.gameObject.transform.tag == "Player 2")
        {
            ChangeBumpDirection();
        }
        if (col.gameObject.transform.tag == "Obstacle")
        {
            Damage();
        }
        if (col.gameObject.transform.tag == "Heart")
        {
            Destroy(col.gameObject);
            hp++;
            RecalculateHp();
        }
    }
    void RecalculateHp()
    {
       switch(hp)
       {
           case 1:
               VisualHP.SetActive(false);
               break;
           case 2 :
               VisualHP.SetActive(true);
               break;
       }
    }
    void Damage()
    {
       
        if(Player1)
        {
            hp--;
            RecalculateHp();
            if (hp == 0)
            {
                Dead();
                GCM.AddPlayer2();
            }
        }
        if(!Player1)
        {
            RecalculateHp();
            hp--;
            if (hp == 0)
            {
                Dead();
                GCM.AddPlayer1();
            }
        }
    }
    void Dead()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().AddTorque(100000);
    }
}
