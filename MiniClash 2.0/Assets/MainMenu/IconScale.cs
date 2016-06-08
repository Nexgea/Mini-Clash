using UnityEngine;
using System.Collections;

public class IconScale : MonoBehaviour {
    public RectTransform[] icons;
    public RectTransform thisTransform;
    public float xPos;
    public float recalculatedPos;
    public float targetedScale;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        xPos = -thisTransform.localPosition.x;
        if(xPos >=-1200 && xPos <-400 )
        {
            recalculatedPos = (xPos + 800) / 400;
            if (xPos > -800)
            {
                targetedScale = 1 / (recalculatedPos + 1) + 0.5f;
            }
            if (xPos < -800)
            {
                targetedScale = -(1 / (recalculatedPos - 1) + 0.5f) + 1f;
            }
            icons[0].localScale = new Vector3(targetedScale, targetedScale, 1);
        }
        else if (xPos > -400 && xPos < 400)
        {
            recalculatedPos = (xPos ) / 400;
            if (xPos >= 0)
            {
                targetedScale = 1 / (recalculatedPos + 1) + 0.5f;
            }
            if (xPos < 0)
            {
                targetedScale = -(1 / (recalculatedPos - 1) + 0.5f) + 1f;
            }
            icons[1].localScale = new Vector3(targetedScale, targetedScale, 1);
        }
        else if (xPos > 400 && xPos < 1200)
        {
            recalculatedPos = (xPos-800) / 400;
            if (xPos > 800)
            {
                targetedScale = 1 / (recalculatedPos + 1) + 0.5f;
            }
            if (xPos < 800)
            {
                targetedScale = -(1 / (recalculatedPos - 1) + 0.5f) + 1f;
            }
            icons[2].localScale = new Vector3(targetedScale, targetedScale, 1);
        }
        else if (xPos > 1200 && xPos < 20000)
        {
            recalculatedPos = (xPos - 1600) / 400;
            if (xPos > 1600)
            {
                targetedScale = 1 / (recalculatedPos + 1) + 0.5f;
            }
            if (xPos < 1600)
            {
                targetedScale = -(1 / (recalculatedPos - 1) + 0.5f) + 1f;
            }
            icons[3].localScale = new Vector3(targetedScale, targetedScale, 1);
        }
	}
}
