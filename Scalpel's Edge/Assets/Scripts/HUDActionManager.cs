﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDActionManager : MonoBehaviour
{
    private string actionInfo = "";
    private string item = "";

    // Displays what control the player needs to press to do the corresponding action
    public void updatePlayerAction (string possibleAction)
    {
        if (actionInfo == "")
        {
            actionInfo = possibleAction;
        }
        
    }

    public void updatePickUpItem (string newItem)
    {
        if (item == "")
        {
            item = newItem;
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
            item = "";
        }
    }

    public string getPlayerAction ()
    {
        return actionInfo;
    }

    public string getItem ()
    {
        return item;
    }
}
