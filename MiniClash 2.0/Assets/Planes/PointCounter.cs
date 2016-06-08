using UnityEngine;
using System.Collections;

public class PointCounter : MonoBehaviour {
    public int points;
    public GameControlManager GCM;
    public bool Player1;
	// Use this for initialization
	void Start () {
        GCM = GameObject.Find("GameManager").GetComponent<GameControlManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void AddPoint()
    {
        points++;
        if(points>= 3)
        {
            if(Player1)
            {
            GCM.AddPlayer1();
            }
            else
            {
            GCM.AddPlayer2();
            }

        }
    }
}
