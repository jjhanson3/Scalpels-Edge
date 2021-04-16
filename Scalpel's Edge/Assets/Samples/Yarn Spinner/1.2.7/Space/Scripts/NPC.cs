/*

The MIT License (MIT)

Copyright (c) 2015-2017 Secret Lab Pty. Ltd. and Yarn Spinner contributors.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yarn.Unity.Example {
    /// attached to the non-player characters, and stores the name of the Yarn
    /// node that should be run when you talk to them.

    public class NPC : MonoBehaviour {

        public string characterName = "";

        public string talkToNode = "";

        [Header("Optional")]
        public YarnProgram scriptToLoad;
        
        public DialogueRunner dialogueRunner;
        void Start () {
            if (scriptToLoad != null) {
                Debug.Log(scriptToLoad);
                //dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
                dialogueRunner.Add(scriptToLoad); 
                
                rb.isKinematic = false;
                coll.isTrigger = false;               
            }
        }

            public Rigidbody rb;
            public BoxCollider coll;
            public Transform player, HandContainer, cam;

            [SerializeField]
            private float speakingRange;

            //public float dropForwardForce, dropUpwardForce;

            public bool equipped;
            public static bool slotFull;

            //variables needed for properly targeting
            [SerializeField]
            private string selectableTag = "Selectable";

    
    

            // Update is called once per frame
            void Update()
            {
                //Debug.Log("check 2");
                Vector3 distanceToPlayer = player.position - transform.position;
                //Debug.Log(distanceToPlayer.magnitude);
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                //Debug.Log("check 0");
                var selection = hit.transform;
                if (selection.CompareTag(selectableTag)) {
                    //Debug.Log("Check 1");
                    var selectionRenderer = selection.GetComponent<Renderer>();
                    if (selectionRenderer != null) {
                        if (Input.GetKeyDown("t") && distanceToPlayer.magnitude <= speakingRange) {
                            //PickUp();
                            //Debug.Log("check 2");
                            dialogueRunner.StartDialogue(talkToNode);

                        } 
                    }
                }
                }

        
            }
        }
    }
