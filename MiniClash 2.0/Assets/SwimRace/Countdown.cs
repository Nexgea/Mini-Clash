using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {
    private int count = 3;
    public Text Counter;
    public Swimmer swimmer;
    public Swimmer swimmer2;
	// Use this for initialization
	void Start () {
        InvokeRepeating("countdown", 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
    }
    void countdown()
    {
        count--;

        if (count == 0)
        {
            Counter.text = "Go";
            swimmer.gameStarted = true;
            swimmer2.gameStarted = true;
        }
        else
        {
            Counter.text = count.ToString();
        }
        if(count < 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
