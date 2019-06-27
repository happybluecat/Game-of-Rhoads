using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public float speed = 1.0f;
    public bool pressed = false;
    public AudioSource sound;
    public GameObject destroyer;
    public GameObject newNotif;

    void Update()
    {

        if(pressed == true)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
            if (this.gameObject.transform.position.y < -2.3)
            {
                pressed = false;
            }
        }

        else if (pressed == false)
        {
            if (this.gameObject.transform.position.y <= -1.34)
            {
                transform.Translate(Vector3.up * Time.deltaTime * speed);
            }
            if (this.gameObject.transform.position.y > -1.33)
            {
                Vector3 resetPos = new Vector3(transform.position.x, -1.34f, transform.position.z);
                transform.position = resetPos;
            }
            
        }

    }

    void OnMouseDown()
    {
        if (newNotif.gameObject.GetComponent<NewNotif>().hasEnded == false)
        {
            pressed = true;
            sound.Play();

            if (this.gameObject.tag == "Licenses" && destroyer.GetComponent<Destroyer>().licensetab == null)
            {
                destroyer.GetComponent<Destroyer>().isCorrect = false;
                destroyer.GetComponent<Destroyer>().addScore();
            }

            else if (this.gameObject.tag == "PDB" && destroyer.GetComponent<Destroyer>().pdbtab == null)
            {
                destroyer.GetComponent<Destroyer>().isCorrect = false;
                destroyer.GetComponent<Destroyer>().addScore();
            }

            else if (this.gameObject.tag == "Appointments" && destroyer.GetComponent<Destroyer>().appttab == null)
            {
                destroyer.GetComponent<Destroyer>().isCorrect = false;
                destroyer.GetComponent<Destroyer>().addScore();
            }
        }

    }

    public bool getPressed()
    {
        return pressed;
    }

    public void setPressed(bool pressed)
    {
        this.pressed = pressed;
    }
}
