using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredPuzzleObject : PuzzleObject
{
    public ObjectColor color;

    public ColoredObjectGroup[] groups;

    private static Material[] materials;
    
    private void Awake()
    {
        materials = new Material[]{
            Resources.Load<Material>("Materials/Temp/Emitter"),
            Resources.Load<Material>("Materials/Temp/Reciever"),
            Resources.Load<Material>("Materials/Temp/Reflector"),
            Resources.Load<Material>("Materials/Temp/Splitter"),
            Resources.Load<Material>("Materials/Temp/Merger"),
            Resources.Load<Material>("Materials/Temp/Trigger"),
            Resources.Load<Material>("Materials/Temp/Default")
        };
    }

    public void setColor(ObjectColor color, ColoredObjectGroup group)
    {
        switch (color)
        {
            case ObjectColor.NONE:
                foreach (var renderer in group.meshRenderers)
                {
                    renderer.material = materials[6];
                    this.color = ObjectColor.NONE;
                }
                return;

            case ObjectColor.RED:
                foreach (var renderer in group.meshRenderers)
                {
                    renderer.material = materials[0];
                    this.color = ObjectColor.RED;
                }
                return;

            case ObjectColor.ORANGE:
                foreach (var renderer in group.meshRenderers)
                {
                    renderer.material = materials[1];
                    this.color = ObjectColor.ORANGE;
                }
                return;

            case ObjectColor.YELLOW:
                foreach (var renderer in group.meshRenderers)
                {
                    renderer.material = materials[2];
                    this.color = ObjectColor.YELLOW;
                }
                return;

            case ObjectColor.GREEN:
                foreach (var renderer in group.meshRenderers)
                {
                    renderer.material = materials[3];
                    this.color = ObjectColor.GREEN;
                }
                return;

            case ObjectColor.BLUE:
                foreach (var renderer in group.meshRenderers)
                {
                    renderer.material = materials[4];
                    this.color = ObjectColor.BLUE;
                }
                return;

            case ObjectColor.VIOLET:
                foreach (var renderer in group.meshRenderers)
                {
                    renderer.material = materials[5];
                    this.color = ObjectColor.VIOLET;
                }
                return;
        }
    }
}
