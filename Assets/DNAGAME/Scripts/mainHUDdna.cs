using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainHUDdna : MonoBehaviour
{
    public GameObject blackOut;
    public GameObject AATable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButtonAATable()
	{
        blackOut.SetActive(!blackOut.activeSelf);
        AATable.SetActive(!AATable.activeSelf);
    }
}
