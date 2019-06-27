using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public int highscore;
    public Text highscoretext;
    public GameObject startscreen;
    public GameObject creditscreen;
    public GameObject howtoplay1;
    public GameObject howtoplay2;
    public GameObject howtoplay3;

	// Use this for initialization
	void Start () {

        highscore = PlayerPrefs.GetInt("highscore", highscore);
        highscoretext.text = "" + highscore;
        startscreen.gameObject.SetActive(true);
        creditscreen.gameObject.SetActive(false);
        howtoplay1.gameObject.SetActive(false);
        howtoplay2.gameObject.SetActive(false);
        howtoplay3.gameObject.SetActive(false);

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Creditscene()
    {
        startscreen.gameObject.SetActive(false);
        creditscreen.gameObject.SetActive(true);

    }

    public void ContactUs()
    {
        Application.OpenURL("https://www.rhoadsonline.com/contact/");
    }

    public void BackToMenu()
    {
        creditscreen.gameObject.SetActive(false);
        howtoplay3.gameObject.SetActive(false);
        startscreen.gameObject.SetActive(true);
    }

    public void HowToPlay1()
    {
        startscreen.gameObject.SetActive(false);
        howtoplay2.gameObject.SetActive(false);
        howtoplay3.gameObject.SetActive(false);
        howtoplay1.gameObject.SetActive(true);
    }

    public void HowToPlay2()
    {
        howtoplay1.gameObject.SetActive(false);
        howtoplay3.gameObject.SetActive(false);
        howtoplay2.gameObject.SetActive(true);
    }

    public void HowToPlay3()
    {
        howtoplay2.gameObject.SetActive(false);
        howtoplay1.gameObject.SetActive(false);
        howtoplay3.gameObject.SetActive(true);
    }


    public void exitgame()
    {
        Application.Quit();
    }
}
