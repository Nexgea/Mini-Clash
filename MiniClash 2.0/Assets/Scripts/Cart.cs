using UnityEngine;
using System.Collections;

public class Cart : MonoBehaviour {
    public int leftright;
    public float speed;
    private int speedDirection;
    //left is 0
    //right is 1
	// Use this for initialization
	void Start () {
        leftright = Random.Range(0, 2);
        if (leftright == 0)
            speedDirection = -1;
        if (leftright == 1)
            speedDirection = 1;

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(speedDirection * speed, 0, 0));
	}
}
