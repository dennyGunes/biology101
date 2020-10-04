using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ribossomeController : MonoBehaviour
{
    public bool insideRibossome;
	public bool buttonPressed = false;
	public bool hasAddedVelocity = false;
	public float speedToAdd = 1f;
	public Rigidbody2D body;
	public Rigidbody2D body2;

    public string eatenEXON;
    public bool tipEntered;
    public bool hasDestroyed;

    public bool controlling;
    public Transform start;
    public Transform mRnaPos;
    public bool finnished;
    public Transform spawnPoint;
    //Movement
    Rigidbody2D myBody;

    float horizontal;
    float vertical;

    public float runSpeed = 15.0f;

    //AA
    public string[] AAString;
    public GameObject[] AAprefabs;
    public Transform spawn;
    public bool wait;
    public string waitingExon;
    public bool canMove = true;
    public bool lastCanMove = true;
    int index;
    int lastEatenExonInt;
    int EatenExonInt;
    // Start is called before the first frame update
    void Start()
    {
        tipEntered = false;
        controlling = false;
        transform.position = start.position;
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		if (buttonPressed)
		{
            
            controlling = true;
            FindObjectOfType<RNAPolymeraseController>().controlling = false;
            FindObjectOfType<CameraFollow>().target = this.gameObject.transform;
            body.transform.position = mRnaPos.position;
		}
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        
    }

	void FixedUpdate()
	{
		//      if (controlling && canMove)
		//{
		//          myBody.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
		//      }  
		//      else if (controlling && !canMove)
		//{
		//          myBody.velocity = new Vector2(0, 0);
		//}
		//      else if(!controlling && canMove)
		//      {
		//          transform.position = Vector3.Lerp(transform.position, start.position, runSpeed);
		//      }
		if (finnished)
		{
            myBody.velocity = new Vector2(0, 0);
            StopCoroutine(startProcessing());
		}
        if (myBody.velocity.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        if (myBody.velocity.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
		if (wait && eatenEXON == "")
		{
            eatenEXON = waitingExon;
            wait = false;
		}
		if (lastCanMove !=canMove)
		{
            if (!canMove)
                myBody.velocity = new Vector2(0, 0);
			else
                myBody.velocity = new Vector2(1f, 0);

        }
        if(lastEatenExonInt != EatenExonInt)
		{
            InstantiateAA(AAprefabs[index]);
        }
        lastCanMove = canMove;
        lastEatenExonInt = EatenExonInt;
    }
	
    

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "BottomStrand")
		{
            insideRibossome = true;
		}
        if (collision.tag == "NitrogenBase" && buttonPressed && !collision.GetComponent<baseController>().hasBeenEaten && canMove)
        {
            if (collision.gameObject.name.Contains("Adenine"))
            {
                if(wait)
				{
                    waitingExon += "A";
				}
				else
				{
                    eatenEXON += "A";
                }
                collision.GetComponent<baseController>().hasBeenEaten = true;

            }
            if (collision.gameObject.name.Contains("Uracil"))
            {
                if (wait)
                {
                    waitingExon += "U";
                }
                else
                {
                    eatenEXON += "U";
                }
                collision.GetComponent<baseController>().hasBeenEaten = true;

            }
            if (collision.gameObject.name.Contains("Guanine"))
            {
                if (wait)
                {
                    waitingExon += "G";
                }
                else
                {
                    eatenEXON += "G";
                }

                collision.GetComponent<baseController>().hasBeenEaten = true;
            }
            if (collision.gameObject.name.Contains("Cytosin"))
            {
                if (wait)
                {
                    waitingExon += "C";
                }
                else
                {
                    eatenEXON += "C";
                }
                collision.GetComponent<baseController>().hasBeenEaten = true;
            }
            if (eatenEXON.Length == 3)
            {
                EatenExonInt++;
                wait = true;
                for (int i = 0; i < AAprefabs.Length; i++)
                {
                    Debug.Log(eatenEXON + "1");
                    if (AAString[i] == eatenEXON)
                    {
                        //Debug.Log(eatenEXON + "2");
                        //Debug.Log(AAString[i]);
                        index = i;
                        FindObjectOfType<antiCodon>().generateAntiCodon(eatenEXON);
                        
                        eatenEXON = "";
                    }


                }

            }
        }

    }
	private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.tag == "BottomStrand")
        {
            insideRibossome = false;
			hasAddedVelocity = false;
			body.velocity = new Vector3(0, 0, 0);
			body2.velocity = new Vector3(0, 0, 0);
		}
    }

    public void OnClickmRNAProcessing()
	{
        buttonPressed = !buttonPressed;
        StartCoroutine(startProcessing());
	}
    IEnumerator startProcessing()
	{
        yield return new WaitForSeconds(.1f);
        transform.position = new Vector3(FindObjectOfType<dnaStrandBottomMove>().transform.position.x - 3.63f, FindObjectOfType<dnaStrandBottomMove>().transform.position.y + 1.38f, transform.position.z);
        yield return new WaitForSeconds(1f);
        myBody.velocity = new Vector2(1f, 0);
        canMove = true;
	}

    public void DestroyBody()
	{
        Destroy(body.gameObject);
	}

    public void InstantiateAA(GameObject prefab)
	{
        Instantiate(prefab, spawn.position, spawn.rotation);
        if(prefab.name == "Stop")
		{
            FindObjectOfType<dnaGameManager>().ended = true;
            finnished = true;
		}
        eatenEXON = "";
    }
}
