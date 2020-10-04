using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DnaStrand : MonoBehaviour
{
    public string DNA;
    public string DNABottom;
    public GameObject Adenine;
    public GameObject Thymine;
    public GameObject Guanine;
    public GameObject Cytosin;
    public GameObject AdenineBottom;
    public GameObject ThymineBottom;
    public GameObject GuanineBottom;
    public GameObject CytosinBottom;
    public GameObject DNAStrand;
    public int dnaSize;
    public int currentSpawnPosition;
    public char[] Bases;

    Vector3 positionToSpawnTop;
    Vector3 positionToSpawnBottom;
    public SpriteRenderer top;
    public SpriteRenderer bottom;
    float lastPositionX = 0.206f;
    public GameObject bottomStrandMaster;
    public GameObject topStrandMaster;
    public RectTransform buttonTop;
    public RectTransform buttonBottom;
    public RectTransform topCanvas;
    public RectTransform bottomCanvas;
    BoxCollider2D myBoxCollider;
    public GameObject dnaFinnishLinhaTop;
    public GameObject dnaFinnishLinhaBottom;
    public bool isInContact;
    public Button startPREMRNA;
    public Vector3 offset;
    public bool isCreatingPreMRNA = false;
    public Text objectiveText;
    string preMRNA;
    public char A;
    public char T;
    public char G;
    public char C;
    public char U;
    string exon;
    public bool begun = false;
    public bool ended = false;
    public bool hasAddedEnd = false;
    public int maxSize;
    public int size;
    string lastMRNA;
    string endStrand;
    // Start is called before the first frame update
    void Start()
    {
        
        DNA = "TAC";
        int dnaRND = Random.Range(15, 60);
        dnaSize = (int)(Mathf.Round(dnaRND / 3) * 3);
        int[] rnd = new int[dnaSize];
        int rndTwo = Random.Range(0, 3);
        for (int i = 0; i < dnaSize-3; i++)
		{
            rnd[i] = Random.Range(0, 4);
            if(rnd[i] == 0)
			{
                DNA += "A";
                //Debug.Log(DNA);
			}
            if (rnd[i] == 1)
            {
                DNA += "T";
               // Debug.Log(DNA);
            }
            if (rnd[i] == 2)
            {
                DNA += "G";
                //Debug.Log(DNA);
            }
            if (rnd[i] == 3)
            {
                DNA += "C";
                //Debug.Log(DNA);
            }
            

        }
        if(rndTwo == 0)
		{
            DNA += "ATT";
            dnaSize += 3;
		}
        if (rndTwo == 1)
        {
            DNA += "ATC";
            dnaSize += 3;
        }
        if (rndTwo == 2)
        {
            DNA += "ACT";
            dnaSize += 3;
        }
        GenerateDnaString();
        endStrand = DNA.Substring(dnaSize - 3, 3);
        //Debug.Log(endStrand + " END");
        for (int i = 0; i < dnaSize; i++)
        {

            if (DNABottom[i] != T)
            {
                preMRNA += DNABottom[i];
            }
            else if (DNABottom[i] == T)
            {
                preMRNA += U;
            }
        }
        myBoxCollider = GetComponent<BoxCollider2D>();
        float sizeX = (2.2f / 37f) * dnaSize;
        top.size = new Vector2(sizeX, 0.4375f);
        myBoxCollider.size = new Vector2(top.size.x, 0.4375f);
        myBoxCollider.offset = new Vector2(top.size.x / 2, 0f);
        bottom.size = new Vector2(sizeX, 0.4375f);
        dnaFinnishLinhaTop.transform.position = new Vector3((top.size.x * 10) + 0.65f, 0, 0);
        dnaFinnishLinhaBottom.transform.position = new Vector3((top.size.x * 10) + 0.65f, -1.625f, 0);
       
		for (int i = 0; i < dnaSize-3; i+=3)
		{
            //Debug.Log("here");
            exon = preMRNA.Substring(i, 3);
            int rndThree = Random.Range(0, 2);
            if (exon == "AUG" && !begun && !ended)
            {
                addAAObjective("AUG");
                begun = true;
            }
            if (rndThree == 1 && begun && !ended)
			{
                if ((exon == "AUG" || exon == "UAA" || exon == "UAG" || exon == "UGA") && begun)
                {
                    exon = "";
                }
                else
                    addAAObjective(exon);
			}
            
            
		}
        
    }

    // Update is called once per frame
    void Update()
    {
		if (!isInContact)
		{
            startPREMRNA.interactable = true;
		}
        if (isInContact)
        {
            startPREMRNA.interactable = false;
        }
    }
	private void FixedUpdate()
	{
		if(lastMRNA == preMRNA)
		{
            ended = true;
            if (!hasAddedEnd)
            {
                if (!hasAddedEnd)
                {
                    if (endStrand == "ATT")
                    {
                       // Debug.Log("tes1");
                        addAAObjective("UAA");
                    }
                    if (endStrand == "ATC")
                    {
                        //Debug.Log("tes2");
                        addAAObjective("UAG");
                    }
                    if (endStrand == "ACT")
                    {
                       // Debug.Log("tes3");
                        addAAObjective("UGA");
                    }
                    hasAddedEnd = true;
                }
            }
        }
        lastMRNA = preMRNA;
	}
	public void GenerateDnaString()
	{
		for (int i = 0; i < dnaSize; i++)
		{
            if(DNA[i] == Bases[0])
			{
                //instanciate A
                DNABottom += Bases[1];
                positionToSpawnTop = new Vector3(lastPositionX, -.515f, 0f);
                positionToSpawnBottom = new Vector3(lastPositionX, -.998f, 0f);
                InstantiateDNABase(Adenine,0);
                InstantiateDNABase(ThymineBottom,1);
            }
            if (DNA[i] == Bases[1])
            {
                //instanciate T
                DNABottom += Bases[0];
                positionToSpawnTop = new Vector3(lastPositionX, -.625f, 0f);
                positionToSpawnBottom = new Vector3(lastPositionX, -1.1088f, 0f);
                InstantiateDNABase(Thymine,0);
                InstantiateDNABase(AdenineBottom, 1);
            }
            if (DNA[i] == Bases[2])
            {
                //instanciate G
                DNABottom += Bases[3];
                positionToSpawnTop = new Vector3(lastPositionX, -.515f, 0f);
                positionToSpawnBottom = new Vector3(lastPositionX, -.998f, 0f);
                InstantiateDNABase(Guanine,0);
                InstantiateDNABase(CytosinBottom,1);
            }
            if (DNA[i] == Bases[3])
            {
                //instanciate C
                DNABottom += Bases[2];
                positionToSpawnTop = new Vector3(lastPositionX, -.625f, 0f);
                positionToSpawnBottom = new Vector3(lastPositionX, -1.1088f, 0f);
                InstantiateDNABase(Cytosin,0);
                InstantiateDNABase(GuanineBottom,1);
            }
        }
	}

    public void InstantiateDNABase(GameObject prefab,int topBottom)
	{
        if(topBottom == 0)
		{
            GameObject baseCreated = Instantiate(prefab, positionToSpawnTop, transform.rotation);
            baseCreated.transform.parent = topStrandMaster.transform;
            lastPositionX += .3f;
        }
        if(topBottom == 1)
		{
            GameObject baseCreated = Instantiate(prefab, positionToSpawnBottom, transform.rotation);
            baseCreated.transform.parent = bottomStrandMaster.transform;
            lastPositionX += .3f;
        }
        
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "BottomStrand" || collision.tag == "TopStrand")
		{
            isInContact = true;
		}
	}
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "BottomStrand" || collision.tag == "TopStrand")
        {
            isInContact = false;
        }
    }

    public void OnButtonClickStartPreMRNAGenerate()
	{
        isCreatingPreMRNA = true;
        offset = new Vector3(offset.x, (topStrandMaster.transform.position.y - bottomStrandMaster.transform.position.y) / 2, offset.z);
        FindObjectOfType<RNAPolymeraseController>().transform.position = new Vector3((bottomStrandMaster.transform.position.x -((bottom.size.x)/2)) , bottomStrandMaster.transform.position.y-.5f, bottomStrandMaster.transform.position.z) + offset;
    }
    public void addAAObjective(string codon)
	{
        objectiveText.text += (codon + " ");
        exon = "";
        size+= 2;
        if(size >=maxSize)
		{
            ended = true;
		}
    }

    public void addEnd(string end)
	{
        addAAObjective(end);
    }
}
