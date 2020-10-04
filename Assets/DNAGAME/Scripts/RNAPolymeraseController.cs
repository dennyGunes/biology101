using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RNAPolymeraseController : MonoBehaviour
{
    //dna removal
    public int currentEatenABases;
    public int currentEatenTBases;
    public int currentEatenUBases;
    public int currentEatenGBases;
    public int currentEatenCBases;
    public Text ABases;
    public Text TBases;
    public Text UBases;
    public Text GBases;
    public Text CBases;
    public bool controlling;
    public Transform start;

    //Movement
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        controlling = true;
    }
	private void Awake()
	{
        FindObjectOfType<dnaGameManager>().started = true;
	}
	void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        ABases.text = currentEatenABases.ToString();
        TBases.text = currentEatenTBases.ToString();
        GBases.text = currentEatenGBases.ToString();
        CBases.text = currentEatenCBases.ToString();
        UBases.text = currentEatenUBases.ToString();
    }

    private void FixedUpdate()
    {
        if (controlling)
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
		else
		{
            transform.position = Vector3.Lerp(transform.position, start.position, 1f);
		}
        if(body.velocity.x > 0)
		{
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
		}
        if (body.velocity.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "NitrogenBase" && this.tag == "Player" && (!FindObjectOfType<DnaStrand>().isCreatingPreMRNA || !FindObjectOfType<mRNAManager>().isCreatingmRNA))
		{
           
            if (collision.gameObject.name.Contains("Adenine"))
			{
                currentEatenABases++;
                
            }
            if (collision.gameObject.name.Contains("Thymine"))
            {
                currentEatenTBases++;
              
            }
            if (collision.gameObject.name.Contains("Guanine"))
            {
                currentEatenGBases++;
                
            }
            if (collision.gameObject.name.Contains("Cytosin"))
            {
                currentEatenCBases++;
            }

            Destroy(collision.gameObject);
		}
        
        if (collision.tag == "NitrogenBase" && this.tag == "Player" && FindObjectOfType<DnaStrand>().isCreatingPreMRNA)
        {

            if (collision.gameObject.name.Contains("Adenine"))
            {
                currentEatenABases++;
                FindObjectOfType<preMRNAManager>().lastPositionX -= .6f;

            }
            if (collision.gameObject.name.Contains("Uracil"))
            {
                currentEatenUBases++;
                FindObjectOfType<preMRNAManager>().lastPositionX -= .6f;

            }
            if (collision.gameObject.name.Contains("Guanine"))
            {
                currentEatenGBases++;
                FindObjectOfType<preMRNAManager>().lastPositionX -= .6f;

            }
            if (collision.gameObject.name.Contains("Cytosin"))
            {
                currentEatenCBases++;
                FindObjectOfType<preMRNAManager>().lastPositionX -= .6f;
            }

            Destroy(collision.gameObject);
        }
    }

    

}
