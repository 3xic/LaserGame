using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    [SerializeField]
    private PuzzleObjectType type = PuzzleObjectType.NONE;

    public bool selected = false;

    public MovementHandler handler;

    void LateUpdate()
    {
        if (selected)
        {
            OnSelect();
            OnInteract();
        }
    }

    //actions the player can do with the object selected, movement
    public void OnSelect()
    {
        switch (type)
        {
            case PuzzleObjectType.STOPPER:
                return;

            case PuzzleObjectType.RECIEVER:
                return;

            case PuzzleObjectType.EMITTER:
                //if (!IsLaserActive())
                //{
                //handler.RotateObject();
                //}
                handler.RotateObject();
                return;

            case PuzzleObjectType.TRIGGER:
                return;

            case PuzzleObjectType.REFLECTOR:
                handler.MoveObjectWithCollision();
                handler.RotateObject();
                handler.FlipObject();
                return;

            case PuzzleObjectType.SPLITTER:
                handler.MoveObjectWithCollision();
                handler.RotateObject();
                handler.FlipObject();
                return;

            case PuzzleObjectType.MERGER:
                handler.MoveObjectWithCollision();
                handler.RotateObject();
                handler.FlipObject();
                return;
        }
    }

    //actions the player can do with the object selected when they interact with the object
    public void OnInteract()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (type)
            {
                case PuzzleObjectType.STOPPER:
                    return;

                case PuzzleObjectType.RECIEVER:
                    return;

                case PuzzleObjectType.EMITTER:
                    GetComponent<LaserSpawningObject>().active = !GetComponent<LaserSpawningObject>().active;
                    //GetComponent<LaserSpawningObject>().UpdateLasers(new ObjectColor[] {GetComponent<ColoredPuzzleObject>().color});
                    return;

                case PuzzleObjectType.TRIGGER:
                    return;

                case PuzzleObjectType.REFLECTOR:
                    return;

                case PuzzleObjectType.SPLITTER:
                    return;

                case PuzzleObjectType.MERGER:
                    return;
            }
        }

    }

    public void SetType(PuzzleObjectType t)
    {
        if (type == PuzzleObjectType.NONE)
        {
            type = t;
        }
        else
        {
            return;
        }
    }

    public PuzzleObjectType GetPObjType()
    {
        return type;
    }

    public bool IsLaserActive()
    {
        return GetComponent<LaserSpawningObject>().spawners[0].active;
    }
}
