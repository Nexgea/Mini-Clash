using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public int direction;
    public int speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate( direction *speed, 0, 0);
	}
    void OnTriggerEnter2D ( Collider2D col)
    {
        if(transform.position.y>col.gameObject.transform.position.y)
        {
            transform.rotation = new Quaternion(direction * 100, 50, 0, 0);
        }
        if (transform.position.y < col.gameObject.transform.position.y)
        {
            transform.rotation = new Quaternion(direction* -100, 50, 0, 0);
        }
              
    }
}
