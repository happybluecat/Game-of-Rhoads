using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewNotif : MonoBehaviour {

    public float seconds = 2.0f;
    public float minsecs = 0.5f;
    public GameObject[] notifs;
    public Text timetext;
    public float countdown = 30.0f;
    public int highscore;
    public Text highscoree;
    public Text yourscoree;
    public GameObject destroyer;
    public bool hasEnded = false;
    public GameObject splashImage;
    public GameObject PCRM;

	// Use this for initialization
	void Start () {
        popup();

        highscore = PlayerPrefs.GetInt("highscore", highscore);

        highscoree.gameObject.SetActive(false);
        yourscoree.gameObject.SetActive(false);
        splashImage.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (countdown > 0.0f)
        {
            countdown = countdown - Time.deltaTime;
        }
        timetext.text = "" + Mathf.Round(countdown);
        if (countdown <= 0.0f)
        {
            timerEnded();
            countdown = 0.0f;

        }

    }

    void popup()
    {
        int randnum = Random.Range(0, notifs.Length);
        GameObject notification = notifs[randnum];
        Instantiate(notification, transform.position, Quaternion.identity);
        if (seconds > minsecs)
        {
            seconds = seconds - 0.07f;
        }
        else
        {
            seconds = minsecs;
        }
        if (hasEnded == false)
        {
            Invoke("popup", seconds);
        }
    }

    void timerEnded()
    {
        hasEnded = true;
        int score = destroyer.gameObject.GetComponent<Destroyer>().score;
        if (score > highscore)
        {
            highscore = score;
        }
        highscoree.text = "" + highscore;
        yourscoree.text = "" + score;
        splashImage.gameObject.SetActive(true);
        yourscoree.gameObject.SetActive(true);
        highscoree.gameObject.SetActive(true);

        PlayerPrefs.SetInt("highscore", highscore);
    }
}
