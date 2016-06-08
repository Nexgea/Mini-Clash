using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
    public Transform targetPlane;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (targetPlane.position.y > transform.position.y + 5)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.position = new Vector3(targetPlane.position.x, 26, 0);
        }
        else
        {
            if (transform.GetChild(0).gameObject.active)
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
	}
}
