using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour {

    public GameObject licensetab;
    public GameObject pdbtab;
    public GameObject appttab;
    public float buffer = 0.5f;
    public Text scoretext;
    public int score;
    public bool isCorrect = false;

	// Use this for initialization
	void Start () {
        this.gameObject.SetActive(true);
        licensetab = null;
        pdbtab = null;
        appttab = null;
        scoretext.text = "Score: 0";
        score = 0;
		
	}
	

    public void assignLicTab()
    {
        if (licensetab == null)
        {
            licensetab = GameObject.Find("Renew Licenses(Clone)");
            if (licensetab != null)
            {
                licensetab.GetComponent<Notifications>().setTabbed(true);
            }
            //Debug.Log("License Tab assigned");
        }
    }
    public void assignPdbTab()
    {
        if (pdbtab == null)
        {
            pdbtab = GameObject.Find("Update PDB(Clone)");
            if (pdbtab != null)
            {
                pdbtab.GetComponent<Notifications>().setTabbed(true);
            }
            //Debug.Log("PDB Tab assigned");
        }
    }
    public void assignAppTab()
    {
        if (appttab == null)
        {
            appttab = GameObject.Find("Make Appointments(Clone)");
            if (appttab != null)
            {
                appttab.GetComponent<Notifications>().setTabbed(true);
            }
            //Debug.Log("Appt Tab assigned");
        }
    }
    

    public void destroyLicenseNotif()
    {
        isCorrect = true;
        licensetab.gameObject.SetActive(false);
        Destroy(licensetab.gameObject);
        licensetab = null;
        addScore();

        Invoke("assignLicTab", buffer);
    }

    public void destroyPDBNotif()
    {
        isCorrect = true;
        pdbtab.gameObject.SetActive(false);
        Destroy(pdbtab.gameObject);
        pdbtab = null;
        addScore();

        Invoke("assignPdbTab", buffer);
    }

    public void destroyApptNotif()
    {
        isCorrect = true;
        appttab.gameObject.SetActive(false);
        Destroy(appttab.gameObject);
        pdbtab = null;
        addScore();

        Invoke("assignAppTab", buffer);
    }

    public void addScore()
    {
        if (isCorrect == true)
        {
            score = score + 5;
            scoretext.color = Color.black;
            scoretext.text = "Score: " + score;
        }

        if (isCorrect == false)
        {
            Handheld.Vibrate();
            score = score - 7;
            scoretext.color = Color.red;
            scoretext.text = "Score: " + score;
        }
    }

    
}
