using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {
    public int speed;
    public float smallSpeed;
    public float floatSpeed;
	// Use this for initialization
	void Start () {
       speed = Random.Range(70, 100);
        floatSpeed = speed;
        smallSpeed = floatSpeed / 3000;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(smallSpeed, 0, 0));
	}
}
