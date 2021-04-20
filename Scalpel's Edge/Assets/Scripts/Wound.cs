using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wound : MonoBehaviour
{

    public string woundType;

    //number to subract severity from to calculate intervals
    public int tempInverse;

    //severity is currently assigned through inspector for testing purposes
    public int severity;
    //interval count for each stage will be found by "tempInverse - severity"
    //but is subject to change
    private int intervals;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        //itemPickUpScript playerScript = player.GetComponent<itemPickUpScript>();
        intervals = tempInverse - severity;
        player.GetComponent<GlobalTimerScript>().AddWound(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //on disable called when object is set to inactive
    private void OnDisable()
    {
        GameObject player = GameObject.Find("Player");
        player.GetComponent<GlobalTimerScript>().RemoveWound(gameObject);

    }

    public string getWound()
    {
        string objName = gameObject.name;
        if (objName.Contains("Open Wound"))
        {
            woundType = "Open Wound";
        }
        else if (objName.Contains("Burn"))
        {
            woundType = "Burn";
        }
        else if (objName.Contains("Infection"))
        {
            woundType = "Infection";
        }

        return woundType;
    }

    public void IntervalUpdate()
    {
        intervals--;
        if (intervals == 0)
        {
            severity++;
            //call function to update nearby clipboard info
            intervals = tempInverse - severity;
        }
        Debug.Log("Wound Severity: " + severity);
    }
}

