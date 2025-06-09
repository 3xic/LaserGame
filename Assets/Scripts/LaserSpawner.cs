using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserSpawner : MonoBehaviour
{
    public ObjectColor color;

    public bool active;

    private LayerMask mask;

    private LineRenderer lr;

    private LaserReciever target;

    private void Awake()
    {
        mask = LayerMask.GetMask("LaserInteractable", "LaserNotInteractable");
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
    }

    private void Update()
    {
        UpdateLaser(color);
    }

    //updates laser when called, if inactive, spanws a laser, if one is active, removes it ALSO maybe make the active thing turn on when the laser 
    public void UpdateLaser(ObjectColor col)
    {
        active = GetComponentInParent<LaserSpawningObject>().active;
        if (active)
        {
            SpawnLaser(col);
        }
        else
        {
            RemoveLaser();
        }
    }

    //spawns laser with given color c, if connects with a reciever, call that recievers OnLaserConnect method, if not, draw laser off screen
    private void SpawnLaser(ObjectColor c)
    {
        Ray laser = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        lr.enabled = true;

        if (Physics.Raycast(laser, out RaycastHit hit, 1000f, mask))
        {
            Debug.Log(hit.transform.gameObject.layer);
            Debug.Log(LayerMask.GetMask("LaserInteractable"));
            //we found something to interact with!
            if (hit.transform.gameObject.layer == 7)
            {
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z));
                SetLaserColor(c);

                //if we already found something but we hit another thing, change targets
                if (target != null && hit.transform.GetComponent<LaserReciever>() != target)
                {
                    target.OnLaserDisconnect();
                }
                target = hit.transform.GetComponent<LaserReciever>();

                target.OnLaserConnect(this);
            }
            //we found something but we can't interact with it :(
            else
            {
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z));
                SetLaserColor(c);

                if (target != null)
                {
                    target.OnLaserDisconnect();
                    target = null;
                }
            }

        }
        //we did not find anything so disconnect an existing laser and remove its target
        else
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, transform.position + (transform.TransformDirection(Vector3.forward) * 10));
            SetLaserColor(c);

            if (target != null)
            {
                target.OnLaserDisconnect();
                target = null;
            }
        }
    }
    
    //sets current laser spawner to color c
    public void SetLaserColor(ObjectColor c)
    {
        color = c;
        lr.material.SetColor("_EmissionColor", EmissionFromColor(c));
    }

    //disables the laser, and removes the target
    private void RemoveLaser()
    {
        lr.enabled = false;
        if (target != null)
        {
            target.OnLaserDisconnect();
        }
        target = null;
    }

    //gets emission color from object color
    private Color EmissionFromColor(ObjectColor c)
    {
        switch (c)
        {
            case ObjectColor.RED:
                return new Color(2, 0, 0, 1);

            case ObjectColor.ORANGE:
                return new Color(2, .23f, 0, 1);

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
