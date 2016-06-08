using UnityEngine;
using System.Collections;

public class MainMenuUI : MonoBehaviour {
    public GameObject credits;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Credits()
    {
        credits.SetActive(true);
    }
    public void Rate()
    {
        Application.OpenURL("market://details?id=com.nexgea.miniclash");
    }
    public void BackFromCredits()
    {
        credits.SetActive(false);
    }
}
