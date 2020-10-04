using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool timeOut = true;
    public GameObject PauseMenu;
    public Slider VolumeSlider;
    public GameObject blackOut;
    public GameObject controls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((!FindObjectOfType<dnaStrandMove>().holding && !FindObjectOfType<dnaStrandBottomMove>().holding) && Input.GetKeyDown(KeyCode.Escape))
		{
            //Debug.Log("ger");
            PauseMenu.SetActive(true);
            blackOut.SetActive(true);
            timeOut = true;
        }
  //      if (timeOut && Input.GetKeyDown(KeyCode.Escape))
		//{
  //          timeOut = false;
  //      }
        if (!timeOut)
        {
            PauseMenu.SetActive(false); 
            blackOut.SetActive(false);
        }
        PlayerPrefs.SetFloat("Volume", VolumeSlider.value);
    }

    public void Unpause()
	{
        timeOut = false;
	}

    public void controlsOn()
	{
        PauseMenu.SetActive(false);
        controls.SetActive(true);
	}
    public void controlsOff()
    {
        controls.SetActive(false);
        PauseMenu.SetActive(true);
    }
    public void ExitToMainMenu()
	{
        SceneManager.LoadScene(0);
	}

}
