using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedScript : MonoBehaviour
{
    public bool isEmpty = true;
    public GameObject clipboard;
    public GameObject wound;


    public GameObject woundToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        //Do nothing?
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeNewWound()
    {
        //Debug.Log("Before Instantiation");
        //First get spawn coordinates
        Vector3 position = gameObject.transform.GetChild(0).position + Vector3.up;
        wound = Instantiate(woundToSpawn, position, Quaternion.identity, gameObject.transform.GetChild(0));
        //Rescale the wound here!
        isEmpty = false;
       // Debug.Log("After Instantiation");
    }
}
