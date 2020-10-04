using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antiCodon : MonoBehaviour
{
    public GameObject Adenine;
    public GameObject Guanine;
    public GameObject Cytosin;
    public GameObject Uracil;
    public char A;
    public char U;
    public char G;
    public char C;

    public Transform[] spawnBig;
    public Transform[] spawnSmall;
    public List<GameObject> instantiatedBases;
    public GameObject strandGraphics;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateAntiCodon(string incomming)
	{
		for (int i = 0; i < 3; i++)
		{
            if(incomming[i] == A)
			{
                instantiateAntiCodonBases(0, Uracil, i);
                Debug.Log("U " + i);
			}
            if (incomming[i] == U)
            {
                instantiateAntiCodonBases(1, Adenine, i);
                Debug.Log("A " + i);
            }
            if (incomming[i] == G)
            {
                instantiateAntiCodonBases(0, Cytosin, i);
                Debug.Log("C " + i);
            }
            if (incomming[i] == C)
            {
                instantiateAntiCodonBases(1, Guanine, i);
                Debug.Log("G " + i);
            }
        }
	}

	public void instantiateAntiCodonBases(int bigSmall, GameObject prefab, int i)
	{
        if(bigSmall == 0)
		{
            GameObject azotateBase = Instantiate(prefab, spawnBig[i].position, spawnBig[i].rotation);
            azotateBase.transform.parent = this.transform;
            instantiatedBases.Add(azotateBase);
            
        }
        if (bigSmall == 1)
        {
            GameObject azotateBase = Instantiate(prefab, spawnSmall[i].position, spawnSmall[i].rotation);
            azotateBase.transform.parent = this.transform;
            instantiatedBases.Add(azotateBase);
            
        }
        if (i == 2)
            StartCoroutine(deleteBases());

    }

    IEnumerator deleteBases()
	{
        strandGraphics.SetActive(true);
        FindObjectOfType<ribossomeController>().canMove = false;
        transform.position = FindObjectOfType<ribossomeController>().spawnPoint.position;
        yield return new WaitForSeconds(2);
        FindObjectOfType<ribossomeController>().canMove = true;
        strandGraphics.SetActive(false);
        StopCoroutine(deleteBases());
	}
}
