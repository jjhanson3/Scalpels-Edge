using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimerScript : MonoBehaviour
{
    //Should new patients spawn?
    public bool spawnActive;
    //should patient condition worsen?
    public bool conditionActive;

    //How often should patients spawn?
    public int spawnIntervals;

    //How many patients should be spawned?
    public int spawnCount;

    private int inc;

    //How big the interval should be for actions.
    //Upon creation, wounds should have an interval field
    //representing how many intervals should pass before condition worsens.
    //Further, new characters spawn after a given number of intervals. This is serialized for testing,
    //but could be made constant for a final build
    [SerializeField]
    float interval;

    private float timer = 0;

    //A list of wounds to send updates to, starts empty
    private List<GameObject> woundsList = new List<GameObject>();

    //array containing all beds will be checked to find an empty one for new patients
    public GameObject allBeds;

    // Start is called before the first frame update
    void Start()
    {
        //maybe initialize the patiets to spawn for a level here?
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < interval)
        {   
            //simply increment timer
            timer += Time.deltaTime;
        }
        else
        {
            //reset timer
            timer = 0;
            if (conditionActive)
            {
                foreach(GameObject wound in woundsList)
                {
                    //call interval update in wound
                    wound.GetComponent<Wound>().IntervalUpdate();
                }
            }
            if (spawnActive)
            {
                if (inc < spawnIntervals)
                {
                    inc++;
                }
                else
                {
                    //choose location
                    bool spawned = false;
                    while (!spawned)
                    {
                        int randBedIndex = Random.Range(0, allBeds.transform.childCount);
                        Transform randBed = allBeds.transform.GetChild(randBedIndex);
                        if (randBed.GetComponent<BedScript>().isEmpty)
                        {
                            //bed is empty, we can spawn here and break
                            
                            spawned = true;
                            randBed.GetComponent<BedScript>().MakeNewWound();
                            Debug.Log("Wound created at " + randBed.name);
                        }
                    }
                    inc = 0;
                    spawnCount--;
                    if (spawnCount == 0)
                    {
                        spawnActive = false;
                    }
                }
            }
        }
    }

    //Simple method to allow wounds to add themselves to the update list
    public void AddWound(GameObject wound)
    {
        woundsList.Add(wound);
    }

    //simple method to allow wounds to be removed on disable
    public void RemoveWound(GameObject wound)
    {
        woundsList.Remove(wound);
    }
}
