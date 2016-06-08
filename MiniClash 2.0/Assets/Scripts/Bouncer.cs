using UnityEngine;
using System.Collections;

public class Bouncer : MonoBehaviour {
    public bool Left;
    public Transform BouncerL;
    public Transform BouncerR;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.transform.tag == "Player 1" || col.gameObject.transform.tag == "Player 2")
        {
            if (Left)
            {
                col.gameObject.transform.position = new Vector3(BouncerR.transform.position.x-6, col.gameObject.transform.position.y, 0);
            }
            if (!Left)
            {
                col.gameObject.transform.position = new Vector3(BouncerL.transform.position.x +8, col.gameObject.transform.position.y, 0);
            }
        }
    }
}
