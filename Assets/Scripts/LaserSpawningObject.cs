using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawningObject : MonoBehaviour
{
    public LaserSpawner[] spawners;

    public void UpdateLasers()
    {
        foreach (var spawner in spawners)
        {
            spawner.UpdateLaser();
            Debug.Log("Updatin!");
        }
    }
}
