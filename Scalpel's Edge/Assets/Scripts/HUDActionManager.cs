using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDActionManager : MonoBehaviour
{
    private string actionInfo = "";

    // Update is called once per frame
    void Update()
    {
        if (actionInfo == "Pickup")
        { //Display "[E] Pickup"
            print("It is pick up time player");
        }
        else if (actionInfo == "Treat")
        { //Display "[Click] Treat"
            print("It is treat time player");
        }
        else if (actionInfo == "Talk")
        { //Display "[T] Talk"
            print("It is talk time player");
        }
        else if (actionInfo == "")
        { //Return to empty state

        }
    }

    // Displays what control the player needs to press to do the corresponding action
    public void updatePlayerAction (string possibleAction)
    {
        if (actionInfo == "")
        {
            actionInfo = possibleAction;
            print("Set action info");
        }
        
    }

    // Sets actionInfo to "" if the key matches actionInfo. Ensures that actionInfo is only cleared if it is called from the correct location
    // Example: itemPickUpScript calls this function when actionKey = "Talk". Value of actionKey will not be changed because clearPlayerAction 
    // from ItemPickUpScript will have the parameter of "Pickup"
    public void clearPlayerAction (string actionKey)
    {
        if(actionKey == actionInfo)
        {
            actionInfo = "";
            print("set actionInfo to nothing");
        }
    }
}
