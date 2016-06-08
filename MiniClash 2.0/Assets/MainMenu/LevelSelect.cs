using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LevelSelect : MonoBehaviour {
    public RectTransform baitTransform;
    public RectTransform thisTransform;
    public float xOffset;
    public float offset;
    public bool disable;
    public bool disable2;
    public float speed;
    public int currentPosition;
    public bool changeablePos;
    public Vector3 lastPos;
    public float tolerance;
    public CanvasGroup canvasGroup;
	// Use this for initialization
	void Start () {
	
	}
	

	// Update is called once per frame
	void Update () {
       // Debug.Log(((Mathf.Abs(((currentPosition-2)*800) -offset ).ToString())));
        if (currentPosition == 1 && Mathf.Abs(800 - offset) > tolerance)
        {
            canvasGroup.blocksRaycasts = false;
        }
     
       else if (currentPosition == 2 && Mathf.Abs(0 - offset) > tolerance)
        {
            canvasGroup.blocksRaycasts = false;
        }
   
      else  if (currentPosition == 3 && Mathf.Abs(-800 - offset) > tolerance)
        {
            canvasGroup.blocksRaycasts = false;
        }
 
       else if (currentPosition == 4 && Mathf.Abs(-1600 - offset) > tolerance)
        {
            canvasGroup.blocksRaycasts = false;
        }
        else
        {
            canvasGroup.blocksRaycasts = true;
        }
       
        Vector3 curPos = transform.position;
        if (Mathf.Abs(thisTransform.localPosition.x - ((1 - 2) * ((currentPosition - 2) * 800))) > 1 && !(Input.GetMouseButton(0)) && (curPos == lastPos))
        {
            Move();
            
        }
        lastPos = curPos;
     
        if (baitTransform.localPosition.x > 400)
        {
            if (!(currentPosition == 1))
            {
                DetectCurrentPosition(-1);
                disable = true;
               
            }
        }
        if (baitTransform.localPosition.x < -400)
        {
            if (!(currentPosition == 4))
            {
                DetectCurrentPosition(1);
                disable = true;
                
            }
        }
            if (disable)
            {
                Move();
               
            }
           
            thisTransform.localPosition = new Vector3(baitTransform.localPosition.x + offset, thisTransform.localPosition.y, thisTransform.localPosition.z);
	}
    void Move() {
        xOffset = Mathf.Lerp(xOffset, -((currentPosition - 2) * 800)-400, Time.deltaTime * speed);
        offset = 400 - baitTransform.localPosition.x + xOffset;
        if(Mathf.Abs(thisTransform.localPosition.x -((1-2)*((currentPosition - 2) * 800))) <1f)
        {
           disable = false;
        }
      
    }
   
    void FinishMove()
    {
      //  disable = false;
    }
   
    void DetectCurrentPosition(int add)
    {
        if (changeablePos)
        {
            changeablePos = false;
            Invoke("EnableChangePos",0.2f);
            currentPosition = currentPosition + add;
        }
    }
    void EnableChangePos()
    {
        changeablePos = true;
    }
}
