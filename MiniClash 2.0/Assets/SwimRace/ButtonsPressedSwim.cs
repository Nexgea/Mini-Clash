using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class ButtonsPressedSwim : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool Player1;

    public Stick stick1;
    public Stick stick2;
    public Swimmer swimmer;
    public bool firstTouch;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!firstTouch)
        {
            firstTouch = true;
            swimmer.JumpIntoWater();
        }
      
        if(Player1)
        {
            stick1.Pressed();
        }
        if (!Player1)
        {
            stick2.Pressed();
        }
    
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
        if (Player1)
        {

            
        }
        if (!Player1)
        {
           
        }
    }
}
