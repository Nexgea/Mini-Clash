using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class PlaneButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPressing;
    public PlaneMovement plane;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

       plane.buttonPressed = isPressing ;
	}
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressing = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressing = false;
        plane.OnButtonRealese();
    }
}
