using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HUDChartSelectScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject thisChart;
    public GameObject parentBackground;

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    // Called on UI click
    public void OnPointerClick(PointerEventData ped)
    {
        //display mini chart
        thisChart.GetComponent<HUDChartOnClickScript>().Activate();
        //Toggle menu screen
        parentBackground.SetActive(!parentBackground.activeSelf);
    }
}
