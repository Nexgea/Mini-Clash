using UnityEngine;
using System.Collections;

public class Stick : MonoBehaviour {

    public GameObject CorrectPlace;
    public Swimmer swimmer;

    public float counter;
    public float sinCounter;
    public float stickRange;
    public float stckSpeed;
    public float offset;

    private bool moving;
    private float randomX;
    public Sprite normalIndicator, bannedIndicator;
    public float height;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
        counter = counter + stckSpeed;
        sinCounter = Mathf.Sin(counter);
        transform.localPosition = new Vector3(sinCounter * stickRange + offset, height, 0);
        }
	}
    public void Pressed()
    {
        float diference = Mathf.Abs(CorrectPlace.transform.localPosition.x - transform.localPosition.x);
        if (diference < 2)
        {
            moving = false;
            swimmer.MakeTempo(diference);
            Invoke("AnotherTempo", 0);
        }
        else
        {
            FailedTempo();
        }
    }
    void FailedTempo ()
    {
        moving = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = bannedIndicator;
        Invoke("Unban", 1);
    }
    void Unban()
    {
        moving = true;
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = normalIndicator;
    }
    void AnotherTempo()
    {
        moving = true;
        randomX = Random.value;
        if (Random.value < 0.5)
        {
            randomX = -randomX;
        }
        CorrectPlace.transform.localPosition = new Vector3(randomX * stickRange*0.8f, height, 0);
    }
}
