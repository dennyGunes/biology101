using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dnaStrandBottomMove : MonoBehaviour
{
    public GameObject bottomStrand;
    public Vector3 differenceBetween;
    public Camera cam;
    public bool holding;
    public float strandMove;
    public bool isInsideBottom;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (holding)
        {
               Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
               bottomStrand.transform.position = new Vector3(mousePos.x, mousePos.y, 0f) + differenceBetween;

            if (Input.GetAxis("Fire2") != 0)
            {
                holding = false;
            }
        }
        if (isInsideBottom && Input.GetAxis("Fire1") != 0 && !holding)
        {
            OnClickButtonStrandBase(1);
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
		
	    differenceBetween = new Vector3((bottomStrand.transform.position.x - mousePos.x), (bottomStrand.transform.position.y - mousePos.y), 0f);
        Debug.Log(differenceBetween);
        topBottom = 1;
		
	}
}
