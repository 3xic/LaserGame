using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserReciever : MonoBehaviour
{
    public bool isRecieving = false;

    PuzzleObjectType type;
    
    private void Start()
    {
        //get the type of object we just connected with to perform the proper Connect function
        type = transform.GetComponentInParent<PuzzleObject>().GetPObjType();
    }

    //on laser connect function, takes in the original laserspawner to set the colors properly
    public void OnLaserConnect(LaserSpawner orig)
    {
        LaserSpawner l = transform.parent.GetComponentInChildren<LaserSpawner>();
        Debug.Log("IM CONNECTED GNG");
        switch (type)
        {
            case PuzzleObjectType.REFLECTOR:
                l.color = orig.color;
                foreach (var group in GetComponentInParent<ColoredPuzzleObject>().groups)
                {
                    GetComponentInParent<ColoredPuzzleObject>().setColor(l.color, group);
                }
                GetComponentInParent<LaserSpawningObject>().UniqueUpdateAllLasersInObject(new ObjectColor[] { l.color });
                GetComponentInParent<LaserSpawningObject>().active = true;
                return;

            case PuzzleObjectType.SPLITTER:
                l.color = orig.color;
                ObjectColor[] colors = new ObjectColor[] { orig.color, LaserSpawningObject.SplitColor(orig.color)[0], LaserSpawningObject.SplitColor(orig.color)[1]};
                Debug.Log(GetComponentInParent<ColoredPuzzleObject>());
                for (int i = 0; i < GetComponentInParent<ColoredPuzzleObject>().groups.Length; i++)
                {
                    GetComponentInParent<ColoredPuzzleObject>().setColor(colors[i], GetComponentInParent<ColoredPuzzleObject>().groups[i]);
                }
                GetComponentInParent<LaserSpawningObject>().UniqueUpdateAllLasersInObject(LaserSpawningObject.SplitColor(l.color));
                GetComponentInParent<LaserSpawningObject>().active = true;
                return;

            default:
                return;
        }
    }

    public void OnLaserDisconnect()
    {
        isRecieving = false;
        GetComponentInParent<LaserSpawningObject>().UpdateAllLasersInObject(ObjectColor.NONE);
        GetComponentInParent<LaserSpawningObject>().active = false;
        foreach (var group in GetComponentInParent<ColoredPuzzleObject>().groups)
                {
                    GetComponentInParent<ColoredPuzzleObject>().setColor(ObjectColor.NONE, group);
                }
    }
}
