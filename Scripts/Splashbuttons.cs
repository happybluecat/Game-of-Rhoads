using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splashbuttons : MonoBehaviour {

	public void Playagain()
    {
        SceneManager.LoadScene(1);
    }

    public void menuscreen()
    {
        SceneManager.LoadScene(0);
    }
}
