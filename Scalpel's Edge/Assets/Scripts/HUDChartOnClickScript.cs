using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDChartOnClickScript : MonoBehaviour
{
    //tuple to hold patient info. Private here, but would be recieved dynamically in full implementation
    //here I have the patient outlook represented by an int scale (for a=example, 1 = no danger - 5 = critical)
    //we could use an enumerator or simply strings if that would be easier. 
    private (string name, int age, string description, int outlook) patientInfo;

    //Allows tuple info to be assigned by and updated independently
    //Talking to receptionist to get better description or outlook changing over time for example
    private string patientName = "Empty Bed";
    private int patientAge = 0;
    private string patientDescription = "An empty bed, no patient currently";
    private int patientOutlook = 1;

    //currently, this is just text and a blank background
    public GameObject chartText;
    public GameObject chartParent;

    //We will get this from the chart
    private TMPro.TextMeshProUGUI textMesh;

    //Data to be written to chart ui. This would be found dynamically when a patient is created
    private string chartData;

    // Start is called before the first frame update
    void Start()
    {
        //initialize hud info
        textMesh = chartText.GetComponent<TMPro.TextMeshProUGUI>();
        //This would be assigned dynamically when new patients are created. 
        //For the sake of the demo, it will just be initialized here
        //prepare data
        UpdateData(patientName, patientAge, patientDescription, patientOutlook);

      
    }

    // Update is called once per frame
    void Update()
    {
        //check if clipboard was clicked on.
        //first check for click. Don't need to raycast every frame if not clicking
        if (Input.GetMouseButtonDown(0))
        {
            //Raycast on click
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //check for the hit on this object
                if (hit.transform.parent != null && hit.transform.parent.transform.name.Equals(gameObject.transform.name))
                {
                    //this specific board was clicked, write data and display chart
                    Activate();
                }
            }
            //If no hits occurred, do nothing
        }

    }
    
    // Simple reusable call to display chart info.
    //passes the data to the chart window and activates it
    public void Activate()
    {
        //prepare text to write to chart
        chartData = chartParent.GetComponent<HUDChartHiderScript>().defaultText;
        //probably a cleaner way to do this
        chartData = chartData.Replace("<name>", patientInfo.name);
        chartData = chartData.Replace("<age>", patientInfo.age.ToString());
        chartData = chartData.Replace("<desc>", patientInfo.description);
        chartData = chartData.Replace("<outlook>", GetOutlookText(patientInfo.outlook));

        textMesh.SetText(chartData);
        //reset its timer if already on screen, otherwise, just display
        chartParent.SetActive(false);
        chartParent.SetActive(true);
    }

    //Updates the chartData. All parameters optional, but can replace all
    public void UpdateData(string newName = null, int newAge = -1, string newDesc = null, int newOutlook = -1)
    {
        //replace info as needed
       if (newName != null)
        {
            patientInfo.name = newName;
        }

       if (newAge != -1)
        {
            patientInfo.age = newAge;
        }

       if (newDesc != null)
        {
            patientInfo.description = newDesc;
        }

       if (newOutlook != -1)
        {
            patientInfo.outlook = newOutlook;
        }
    }

    //Currently these are hard coded, but we can change that later. Number of outlook "stages" is not set in stone,
    //neither is the descriptot
    public string GetOutlookText(int outlook)
    {
        switch (outlook)
        {
            //these don't have breaks because they return.
            //fallthrough should not be possible
            case 1:
                return "No Immediate Danger";
            case 2:
                return "Minor Risk";
            case 3:
                return "Moderate Risk";
            case 4:
                return "Needs Immediate Attention";
            case 5:
                return "Situaltion Critical";
            default:
                return "Unrecognized Outlook Code. If you see this, report a bug";

        }
    }
}
