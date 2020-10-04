using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dnaStrandMove : MonoBehaviour
{
    public GameObject topStrand;
    public Vector3 differenceBetween;
    public Camera cam;
    public bool holding;
    public float strandMove;
    public bool isInsideTop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (holding && !FindObjectOfType<GameManager>().timeOut)
        {
            
            
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                topStrand.transform.position = new Vector3(mousePos.x, mousePos.y, 0f) + differenceBetween;
            
           
            //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //    bottomStrand.transform.position = new Vector3(mousePos.x, mousePos.y, 0f) + differenceBetween;
            
            if (Input.GetAxis("Fire2") != 0)
            {
                holding = false;
            }
        }
        if (isInsideTop && Input.GetAxis("Fire1") != 0 && !holding)
        {
            OnClickButtonStrandBase(0);
        }
    }
    void FixedUpdate()
    {
        strandMove = Input.GetAxis("Fire1");
    }

    public void OnClickButtonStrandBase(int topBottom)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!FindObjectOfType<GameManager>().timeOut)
            holding = true;
       
        
            differenceBetween = new Vector3((topStrand.transform.position.x - mousePos.x), (topStrand.transform.position.y - mousePos.y), 0f);
            //Debug.Log(differenceBetween);
            topBottom = 0;
        
        //if (topBottom == 1)
        //{
        //    differenceBetween = new Vector3((bottomStrand.transform.position.x - mousePos.x), (bottomStrand.transform.position.y - mousePos.y), 0f);
        //    topBottom = 1;
        //}
    }
}
