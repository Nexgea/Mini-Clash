using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LerpMovement : MonoBehaviour {
    public RectTransform thisTransform;
    public int targetLocation;
    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	switch(targetLocation)
    {
        case 1:
            thisTransform.localPosition = new Vector3(Mathf.Lerp(thisTransform.localPosition.x,  800,Time.deltaTime * speed), thisTransform.localPosition.y, thisTransform.localPosition.z);
            Debug.Log("1");

            break;
        case 2:
            thisTransform.localPosition = new Vector3(Mathf.Lerp(thisTransform.localPosition.x, 0, Time.deltaTime * speed), thisTransform.localPosition.y, thisTransform.localPosition.z);
            break;
        case 3:
            thisTransform.localPosition = new Vector3(Mathf.Lerp(thisTransform.localPosition.x, -800, Time.deltaTime * speed), thisTransform.localPosition.y, thisTransform.localPosition.z);
            break;
        case 4:
            thisTransform.localPosition = new Vector3(Mathf.Lerp(thisTransform.localPosition.x, -1600, Time.deltaTime * speed), thisTransform.localPosition.y, thisTransform.localPosition.z);
            break;

    }
	}
    public void Move(int location)
    {
        targetLocation = location;
    }
}
