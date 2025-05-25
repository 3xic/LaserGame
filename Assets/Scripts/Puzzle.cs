using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//Puzzle Singleton
public class Puzzle : MonoBehaviour
{
    public static Puzzle instance { get; private set; }

    
    public PuzzleObjectCreationData[] objects = {
            new PuzzleObjectCreationData(PuzzleObjectType.EMITTER, new Vector2Int(0,0), ObjectColor.RED),
            new PuzzleObjectCreationData(PuzzleObjectType.EMITTER, new Vector2Int(0,1), ObjectColor.YELLOW),
            new PuzzleObjectCreationData(PuzzleObjectType.EMITTER, new Vector2Int(0,2), ObjectColor.BLUE),
            new PuzzleObjectCreationData(PuzzleObjectType.REFLECTOR, new Vector2Int(0,3)),
            new PuzzleObjectCreationData(PuzzleObjectType.MERGER, new Vector2Int(1,1)),
            new PuzzleObjectCreationData(PuzzleObjectType.SPLITTER, new Vector2Int(1,2)),
            new PuzzleObjectCreationData(PuzzleObjectType.TRIGGER, new Vector2Int(1,3), ObjectColor.GREEN)
        };
    
    public int size = 10;

    private void Awake()
    {
        if(instance != null && instance != this) {
            Destroy(this);
        }
        else {
            instance = this;
        }
        generateJSONFromPuzzle();
    }

    public void generateJSONFromPuzzle() {
        string json = JsonUtility.ToJson(this, true);
        Debug.Log(json);

        using (StreamWriter writer = new StreamWriter(Application.dataPath + Path.AltDirectorySeparatorChar + "Test.json"))
        {
            writer.Write(json);
        }
    }

    public void loadPuzzleFromJSON() {

    }

}
