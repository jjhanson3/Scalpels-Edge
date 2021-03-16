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
                var selectionRenderer = selection.GetComponent<Renderer>();
                //print("Tag is correct " + selectionRenderer);
                //if (selectionRenderer != null)
                //{
                if (Input.GetKeyDown("e") && !equipped && distanceToPlayer.magnitude <= pickUpRange && !slotFull)
                {
                    hit.transform.SetParent(HandContainer);
                    print("Get inside of button press");
                        hit.transform.SetParent(HandContainer);
                        hit.transform.localPosition = Vector3.zero;
                        hit.transform.localRotation = Quaternion.Euler(Vector3.zero);
                        rb.isKinematic = true;
                        coll.isTrigger = true;

                    //PickUp();
                }
                //}
            }
        }

        if (equipped && Input.GetKeyDown("q"))
        {
            Drop();
        }
    }

    private void PickUp()
    {
        print("Item has been picked up");
        equipped = true;
        slotFull = true;

        //Make weapon a child of the camera and move it to default position
        transform.SetParent(HandContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;


        //Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        //Enable script
        //medicineScript.enabled = true;

    }

    private void Drop()
    {
        print("Item has been dropped");
        equipped = false;
        slotFull = false;

        //Set parent to null
        transform.SetParent(null);

        //Make Rigidbody not kinematic and BoxCollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;

        //Gun carries momentum of player
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //Add force
        rb.AddForce((Vector3.one + cam.forward) * dropForwardForce, ForceMode.Impulse);
        rb.AddForce((Vector3.one + cam.up) * dropUpwardForce, ForceMode.Impulse);

        //Disable script
        //medicineScript.enabled = false;
    }
}
