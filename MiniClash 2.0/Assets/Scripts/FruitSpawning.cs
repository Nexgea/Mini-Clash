using UnityEngine;
using System.Collections;

public class FruitSpawning : MonoBehaviour {
    public GameObject[] Fruit;
	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnFruit", 0, 1);
	}
    void SpawnFruit()
    {
       var temp =  Instantiate(RandomFruit(), new Vector3(transform.position.x, transform.position.y , 0), transform.rotation) as GameObject;
       temp.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-1000, 1000));
    }
	// Update is called once per frame
	void Update () {
	
	}
    GameObject RandomFruit()
    {
        GameObject randomFruit = Fruit[Random.Range(0, Fruit.GetLength(0))];
        return randomFruit;
    }
}
