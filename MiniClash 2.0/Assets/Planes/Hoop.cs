using UnityEngine;
using System.Collections;

public class Hoop : MonoBehaviour {
    public bool avaible;
    public PointCounter PC1;
    public PointCounter PC2;
	// Use this for initialization
	void Start () {
        PC1 = GameObject.Find("Plane 1").GetComponent<PointCounter>();
        PC2 = GameObject.Find("Plane 2").GetComponent<PointCounter>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (avaible)
        {
            if (col.transform.tag == "Player 1")
            {
                PC1.AddPoint();
                avaible = false;
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.blue;
                transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.blue;
            }
            if (col.transform.tag == "Player 2")
            {
                PC2.AddPoint();
                avaible = false;
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
                transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

}
