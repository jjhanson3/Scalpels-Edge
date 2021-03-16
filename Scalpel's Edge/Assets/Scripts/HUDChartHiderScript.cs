using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDChartHiderScript : MonoBehaviour
{
    //default text to be written
    [TextArea]
    public string defaultText;
    //Used to calculate the time to disable
    public float timer, interval = 2f;

    //child to modify with this script
    public GameObject textObject;
    // Start is called before the first frame update
    void Start()
    {
        //Disable the hud to start
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //Disable the hud after interval seconds 
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            gameObject.SetActive(false);
            timer = 0;
        }
    }

    // OnDisable is called when deactivated or disabled
    private void OnDisable()
    {
        //reset the data so any chart data could be applied
        TMPro.TextMeshProUGUI textMesh = textObject.GetComponent<TMPro.TextMeshProUGUI>();
        textMesh.SetText(defaultText);
    }
}
