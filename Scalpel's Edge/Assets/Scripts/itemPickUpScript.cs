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

    [SerializeField]
    private float pickUpRange;

    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    //variables needed for properly targeting
    [SerializeField]
    private string selectableTag = "Selectable";

    private Transform objTransform;

    // Start is called before the first frame update
    void Start()
    {
        //medicineScript.enabled = false;
        rb.isKinematic = false;
        coll.isTrigger = false;
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
            if (selection.CompareTag(selectableTag))
            {
                if (Input.GetKeyDown("e") && !equipped && distanceToPlayer.magnitude <= pickUpRange && !slotFull)
                {
                    print("Item has been picked up");
                    equipped = true;
                    slotFull = true;
                    objTransform = selection;
                    objTransform.parent = HandContainer.transform;
                    objTransform.localPosition = Vector3.zero;
                    objTransform.localRotation = Quaternion.Euler(Vector3.zero);
                    rb = hit.rigidbody;
                    coll = hit.collider;
                    rb.isKinematic = true;
                    coll.isTrigger = true;

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
        }
    }
}
