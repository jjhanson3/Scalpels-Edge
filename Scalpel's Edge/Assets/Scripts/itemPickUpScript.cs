using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickUpScript : MonoBehaviour
{

    //might need something of this type
    //public Medicine medicineScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, HandContainer, cam;

    [SerializeField]
    private float pickUpRange;

    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    //variables needed for properly targeting
    [SerializeField]
    private string selectableTag = "Selectable";

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

                    hit.transform.parent = HandContainer.transform;
                    hit.transform.localPosition = Vector3.zero;
                    hit.transform.localRotation = Quaternion.Euler(Vector3.zero);
                    transform.localScale = Vector3.one;
                    rb.isKinematic = true;
                    coll.isTrigger = true;

                }
            }
        }

        if (equipped && Input.GetKeyDown("q") && transform.parent != null)
        {
            print("Item has been dropped");
            equipped = false;
            slotFull = false;

            //Set parent to null
            transform.parent = null;

            //Make Rigidbody not kinematic and BoxCollider normal
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
    }
}
