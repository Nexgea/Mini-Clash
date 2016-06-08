using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameControlManager : MonoBehaviour {
    private static GameControlManager instance = null;
    public static GameControlManager Instance
    {
        get { return instance; }
    }
    public int Player1Score;
    public int Player2Score;
    public Text Player1Counter;
    public Text Player2Counter;
    public Text Banner;
    public bool finished;
   public GameObject GameWin;
   public Text GameWinBar;
    void Awake()
    {

        finished = false;
        
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    
      
    }
    void SetValues()
    {

        GameObject canvas = GameObject.Find("Canvas");
        GameWin = canvas.transform.GetChild(canvas.transform.childCount-1).gameObject;
        GameWinBar = GameWin.transform.GetChild(0).gameObject.GetComponent<Text>();
        GameWin.SetActive(false);
        Player1Counter = GameObject.Find("Counter1").GetComponent<Text>();
        Player2Counter = GameObject.Find("Counter2").GetComponent<Text>();
        Banner = GameObject.Find("Banner").GetComponent<Text>();
       
        
        
    }
	// Use this for initialization
    void OnLevelWasLoaded()
    {
        finished = false;
        SetValues();
	}
	void Start()
    {
        
        
    }
	// Update is called once per frame
	void Update () {
        Player1Counter.text = Player1Score.ToString();
        Player2Counter.text = Player2Score.ToString();
     if(Player1Score>=5)
     {
         Player1Won();
     }
     if (Player2Score >= 5)
     {
         Player2Won();
     }
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.LoadLevel(0);
	}
    void Player1Won()
    {
        GameWin.SetActive(true);
        GameWinBar.text = "Blue wins";
    }
    void Player2Won()
    {
        GameWin.SetActive(true);
        GameWinBar.text = "Red wins";
    }
    public void AddPlayer1()
    {
        if (!finished)
        {
            Player1Score++;
            Player1Counter.text = Player1Score.ToString();
            Banner.text = "<color=#0F80C1AD>Blue</color> wins round";
            Invoke("NextGame", 1.5f);
            finished = true;
        }
    }
    public void AddPlayer2()
    {
        if(!finished)
        {
            Player2Score++;
            Player2Counter.text = Player2Score.ToString();
            Banner.text = "<color=#FE1435FF>Red</color> wins round";
            Invoke("NextGame", 1.5f);
            finished = true;
        }
    }
    void NextGame()
    {
        
        SceneManager.LoadScene(Application.loadedLevel);
       
    }
}
