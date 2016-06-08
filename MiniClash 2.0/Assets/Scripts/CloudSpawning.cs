using UnityEngine;
using System.Collections;

public class CloudSpawning : MonoBehaviour {
    public GameObject[] Clouds;
    public Transform CloudSocket;
	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnCloud", 0, 24);
        SpawnFirst();
	}
	
	
	void SpawnCloud () {
        Instantiate(RandomCloud(), new Vector3(CloudSocket.position.x , CloudSocket.position.y + Random.Range(-7, 7), 0), transform.rotation);
	}
    void SpawnFirst()
    {
        Instantiate(RandomCloud(),  new Vector3(CloudSocket.position.x+Random.Range(35,45),CloudSocket.position.y+Random.Range(-7,7),0), transform.rotation);
    }
    GameObject RandomCloud()
    {
        GameObject randomCLoud = Clouds[Random.Range(0, Clouds.GetLength(0))];
        return randomCLoud;
    }
}
