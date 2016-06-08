using UnityEngine;
using System.Collections;

public class PaintballBall : MonoBehaviour {
    public float speed;
    public int direction;
    public GameControlManager GCM;
    public GameObject Splah;
    public float splashOffset;
	// Use this for initialization
	void Start () {
        GCM = GameObject.Find("GameManager").GetComponent<GameControlManager>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 dir = DegreeToVector2(transform.eulerAngles.z);
        GetComponent<Rigidbody2D>().velocity = new Vector2(dir.x * speed *direction , dir.y * speed *direction);
	}
    public static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    public static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.transform.tag == "Wall")
        {
              Vector2 dir = DegreeToVector2(transform.eulerAngles.z);
            Instantiate(Splah, new Vector3 (transform.position.x + dir.x *splashOffset,transform.position.y+dir.y *splashOffset,transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (col.collider.transform.tag == "Player 1")
        {
            if (direction == -1)
            {
                col.collider.gameObject.GetComponent<Paintballer>().Dead();
                Destroy(this.gameObject);
            }
        }
        if (col.collider.transform.tag == "Player 2")
        {
            if (direction == 1)
            {
                col.collider.gameObject.GetComponent<Paintballer>().Dead();
                Destroy(this.gameObject);
            }
        }
        
    }
}
