using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserSpawner : MonoBehaviour
{
    public ObjectColor color;

    public bool active = false;

    private LayerMask mask;

    private LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
    }

    public void UpdateLaser()
    {
        mask = LayerMask.GetMask("LaserInteractable");
        if (!active)
        {
            active = true;
            lr.enabled = active;
            Ray laser = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, transform.position + (transform.TransformDirection(Vector3.forward) * 10));

            Debug.Log(lr.material.GetColor("_EmissionColor"));
            lr.material.SetColor("_EmissionColor", EmissionFromColor());
        }
        else
        {
            active = false;
            lr.enabled = active;
        }
    }

    private Color EmissionFromColor()
    {
        switch (color)
        {
            case ObjectColor.RED:
                return new Color(2, 0, 0, 1);

            case ObjectColor.ORANGE:
                return new Color(2, .5f, 0, 1);

            case ObjectColor.YELLOW:
                return new Color(2, 2, 0, 1);

            case ObjectColor.GREEN:
                return new Color(0, 2, 0, 1);

            case ObjectColor.BLUE:
                return new Color(0, .5f, 2, 1);

            case ObjectColor.VIOLET:
                return new Color(1, 0, 2, 1);

            case ObjectColor.NONE:
                return new Color(1, 1, 1, 1);

            default:
                return new Color(1, 1, 1, 1);
        }
    }
}
