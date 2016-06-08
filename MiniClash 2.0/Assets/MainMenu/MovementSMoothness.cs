using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MovementSMoothness : MonoBehaviour {
    public RectTransform targetTransform;
    public RectTransform thisTransform;
    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        thisTransform.localPosition = new Vector3(Mathf.Lerp(thisTransform.localPosition.x,targetTransform.localPosition.x,Time.deltaTime*speed), thisTransform.localPosition.y, thisTransform.localPosition.z);
	}
}
