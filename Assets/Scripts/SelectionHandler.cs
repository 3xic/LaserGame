using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectionHandler : MonoBehaviour
{
    public Vector2Int pos;

    public MovementHandler handler;
    
    //list of selectable objects, should only be objects that can be rotated and moved
    private PuzzleObjectType[] selectableObjects = { PuzzleObjectType.REFLECTOR, PuzzleObjectType.SPLITTER, PuzzleObjectType.MERGER, PuzzleObjectType.EMITTER, PuzzleObjectType.RECIEVER };

    //list of rotatable objects
    private PuzzleObjectType[] rotatableObjects = { PuzzleObjectType.REFLECTOR, PuzzleObjectType.EMITTER, PuzzleObjectType.RECIEVER };

    private bool inSelectionMode = true;

    private PuzzleObject selectedObj;

    private Animator animator;

    private Ray ray;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update() {
        MoveCursor();

        ray = new Ray(transform.position + new Vector3(0,2,0), new Vector3(0,-1,0));
        
        if(Input.GetKeyDown(KeyCode.Space)) {    
            UpdateSelectedObject();
        }
    }

    void MoveCursor() {
        if (inSelectionMode) {
            handler.MoveObject();
        }
        else if (!inSelectionMode && selectableObjects.Contains(selectedObj.GetComponent<PuzzleObject>().GetPObjType())) {
            return;
        }
        else {
            handler.MoveObjectWithCollision();
        }
        
        pos = new Vector2Int((int) transform.position.x, (int) transform.position.z);
    }

    private void UpdateSelectedObject() {
        if (inSelectionMode)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject obj = hit.transform.gameObject;
                if (obj.GetComponent<PuzzleObject>() != null)
                {
                    if (selectableObjects.Contains(obj.GetComponent<PuzzleObject>().GetPObjType()))
                    {
                        selectedObj = obj.GetComponent<PuzzleObject>();
                        selectedObj.selected = true;
                        Debug.Log("Object selected!");
                        inSelectionMode = false;
                        animator.SetBool("InSelectionMode", inSelectionMode);
                    }
                }
            }
        }
        else
        {
            if (selectedObj != null)
            {
                selectedObj.selected = false;
            }
            selectedObj = null;
            Debug.Log("Deselecting object");
            inSelectionMode = true;
            animator.SetBool("InSelectionMode", inSelectionMode);
        }
    }
}
