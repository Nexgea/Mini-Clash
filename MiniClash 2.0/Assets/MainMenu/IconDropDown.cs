using UnityEngine;
using System.Collections;

public class IconDropDown : MonoBehaviour {
    public float timeOffset;
    public float speed;
    public GameObject[] buttons;
	// Use this for initialization
	void Start () {
        StartCoroutine(IconJumps());
	for (int i = 0;i<5;i++)
    {
        ButtonDropDown(i);
    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void ButtonDropDown(int position)
    { 

        StartCoroutine(Play(position));
       
    }
     private IEnumerator Play(int seconds)
    {
        yield return new WaitForSeconds(seconds*seconds*timeOffset);

        buttons[seconds].GetComponent<Animation>().Play();
    }
     private IEnumerator IconJumps()
     {
         yield return new WaitForSeconds(0.8f);
       
     }
}
