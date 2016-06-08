using UnityEngine;
using System.Collections;

public class HoopSpawn : MonoBehaviour {
    public GameObject HoopNeutral;
    public GameObject HoopRed;
    public int numberOfHoops;
	// Use this for initialization
	void Start () {

        for (int i = 0; i < numberOfHoops; i++)
        {
            Instantiate(HoopNeutral, RandomHoopPosition(), transform.rotation);
        }


	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public Vector3 RandomHoopPosition()
    {
        int x = Random.Range(78, 678);
        int y = Random.Range(-15, 20);
        return new Vector3(x / 10, y, 0);
    }
}
