using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treatment : MonoBehaviour
{

    public string healType;
    public Collider coll;
    public string woundType;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (coll.Raycast(ray, out hit, 100.0f))
            {
                print(healType);
                GameObject hitObject = hit.collider.gameObject;

                Wound hitWound = hitObject.GetComponent<Wound>();

                woundType = hitWound.getWound();
                print(woundType);

                if (woundType == "Open Wound" && healType == "Bandage")
                {
                    hitObject.SetActive(false);
                } else if (woundType == "Burn Cream" && healType == "Burn")
                {
                    hitObject.SetActive(false);
                } else if (woundType == "Infection" && healType == "Antibiotics")
                {
                    hitObject.SetActive(false);
                }
            }
        }
    }

    public string getTreatment()
    {
        string objName = gameObject.name;
        if (objName.Contains("Bandages"))
        {
            healType = "Bandage";
        } else if (objName.Contains("Burn Cream"))
        {
            healType = "Burn Cream";
        } else if (objName.Contains("Antibiotics"))
        {
            healType = "Antibiotics";
        }
        return healType;
    }
}
