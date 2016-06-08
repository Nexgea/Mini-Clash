using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour {
    public GameObject ShotgunPowerUp;
    public GameObject BootsPowerUp;
    public GameObject GhostPowerUp;
	// Use this for initialization
	void Start () {
	if(Random.value>0.33f)
    {
        SpawnShotgun();
    }
    if (Random.value > 0.33f)
    {
        SpawnBoots();
    }
    if (Random.value > 0.33f)
    {
        SpawnGhost();
    }
	}
	void SpawnShotgun()
    {
        Instantiate(ShotgunPowerUp, RandomLocation(), Quaternion.identity);
    }
    void SpawnBoots()
    {
        Instantiate(BootsPowerUp, RandomLocation(), Quaternion.identity);
    }
    void SpawnGhost()
    {
        Instantiate(GhostPowerUp, RandomLocation(), Quaternion.identity);
    }
	// Update is called once per frame
	void Update () {
	
	}
    Vector3 RandomLocation()
    {
        int randomX = Random.Range(0, 6);
        int randomY = Random.Range(0, 3);
        return new Vector3(randomX * 8, -randomY * 8, 0);
    }
}
