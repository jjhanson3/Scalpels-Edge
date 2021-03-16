using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDChartOnClickScript : MonoBehaviour
{
    //tuple to hold patient info. Private here, but would be recieved dynamically in full implementation
    //here I have the patient outlook represented by an int scale (for a=example, 1 = no danger - 5 = critical)
    //we could use an enumerator or simply strings if that would be easier. 
    (string name, int age, string description, int outlook) patientInfo;

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
        patientInfo = ("Dummy, Test", 24, "Patient claims to be invisible, but I don't see a problem", 1);

        //prepare text to write to chart
        chartData = textMesh.text;
        //probably a cleaner way to do this
        chartData = chartData.Replace("<name>", patientInfo.name);
        chartData = chartData.Replace("<age>", patientInfo.age.ToString());
        chartData = chartData.Replace("<desc>", patientInfo.description);
        chartData = chartData.Replace("<outlook>", "No immediate risk");
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
                if (hit.transform.name.Equals(gameObject.transform.name))
                {
                    //this specific board was clicked, write data and display chart
                    textMesh.SetText(chartData);
                    chartParent.SetActive(true);
                }
            }
            //If no hits occurred, do nothing
        }

    }
}
