using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifications : MonoBehaviour {

    public GameObject Mole1;
    public GameObject Mole2;
    public GameObject Mole3;
    public GameObject destroyer;
    public bool tabbed = false;

	// Use this for initialization
	void Start () {
        transform.Rotate(90f, -90f, 90f);
        Vector3 pos = new Vector3(Random.RandomRange(-4.8f, 4.8f), Random.RandomRange(1.5f, 3.3f), -4.4f);
        transform.position = pos;
        Mole1 = GameObject.Find("Licenses Mole");
        Mole2 = GameObject.Find("PDB Mole");
        Mole3 = GameObject.Find("Appointments Mole");
        destroyer = GameObject.Find("Destroyer");
        assignTab();
    }
	
	// Update is called once per frame
	void Update () {
        clear();
		
	}

    void assignTab()
    {
        if(this.gameObject.tag == "Licenses")
        {
            destroyer.GetComponent<Destroyer>().assignLicTab();
        }
        else if (this.gameObject.tag == "PDB")
        {
            destroyer.GetComponent<Destroyer>().assignPdbTab();
        }
        else if (this.gameObject.tag == "Appointments")
        {
            destroyer.GetComponent<Destroyer>().assignAppTab();
        }
    }

    void clear()
    {
        if (Mole1.GetComponent<Mole>().getPressed() == true)
        {
            if(this.gameObject.tag == Mole1.gameObject.tag)
            {
                checkDestroy();
            }

        }
        if (Mole2.GetComponent<Mole>().getPressed() == true)
        {
            if (this.gameObject.tag == Mole2.gameObject.tag)
            {
                checkDestroy();
            }
        }
        if (Mole3.GetComponent<Mole>().getPressed() == true)
        {
            if (this.gameObject.tag == Mole3.gameObject.tag)
            {
                checkDestroy();
            }

        }
    }

    void checkDestroy()
    {
        if (tabbed == true)
        {
            //this.gameObject.SetActive(false);
            if (this.gameObject.tag == "Licenses")
            {
                destroyer.GetComponent<Destroyer>().destroyLicenseNotif();
                tabbed = false;
            }

            else if (this.gameObject.tag == "PDB")
            {
                destroyer.GetComponent<Destroyer>().destroyPDBNotif();
                tabbed = false;
            }
            else if (this.gameObject.tag == "Appointments")
            {
                destroyer.GetComponent<Destroyer>().destroyApptNotif();
                tabbed = false;
            }
        }
    }

    public void setTabbed(bool tabbed)
    {
        this.tabbed = tabbed;
    }

    public bool getTabbed()
    {
        return tabbed;
    }

}
