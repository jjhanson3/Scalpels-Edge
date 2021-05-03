using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDMenuInputHandlerScript : MonoBehaviour
{
    //The chart menu
    public GameObject chartMenu;

    public GameObject actionPopUp;

    private HUDActionManager hudActionManager;
    private string actionInfo = "";
    private string actionItem = "";
    private string popUpInfo;

    private TMPro.TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = actionPopUp.GetComponent<TMPro.TextMeshProUGUI>();
        //temproarily unsused
    }

    private void Awake()
    {
        hudActionManager = GameObject.FindObjectOfType<HUDActionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check for each potential button press that would make a menu
        actionInfo = hudActionManager.getPlayerAction();
        actionItem = hudActionManager.getItem();

        //P for patients, the "master chart"
        if (Input.GetKeyDown("p")) {
            //Toggle menu screen
            actionPopUp.SetActive(false);
            chartMenu.SetActive(!chartMenu.activeSelf);
        } else if (actionInfo != "") {
            print("Get inside of this loop");
            print("actionInfo");
            actionPopUp.SetActive(true);
            popUpInfo = actionPopUp.GetComponent<actionPopUpScript>().defaultText;
            if (actionInfo == "Pickup")
            { //Display "[E] Pickup"
                popUpInfo = popUpInfo.Replace("<Instruction>", "[E] Pickup " + actionItem);
                textMesh.SetText(popUpInfo);
                print("It is pick up time player");
            }
            else if (actionInfo == "Treat")
            { //Display "[Click] Treat"
                popUpInfo = popUpInfo.Replace("<Instruction>", "[Click] Treat");
                textMesh.SetText(popUpInfo);
                print("It is treat time player");
            }
            else if (actionInfo == "Talk")
            { //Display "[T] Talk"
                popUpInfo = popUpInfo.Replace("<Instruction>", "[T] Talk");
                textMesh.SetText(popUpInfo);
                print("It is talk time player");
            }
            else if (actionInfo == "")
            { //Return to empty state

            }
        } else {
            actionPopUp.SetActive(false);
        }
    }
}
