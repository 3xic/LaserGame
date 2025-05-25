using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredPuzzleObject : PuzzleObject
{
    public ObjectColor color;

    public Renderer[] meshRenderers;

    private static Material[] materials;
    
    private void Awake()
    {
        materials = new Material[]{
            Resources.Load<Material>("Materials/Temp/Emitter"),
            Resources.Load<Material>("Materials/Temp/Reciever"),
            Resources.Load<Material>("Materials/Temp/Reflector"),
            Resources.Load<Material>("Materials/Temp/Splitter"),
            Resources.Load<Material>("Materials/Temp/Merger"),
            Resources.Load<Material>("Materials/Temp/Trigger")
        };
    }

    public void setColor(ObjectColor color)
    {
        switch (color)
        {
            case ObjectColor.NONE:
                return;

            case ObjectColor.RED:
                foreach (var renderer in meshRenderers)
                {
                    renderer.material = materials[0];
                }
                return;

            case ObjectColor.ORANGE:
                foreach (var renderer in meshRenderers)
                {
                    renderer.material = materials[1];
                }
                return;

            case ObjectColor.YELLOW:
                foreach (var renderer in meshRenderers)
                {
                    renderer.material = materials[2];
                }
                return;

            case ObjectColor.GREEN:
                foreach (var renderer in meshRenderers)
                {
                    renderer.material = materials[3];
                }
                return;

            case ObjectColor.BLUE:
                foreach (var renderer in meshRenderers)
                {
                    renderer.material = materials[4];
                }
                return;

            case ObjectColor.VIOLET:
                foreach (var renderer in meshRenderers)
                {
                    renderer.material = materials[5];
                }
                return;
        }
    }
}
