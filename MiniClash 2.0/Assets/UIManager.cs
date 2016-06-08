using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    public GameObject pause;
    public GameObject credits;
    public GameControlManager GCM;
	// Use this for initialization
	void Start () {
        GCM = GameObject.Find("GameManager").GetComponent<GameControlManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        GCM.Player1Score = 0;
        GCM.Player2Score = 0;
        Application.LoadLevel(Application.loadedLevel);
    }
    public void NextGame()
    {
        Time.timeScale = 1;
        GCM.Player1Score = 0;
        GCM.Player2Score = 0;
        if(Application.loadedLevel == 4)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene(Application.loadedLevel+1, LoadSceneMode.Single);
        }
    }
    public void Home()
    {
        Time.timeScale = 1;
       SceneManager.LoadScene(0,  LoadSceneMode.Single);
    }
    public void Rate()
    {

    }
    public void Credits()
    {
        credits.SetActive(true);
        pause.SetActive(false);
    }
    public void BackFromCredits()
    {
        credits.SetActive(false);
        pause.SetActive(true);
    }
}
