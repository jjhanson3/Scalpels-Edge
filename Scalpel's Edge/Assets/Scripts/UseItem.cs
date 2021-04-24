using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public Collider coll;
    public string woundType;
    public string healType;
    private itemPickUpScript pickUpScript;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
        pickUpScript = gameObject.GetComponent<itemPickUpScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get cast to item position to get treatment object and healType
        //Then, one mouseclick, use cast to get wound object and woundType
        //Compare types, disappear if they match
        
        if (Input.GetMouseButtonDown(0) && Camera.main.GetComponent<cameraMovement>().enabled)
        {
            print(pickUpScript.itemID);
            healType = pickUpScript.itemID;
            //print(healType);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 20, Color.white, 5f);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;
                print(hitObject);
                Wound hitWound = hitObject.GetComponent<Wound>();

                if (hitWound != null)
                {
                    woundType = hitWound.getWound();
                    print(woundType);
                } else
                {
                    print("WoundType is Null");
                    woundType="";
                }


                if (woundType == "Open Wound" && healType == "Bandage")
                {
                    print("check 1");
                    hitObject.SetActive(false);
                }
                else if (woundType == "Burn Cream" && healType == "Burn")
                {
                    hitObject.SetActive(false);
                }
                else if (woundType == "Infection" && healType == "Antibiotics")
                {
                    hitObject.SetActive(false);
                }
            }
        }
    }
}
