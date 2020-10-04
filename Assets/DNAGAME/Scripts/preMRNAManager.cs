using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preMRNAManager : MonoBehaviour
{
    public GameObject Adenine;
    public GameObject Uracil;
    public GameObject Guanine;
    public GameObject Cytosin;

    public GameObject baseStrand;

    public Vector3 posToSpawn;
    public float lastPositionX = 0.206f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//if(Input.GetKeyDown(KeyCode.Alpha1))
		//{
  //          //generate a
  //          FindObjectOfType<RNAPolymeraseController>().currentEatenABases--;
  //          posToSpawn = new Vector3(baseStrand.transform.position.x + lastPositionX, baseStrand.transform.position.y - 1.1088f, baseStrand.transform.position.z);
  //          InstanciateRNABase(Adenine);
  //          FindObjectOfType<RNAPolymeraseController>().transform.position = new Vector3(FindObjectOfType<RNAPolymeraseController>().transform.position.x + 0.6f, FindObjectOfType<RNAPolymeraseController>().transform.position.y, FindObjectOfType<RNAPolymeraseController>().transform.position.z);
		//}
  //      if (Input.GetKeyDown(KeyCode.Alpha2))
  //      {
  //          //generate u
  //          FindObjectOfType<RNAPolymeraseController>().currentEatenTBases--;
  //          posToSpawn = new Vector3(baseStrand.transform.position.x + lastPositionX, baseStrand.transform.position.y - .998f, baseStrand.transform.position.z);
  //          InstanciateRNABase(Uracil);
  //          FindObjectOfType<RNAPolymeraseController>().transform.position = new Vector3(FindObjectOfType<RNAPolymeraseController>().transform.position.x + 0.6f, FindObjectOfType<RNAPolymeraseController>().transform.position.y, FindObjectOfType<RNAPolymeraseController>().transform.position.z);
  //      }
  //      if (Input.GetKeyDown(KeyCode.Alpha3))
  //      {
  //          //generate g
  //          FindObjectOfType<RNAPolymeraseController>().currentEatenGBases--;
  //          posToSpawn = new Vector3(baseStrand.transform.position.x + lastPositionX, baseStrand.transform.position.y - 1.1088f, baseStrand.transform.position.z);
  //          InstanciateRNABase(Guanine);
  //          FindObjectOfType<RNAPolymeraseController>().transform.position = new Vector3(FindObjectOfType<RNAPolymeraseController>().transform.position.x + 0.6f, FindObjectOfType<RNAPolymeraseController>().transform.position.y, FindObjectOfType<RNAPolymeraseController>().transform.position.z);
  //      }
  //      if (Input.GetKeyDown(KeyCode.Alpha4))
  //      {
  //          //generate c
  //          FindObjectOfType<RNAPolymeraseController>().currentEatenCBases--;
  //          posToSpawn = new Vector3(baseStrand.transform.position.x + lastPositionX, baseStrand.transform.position.y - .998f, baseStrand.transform.position.z);
  //          InstanciateRNABase(Cytosin);
  //          FindObjectOfType<RNAPolymeraseController>().transform.position = new Vector3(FindObjectOfType<RNAPolymeraseController>().transform.position.x + 0.6f, FindObjectOfType<RNAPolymeraseController>().transform.position.y, FindObjectOfType<RNAPolymeraseController>().transform.position.z);
  //      }
    }
	

    public void InstanciateRNABase(GameObject prefab)
	{
        
            GameObject baseCreated = Instantiate(prefab, posToSpawn, transform.rotation);
            baseCreated.transform.parent = baseStrand.transform;
            lastPositionX += .6f;
        
    }
    public void OnClickButtonChooseBase(int type)
	{
        if (type == 0)
        {
            //generate a
            FindObjectOfType<RNAPolymeraseController>().currentEatenABases--;
            posToSpawn = new Vector3(baseStrand.transform.position.x + lastPositionX, baseStrand.transform.position.y - 1.1088f, baseStrand.transform.position.z);
            InstanciateRNABase(Adenine);
            FindObjectOfType<RNAPolymeraseController>().transform.position = new Vector3(FindObjectOfType<RNAPolymeraseController>().transform.position.x + 0.6f, FindObjectOfType<RNAPolymeraseController>().transform.position.y, FindObjectOfType<RNAPolymeraseController>().transform.position.z);
        }
        if (type == 1)
        {
            //generate u
            FindObjectOfType<RNAPolymeraseController>().currentEatenTBases--;
            posToSpawn = new Vector3(baseStrand.transform.position.x + lastPositionX, baseStrand.transform.position.y - .998f, baseStrand.transform.position.z);
            InstanciateRNABase(Uracil);
            FindObjectOfType<RNAPolymeraseController>().transform.position = new Vector3(FindObjectOfType<RNAPolymeraseController>().transform.position.x + 0.6f, FindObjectOfType<RNAPolymeraseController>().transform.position.y, FindObjectOfType<RNAPolymeraseController>().transform.position.z);
        }
        if (type == 2)
        {
            //generate g
            FindObjectOfType<RNAPolymeraseController>().currentEatenGBases--;
            posToSpawn = new Vector3(baseStrand.transform.position.x + lastPositionX, baseStrand.transform.position.y - 1.1088f, baseStrand.transform.position.z);
            InstanciateRNABase(Guanine);
            FindObjectOfType<RNAPolymeraseController>().transform.position = new Vector3(FindObjectOfType<RNAPolymeraseController>().transform.position.x + 0.6f, FindObjectOfType<RNAPolymeraseController>().transform.position.y, FindObjectOfType<RNAPolymeraseController>().transform.position.z);
        }
        if (type == 3)  
        {
            //generate c
            FindObjectOfType<RNAPolymeraseController>().currentEatenCBases--;
            posToSpawn = new Vector3(baseStrand.transform.position.x + lastPositionX, baseStrand.transform.position.y - .998f, baseStrand.transform.position.z);
            InstanciateRNABase(Cytosin);
            FindObjectOfType<RNAPolymeraseController>().transform.position = new Vector3(FindObjectOfType<RNAPolymeraseController>().transform.position.x + 0.6f, FindObjectOfType<RNAPolymeraseController>().transform.position.y, FindObjectOfType<RNAPolymeraseController>().transform.position.z);
        }
    }

    public void OnClickButtonFinishPreMRNA()
	{
        FindObjectOfType<DnaStrand>().isCreatingPreMRNA = false;
        FindObjectOfType<mRNAManager>().isCreatingmRNA = !FindObjectOfType<mRNAManager>().isCreatingmRNA;


    }
	
}
