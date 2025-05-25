using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    public void MoveObject() {
        if (Puzzle.instance == null) {
            Debug.LogError("Puzzle.instance is null");
            return;
        }
        
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && !(transform.position.x + 1 > (Puzzle.instance.size / 2) - 1)) {
            transform.position += new Vector3(1, 0, 0);
        }
        if((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && !(transform.position.x - 1 < -Math.Ceiling(Puzzle.instance.size / 2d))) {
            transform.position += new Vector3(-1, 0, 0);
        }
        if((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && !(transform.position.z - 1 < -Math.Ceiling(Puzzle.instance.size / 2d))) {
            transform.position += new Vector3(0, 0, -1);
        }
        if((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && !(transform.position.z + 1 > (Puzzle.instance.size / 2) - 1)) {
            transform.position += new Vector3(0, 0, 1);
        }
    }

    public void RotateObject()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(0, -90, 0, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(0, 90, 0, Space.World);
        }
    }

    public void MoveObjectWithCollision()
    {
        Ray ray;
        if (Input.GetKeyDown(KeyCode.UpArrow) && !(transform.position.x + 1 > (Puzzle.instance.size / 2) - 1))
        {
            ray = new Ray(transform.position + new Vector3(1, 2, 0), new Vector3(0, -1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !(transform.position.x - 1 < -Math.Ceiling(Puzzle.instance.size / 2d)))
        {
            ray = new Ray(transform.position + new Vector3(-1, 2, 0), new Vector3(0, -1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !(transform.position.z - 1 < -Math.Ceiling(Puzzle.instance.size / 2d)))
        {
            ray = new Ray(transform.position + new Vector3(0, 2, -1), new Vector3(0, -1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !(transform.position.z + 1 > (Puzzle.instance.size / 2) - 1))
        {
            ray = new Ray(transform.position + new Vector3(0, 2, 1), new Vector3(0, -1, 0));
        }
        else
        {
            ray = new Ray();
        }

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject obj = hit.transform.gameObject;
            if (obj.GetComponent<PuzzleObject>() == null)
            {
                MoveObject();
            }
        }
    }
}
