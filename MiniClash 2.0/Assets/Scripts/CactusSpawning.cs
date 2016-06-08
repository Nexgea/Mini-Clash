using UnityEngine;
using System.Collections;

public class CactusSpawning : MonoBehaviour {
    public GameObject[] Cactus;
    public int cactussCount;
	// Use this for initialization
	void Start () {
        for (int i = cactussCount; i > 0; i--)
        {
            SpawnCactus();
        }
	}

    void SpawnCactus()
    {
        Instantiate(RandomCactus(), new Vector3(Random.Range(-80, 80), Random.Range(-70, 60), 0), transform.rotation);
    }
	// Update is called once per frame
	void Update () {
	
	}
    GameObject RandomCactus()
    {
        GameObject randomCactus = Cactus[Random.Range(0, Cactus.GetLength(0))];
        return randomCactus;
    }
}
