using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickUpScript : MonoBehaviour
{

    //might need something of this type
    //public Medicine medicineScript;
    public Rigidbody rb;
    public Collider coll;
    public Transform player, HandContainer, cam;

    public GameObject item;
    public Treatment itemTreatment;
    public string itemID;

    [SerializeField]
    private float pickUpRange;

    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    //variables needed for properly targeting
    [SerializeField]
    //private string selectableTag = "Selectable";

    private Transform objTransform;

    // Start is called before the first frame update
    void Start()
    {
        HandContainer.position = HandContainer.position + Vector3.down * 0.5f;
        //medicineScript.enabled = false;
        //rb.isKinematic = false;
        //coll.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag("Antibiotics") || selection.CompareTag("Burn Creams") || selection.CompareTag("Bandages"))
            {
                if (Input.GetKeyDown("e") && !equipped && distanceToPlayer.magnitude <= pickUpRange && !slotFull)
                {
                    print("Item has been picked up");
                    equipped = true;
                    slotFull = true;
                    objTransform = selection;
                    //HandContainer.position = HandContainer.position + Vector3.down * 0.5f;
                    //print(HandContainer.position);
                    objTransform.parent = HandContainer.transform;
                    objTransform.localPosition = Vector3.zero;
                    objTransform.localRotation = Quaternion.Euler(Vector3.zero);
                    rb = hit.rigidbody;
                    coll = hit.collider;
                    rb.isKinematic = true;
                    coll.isTrigger = true;
                    itemTreatment = objTransform.GetComponent<Treatment>();
                    if(itemTreatment==null) {
                        print("itemTreatment is null");
                    }
                    itemID = itemTreatment.getTreatment();
                    if(itemID==null||itemID=="") {
                        print("itemID is null");
                    }
                    //print(itemID);
                    //print("Success");
                    //definitely making it here.
                }
            }
        }

        if (equipped && Input.GetKeyDown("q") && objTransform.parent != null)
        {
            print("Item has been dropped");
            equipped = false;
            slotFull = false;

            //Set parent to null
            objTransform.parent = null;

            //Make Rigidbody not kinematic and BoxCollider normal
            rb.isKinematic = false;
            coll.isTrigger = false;

            //Set held object ID to null
            itemID = null;
        }
    }
}
