using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDMenuInputHandlerScript : MonoBehaviour
{
    //The chart menu
    public GameObject chartMenu;

    // Start is called before the first frame update
    void Start()
    {
        //temproarily unsused
    }

    // Update is called once per frame
    void Update()
    {
        //Check for each potential button press that would make a menu

        //P for patients, the "master chart"
        if (Input.GetKeyDown("p"))
        {
            //Toggle menu screen
            chartMenu.SetActive(!chartMenu.activeSelf);
        }
    }
}
