using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

[Serializable]
public struct PuzzleObjectCreationData
{
    [SerializeField]
    public PuzzleObjectType type;
    [SerializeField]
    public Vector2Int pos;
    [SerializeField]
    public ObjectColor col;
    [SerializeField]
    public ObjectSpawnOrientations orientation;

    public PuzzleObjectCreationData(PuzzleObjectType t, Vector2Int p)
    {
        type = t;
        pos = p;
        col = ObjectColor.NONE;
        orientation = ObjectSpawnOrientations.LEFT;
        
    }

    public PuzzleObjectCreationData(PuzzleObjectType t, Vector2Int p, ObjectSpawnOrientations o)
    {
        type = t;
        pos = p;
        col = ObjectColor.NONE;
        orientation = o;
    }


    public PuzzleObjectCreationData(PuzzleObjectType t, Vector2Int p, ObjectColor c)
    {
        type = t;
        pos = p;
        col = c;
        orientation = ObjectSpawnOrientations.LEFT;
    }

    public PuzzleObjectCreationData(PuzzleObjectType t, Vector2Int p, ObjectColor c, ObjectSpawnOrientations o)
    {
        type = t;
        pos = p;
        col = c;
        orientation = o;
    }

    private static int OrientationToInt(ObjectSpawnOrientations o)
    {
        switch (o)
        {
            case ObjectSpawnOrientations.LEFT:
                return 0;

            case ObjectSpawnOrientations.RIGHT:
                return 180;

            case ObjectSpawnOrientations.UP:
                return 90;

            case ObjectSpawnOrientations.DOWN:
                return -90;

            default:
                return 0;
        }
    }

    public int getRot()
    {
        return OrientationToInt(orientation);
    }
}
