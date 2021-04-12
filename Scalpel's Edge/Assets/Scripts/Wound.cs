using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wound : MonoBehaviour
{

    public string woundType;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject player = GameObject.Find("Player");
        //itemPickUpScript playerScript = player.GetComponent<itemPickUpScript>();
    }

    // Update is called once per frame
    void Update()
    {

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

    public void treat()
    {
        gameObject.SetActive(false);
    }
}

