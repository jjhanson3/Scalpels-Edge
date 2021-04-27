using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionPopUpScript : MonoBehaviour
{
    //default text to be written
    [TextArea]
    public string defaultText;

    //child to modify with this script
    public GameObject textObject;
    // Start is called before the first frame update
    void Start()
    {
        //Disable the hud to start
        gameObject.SetActive(false);
    }
}
