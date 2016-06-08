using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class ButtonPressed : MonoBehaviour, IPointerDownHandler// required interface when using the OnPointerDown method.
{
    public bool Button1;
    public Player P1;
    public Player P2;


    public bool isInSandScene;
    public SandPlayer P1s;
    public SandPlayer P2s;
    //Do this when the mouse is clicked over the selectable object this script is attached to.
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isInSandScene)
        {
            if (Button1)
            {
                P1.ChangeDirection();
            }
            if (!Button1)
            {
                P2.ChangeDirection();
            }
        }
        if (isInSandScene)
        {
            if (Button1)
            {
                P1s.ChangeDirection();
            }
            if (!Button1)
            {
                P2s.ChangeDirection();
            }
        }
    }
}
