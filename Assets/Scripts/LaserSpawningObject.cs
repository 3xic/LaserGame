using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawningObject : MonoBehaviour
{
    public LaserSpawner[] spawners;

    public bool active = false;

    //updates all the lasers this object contains with a list of colors, one for each laser
    public void UniqueUpdateAllLasersInObject(ObjectColor[] colors)
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].UpdateLaser(colors[i]);
            Debug.Log("Updatin!");
        }
    }

    public void UpdateAllLasersInObject(ObjectColor color)
    {
        foreach (var spawner in spawners)
        {
            spawner.UpdateLaser(color);
            Debug.Log("Updatin!");
        }
    }

    public static ObjectColor[] SplitColor(ObjectColor col)
    {
        switch (col)
        {
            case ObjectColor.ORANGE:
                return new ObjectColor[] { ObjectColor.RED, ObjectColor.YELLOW };

            case ObjectColor.GREEN:
                return new ObjectColor[] { ObjectColor.YELLOW, ObjectColor.BLUE };

            case ObjectColor.VIOLET:
                return new ObjectColor[] { ObjectColor.BLUE, ObjectColor.RED };

            default:
                return new ObjectColor[] { col, col };
        }
    }
}
