using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class MazeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool Player1;

    public Paintballer Paintballer1;
    public Paintballer Paintballer2;
    public MazeButton OtherButton;
    public bool touched;
    private float counter= 90;
    public Image Border;
    public Text textPlayer;

    public void OnPointerDown(PointerEventData eventData)
    {
        touched = true;
        CheckFirstTouch();
        if (Player1)
        {
            Paintballer1.Pressed();
        }
        if (!Player1)
        {
            Paintballer2.Pressed();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        if (Player1)
        {
            Paintballer1.Released();

        }
        if (!Player1)
        {
            Paintballer2.Released();
        }
    }
    void Update()
    {
        if(!touched)
        CheckFirstTouch();
    }
    void CheckFirstTouch()
    {
         if(touched)
         {
             GameStarted();
           OtherButton.GameStarter();

         }
         else
         {
             counter +=0.05f ;
            Border.gameObject.GetComponent<Image>().color = new Color( 
            Border.gameObject.GetComponent<Image>().color.r,
            Border.gameObject.GetComponent<Image>().color.g,
            Border.gameObject.GetComponent<Image>().color.b,
                 Mathf.Sin(counter));
          textPlayer.gameObject.GetComponent<Text>().color = new Color(
          textPlayer.gameObject.GetComponent<Text>().color.r,
          textPlayer.gameObject.GetComponent<Text>().color.g,
          textPlayer.gameObject.GetComponent<Text>().color.b,
                Mathf.Sin(counter));
       this.gameObject.GetComponent<Image>().color = new Color(
       this.gameObject.GetComponent<Image>().color.r,
       this.gameObject.GetComponent<Image>().color.g,
       this.gameObject.GetComponent<Image>().color.b,
           0);

         }
    }
    void GameStarted()
    {
       
        touched = true;
        this.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        Border.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        textPlayer.gameObject.GetComponent<Text>().color = new Color(0, 0, 0, 0);
    }
    public void GameStarter()
    {
        GameStarted();
    }
}