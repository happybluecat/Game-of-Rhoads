using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour {

    public Button pcrm;
    public GameObject destroyer;
    public int scorecharge;
    public int clickcount = 0;
    public GameObject newNotif;
    public bool paused = false;
    public GameObject pausetext;
    public GameObject[] mole;


    // Use this for initialization
    void Start () {
        destroyer = GameObject.Find("Destroyer");
        pcrm.onClick.AddListener(TaskOnClick);
        pcrm.gameObject.SetActive(false);
        pausetext.gameObject.SetActive(false);
        paused = false;
        Time.timeScale = 1f;
    }
	
	// Update is called once per frame
	void Update () {
        scorecharge = destroyer.gameObject.GetComponent<Destroyer>().score;
        if (scorecharge >= 100 && clickcount == 0)
        {
            pcrm.gameObject.SetActive(true);
        }
        else if (scorecharge > ((clickcount+1)*100) && clickcount >= 1)
        {
            pcrm.gameObject.SetActive(true);
        }

        if (newNotif.GetComponent<NewNotif>().hasEnded == true)
        {
            pcrm.gameObject.SetActive(false);
            Destroy(this);
        }
    }

    void TaskOnClick()
    {
        //Debug.Log("You have clicked the button!");
        clickcount = clickcount + 1;
        pcrm.gameObject.SetActive(false);
        GameObject[] notifications = new GameObject[8 + clickcount];

        //Destroy(GameObject.Find(Make Appointments(Clone));

        for (int i = 0; i < notifications.Length; i++)
        {
            if (destroyer.gameObject.GetComponent<Destroyer>().pdbtab!= null)
            {
                destroyer.gameObject.GetComponent<Destroyer>().destroyPDBNotif();
            }
            else if (destroyer.gameObject.GetComponent<Destroyer>().licensetab != null)
            {
                destroyer.gameObject.GetComponent<Destroyer>().destroyLicenseNotif();
            }
            else if (destroyer.gameObject.GetComponent<Destroyer>().appttab != null)
            {
                destroyer.gameObject.GetComponent<Destroyer>().destroyApptNotif();
            }

            notifications[i] = GameObject.Find("Update PDB(Clone)");
            if (notifications[i] == null)
            {
                notifications[i] = GameObject.Find("Renew Licenses(Clone)");
            }
            if (notifications[i] == null)
            {
                notifications[i] = GameObject.Find("Make Appointments(Clone)");
            }
            Destroy(notifications[i].gameObject);
        }

    }

    public void pausegame()
    {
        paused = togglePause();
    }

    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            pausetext.gameObject.SetActive(false);
            enableMole();
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            pausetext.gameObject.SetActive(true);
            disableMole();
            return (true);
        }
    }


    void disableMole()
    {
        for (int i = 0; i < mole.Length; i++)
        {
            mole[i].GetComponent<Mole>().enabled = false;
            mole[i].GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    void enableMole()
    {
        for (int i = 0; i < mole.Length; i++)
        {
            mole[i].GetComponent<Mole>().enabled = true;
            mole[i].GetComponent<CapsuleCollider>().enabled = true;
        }
    }
}
