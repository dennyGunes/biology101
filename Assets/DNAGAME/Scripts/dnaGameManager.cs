using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dnaGameManager : MonoBehaviour
{
    public float bestTime;
    public float currentTime;
    public bool started;
    public bool ended;

    //UI
    public Text pb;
    public Text current;

    public GameObject ScoreScreen;
    public Text scoreText;
        // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
		if (PlayerPrefs.HasKey("DnaPB"))
		{
            bestTime = PlayerPrefs.GetFloat("DnaPB");
		}
		else
		{
            bestTime = 0;

        }
        string minutes = Mathf.Floor(bestTime / 60).ToString("00");
        string seconds = (bestTime % 60).ToString("00");
        pb.text = "PB: " +minutes + ":" + seconds;
    }

    // Update is called once per frame
    void Update()
    {
        string minutes = Mathf.Floor(currentTime / 60).ToString("00");
        string seconds = (currentTime % 60).ToString("00");
        if (started &&!FindObjectOfType<GameManager>().timeOut)
		{
            currentTime += Time.deltaTime;
		}
		if (ended)
		{
            started = false;
            ScoreScreen.SetActive(true);
            if (currentTime < PlayerPrefs.GetFloat("DnaPB") && PlayerPrefs.HasKey("DnaPB"))
			{
                PlayerPrefs.SetFloat("DnaPB", currentTime);
                scoreText.text = ("Congratulations you finished your task in " + minutes + ":" + seconds + ", a new Personal Best");
            }
            else if (currentTime > PlayerPrefs.GetFloat("DnaPB") && !PlayerPrefs.HasKey("DnaPB"))
			{
                PlayerPrefs.SetFloat("DnaPB", currentTime);
                scoreText.text = ("Congratulations you finished your task in " + minutes + ":" + seconds + ", a new Personal Best");
            }
			else if(currentTime > PlayerPrefs.GetFloat("DnaPB") && PlayerPrefs.HasKey("DnaPB"))
			{
                scoreText.text = ("Congratulations you finished your task in " + minutes + ":" + seconds + ", just shy of your Personal Best");
            }
            ended = false;
		}
        current.text = "Current time: " + minutes + ":" + seconds;
    }
}
