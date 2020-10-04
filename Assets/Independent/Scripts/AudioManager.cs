﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    public Slider volSlider;
    // Start is called before the first frame update
    void Start()
    {
		if (PlayerPrefs.HasKey("Volume"))
		{
            volSlider.value = PlayerPrefs.GetFloat("Volume");
		}
		else
		{
            volSlider.value = 1;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
