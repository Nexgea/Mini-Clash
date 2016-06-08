using UnityEngine;
using System.Collections;

public class SandPlayer : MonoBehaviour {
    public bool Player1;
    public int direction;
    public int speed;
    public bool shooted;
    public GameObject Bullet;
    public Transform bulletSocket;
	// Use this for initialization
	void Start () {
	transform.position = new Vector3(transform.position.x, Random.Range(-70,70),0 );
        if(Player1)
        {
            direction = 1;
        }
        if (!Player1)
        {
            direction = -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, direction * speed, 0));
	if(transform.position.y>65)
    {
        direction = -1;
    }
    if (transform.position.y < -65)
    {
        direction = 1;
    }
	}
    public void ChangeDirection()//Shoot
    {
        if(!shooted)
        {
            Shoot();
            shooted = true;
        }
        if (shooted)
        {
            SwapDirection();
        }
    }
    void Shoot()
    {
        var temp = Instantiate(Bullet, bulletSocket.position, new Quaternion(0,0,0,0)) as GameObject;
        if (Player1)
        {
            temp.GetComponent<Bullet>().direction = 1;
        }
        if (!Player1)
        {
            temp.GetComponent<Bullet>().direction = -1;
        }
    }
    void SwapDirection()
    {
        direction = -direction;
    }
}
