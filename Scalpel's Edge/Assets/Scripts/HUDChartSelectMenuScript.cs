using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDChartSelectMenuScript : MonoBehaviour
{
    //camera to modify control status
    public GameObject cameraControl;

    // Start is called before the first frame update
    void Start()
    {
        //Disable the hud to start
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //as update is only run while active, this will only deactivate
        if (Input.GetKeyDown("p"))
        {
            //Deactivate object
            gameObject.SetActive(false);
        }
    }

    // Called when disabled or deactivated
    void OnDisable()
    {
        //enable camera control, and by extension, player movement
        cameraControl.GetComponent<cameraMovement>().locked = false;
    }

    private void OnEnable()
    {
        //disable camera control, and by extension, player movement
        cameraControl.GetComponent<cameraMovement>().locked = true;
    }
}
