using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {
    public bool buttonPressed;
    public float strong;
    public float kvadratic;
    public float motor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (buttonPressed)
        {
            motor = motor + 0.05f;
        }
        else
        {
            if(motor>0.1f)
                motor = motor - 0.1f;
        }
        transform.Translate( motor,0,0);

	    if(buttonPressed)
        {
            if(strong <3)
            strong = strong +0.05f;
        }
        else
        {
            if (strong > -3)
            strong = strong -0.05f;
        }
        if(strong > 0)
        {
        kvadratic = strong * strong;
        }
        else
        {
            kvadratic = -(strong * strong);
        }

	}
    
}
