using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public GameObject[] buttons;
    public Button playButton;
    public int selected;
    public Sprite goldenBorder;
    public Sprite normalBorder;
    public LerpMovement lerpMovement;

    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;

    private bool isSwipe = false;
    private float minSwipeDist = 50.0f;
    private float maxSwipeTime = 0.5f;

	// Use this for initialization
	void Start () {
        Desert();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {

            foreach (Touch touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        /* this is a new touch */
                        isSwipe = true;
                        fingerStartTime = Time.time;
                        fingerStartPos = touch.position;
                        break;

                    case TouchPhase.Canceled:
                        /* The touch is being canceled */
                        isSwipe = false;
                        break;

                    case TouchPhase.Ended:

                        float gestureTime = Time.time - fingerStartTime;
                        float gestureDist = (touch.position - fingerStartPos).magnitude;

                        if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
                        {
                            Vector2 direction = touch.position - fingerStartPos;
                            Vector2 swipeType = Vector2.zero;

                            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                            {
                                // the swipe is horizontal:
                                swipeType = Vector2.right * Mathf.Sign(direction.x);
                            }
                            else
                            {
                                // the swipe is vertical:
                                swipeType = Vector2.up * Mathf.Sign(direction.y);
                            }

                            if (swipeType.x != 0.0f)
                            {
                                if (swipeType.x > 0.0f)
                                {
                                    Select(selected - 1);
                                }
                                else
                                {
                                    Select(selected +1);
                                }
                            }

                            if (swipeType.y != 0.0f)
                            {
                                if (swipeType.y > 0.0f)
                                {
                                    // MOVE UP
                                }
                                else
                                {
                                    // MOVE DOWN
                                }
                            }

                        }

                        break;
                }
            }
        }


	}

    public void Mine()
    {
        Select(1);
    }

    public void Desert()
    {
        Select(2);
    }

    public void Pool()
    {
        Select(3);
    }

    public void Planes()
    {
        Select(4);
    }
    public void Play()
    {
        Application.LoadLevel(selected);
    }
    void Select(int button)
    {
        if(button == 0 ) 
        {
            button = 1;
        }
        else if(button ==5)
        {
            button = 4;
        }
        else
        {
            lerpMovement.Move(button);
            selected = button;
            playButton.interactable = true;
            foreach (GameObject iconButton in buttons)
            {
                iconButton.transform.GetChild(0).GetComponent<Image>().sprite = normalBorder;
            }
            buttons[button - 1].transform.GetChild(0).GetComponent<Image>().sprite = goldenBorder;
        }
  
    }
}
