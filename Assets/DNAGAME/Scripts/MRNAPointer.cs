using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRNAPointer : MonoBehaviour
{
    public dnaStrandMove topStrand;
    public dnaStrandBottomMove bottomStrand;
    public bool isInsideTop;
    public bool isInsideBottom;
    public bool deleteIntron = false;
    public GameObject cross;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetAxis("Fire1") > 0)
		{
            if(isInsideTop)
			{
                topStrand.OnClickButtonStrandBase(0);
            }
            if (isInsideBottom)
            {
                bottomStrand.OnClickButtonStrandBase(1);
            }
        }
		if (FindObjectOfType<mRNAManager>().isCreatingmRNA)
		{
            cross.SetActive(true);
		}
		if (!FindObjectOfType<mRNAManager>().isCreatingmRNA)
		{
            cross.SetActive(false);
		}

    }

	private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.tag == "TopStrand")
        {
            topStrand.isInsideTop = false;
         
        }
        if (collision.tag == "BottomStrand")
        {
            bottomStrand.isInsideBottom = false;
            
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.tag == "TopStrand")
        {
            topStrand.isInsideTop = true;
            
        }
        if (collision.tag == "BottomStrand")
        {
            bottomStrand.isInsideBottom = true;
           
        }
        if (collision.tag == "NitrogenBase" && FindObjectOfType<mRNAManager>().isCreatingmRNA)
        {
            deleteIntron = true;
            Destroy(collision.gameObject);
        }
    }
}
