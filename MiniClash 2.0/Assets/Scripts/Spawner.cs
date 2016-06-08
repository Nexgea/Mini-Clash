using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public GameObject Obstacle1;
    public GameObject Obstacle2;
    public GameObject Obstacle3;
    public GameObject Obstacle4;
    public GameObject heart;
    public int height;
    public Transform BouncerL;
    public Transform BouncerR;
    public bool startedSpawning;
	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void StartSpawning()
    {
        if(!startedSpawning)
        {
            InvokeRepeating("Spawn", 0, 1);
            InvokeRepeating("Spawn", 3, 5);
            InvokeRepeating("Spawn", 8, 3);
            InvokeRepeating("Spawn", 20, 3);
            InvokeRepeating("SpawnHeart", Random.Range(5,10), Random.Range(5,12));
            startedSpawning = true;
        }
    }
     void Spawn()
    {
        GameObject temp = Instantiate(RandomGameObject(), RandomPosition(), transform.rotation) as GameObject;
        temp.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-1000, 1000));
    }
     void SpawnHeart()
     {
         GameObject temp = Instantiate(heart, RandomPosition(), transform.rotation) as GameObject;
         temp.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-1000, 1000));
     }
    GameObject RandomGameObject()
    {
        GameObject SelectedGameObject = Obstacle1;
        int r = Random.Range(1, 4);
        switch (r)
        {
            case 1:
                SelectedGameObject = Obstacle1;
                break;
            case 2:
                SelectedGameObject = Obstacle2;
                break;
            case 3:
                SelectedGameObject = Obstacle3;
                break;
            case 4:
                SelectedGameObject = Obstacle4;
                break;
        }
        return SelectedGameObject;
    }
    Vector3 RandomPosition()
    {
        int x = Random.Range(Mathf.RoundToInt(BouncerL.transform.position.x + 16), Mathf.RoundToInt(BouncerR.transform.position.x - 16));
        return new Vector3(x, height, 0);
    }
}
