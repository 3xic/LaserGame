using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGenerator : MonoBehaviour
{
    public GameObject tile;

    public GameObject[] objects;

    Animator tileAnimator;

    void Start()
    {
        GeneratePuzzleGrid();
    }
 
    void GeneratePuzzleGrid() {
        GenerateTiles();
        GenerateObjects();
    }

    void GenerateObjects() {
        for(int i = 0; i < Puzzle.instance.objects.Length; i++) {
            CreateGameObject(Puzzle.instance.objects[i]);
        }
    }

    void GenerateTiles() {
        int size = Puzzle.instance.size;
        for (int i = 0; i < size; i++) {
            for(int j = 0; j < size; j++) {
                //tile creation and centering logic
                Vector3 loc = new Vector3(
                    0 - ((size + 1) / 2) + i,
                    0,
                    0 - ((size + 1) / 2) + j
                );

                //create the tiles ALSO FIX THE IMPORT BEING ROTATED IMPROPERLY fucking fbx bullshit I DONT KNOW HOW THIS WORKS
                GameObject obj = Instantiate(tile, loc, Quaternion.Euler(-90,0,0));
                
                //trigger spawn animation on object creation
                tileAnimator = obj.GetComponent<Animator>();
                tileAnimator.SetTrigger("Spawn");
            }
        }
    }

    //fix color bs
    void CreateGameObject(PuzzleObjectCreationData p) {
        GameObject obj;
        switch (p.type) {
            case PuzzleObjectType.EMITTER:
                obj = Instantiate(objects[0], new Vector3(p.pos.x, .5f, p.pos.y), Quaternion.Euler(0, p.getRot(), 0));
                foreach (var group in obj.GetComponent<ColoredPuzzleObject>().groups)
                {
                    obj.GetComponent<ColoredPuzzleObject>().setColor(p.col, group);
                }
                obj.GetComponent<LaserSpawningObject>().spawners[0].SetLaserColor(p.col);
                return;
            case PuzzleObjectType.RECIEVER:
                obj = Instantiate(objects[1], new Vector3(p.pos.x, .5f, p.pos.y), Quaternion.Euler(0, p.getRot(), 0));
                foreach (var group in obj.GetComponent<ColoredPuzzleObject>().groups)
                {
                    obj.GetComponent<ColoredPuzzleObject>().setColor(p.col, group);
                }
                return;
            case PuzzleObjectType.REFLECTOR:
                obj = Instantiate(objects[2], new Vector3(p.pos.x, .5f, p.pos.y), Quaternion.Euler(0, p.getRot(), 0));
                foreach (var group in obj.GetComponent<ColoredPuzzleObject>().groups)
                {
                    obj.GetComponent<ColoredPuzzleObject>().setColor(p.col, group);
                }
                return;
            case PuzzleObjectType.SPLITTER:
                obj = Instantiate(objects[3], new Vector3(p.pos.x, .5f, p.pos.y), Quaternion.Euler(0, p.getRot(), 0));
                foreach (var group in obj.GetComponent<ColoredPuzzleObject>().groups)
                {
                    obj.GetComponent<ColoredPuzzleObject>().setColor(p.col, group);
                }
                return;
            case PuzzleObjectType.MERGER:
                obj = Instantiate(objects[4], new Vector3(p.pos.x, .5f, p.pos.y), Quaternion.Euler(0, p.getRot(), 0));
                foreach (var group in obj.GetComponent<ColoredPuzzleObject>().groups)
                {
                    obj.GetComponent<ColoredPuzzleObject>().setColor(p.col, group);
                }
                return;
            case PuzzleObjectType.TRIGGER:
                obj = Instantiate(objects[5], new Vector3(p.pos.x, .5f, p.pos.y), Quaternion.Euler(0, p.getRot(), 0));
                foreach (var group in obj.GetComponent<ColoredPuzzleObject>().groups)
                {
                    obj.GetComponent<ColoredPuzzleObject>().setColor(p.col, group);
                }
                return;
            case PuzzleObjectType.STOPPER:
                Instantiate(objects[6], new Vector3(p.pos.x, 1, p.pos.y), Quaternion.identity).GetComponent<PuzzleObject>();
                return;
        }
    
    }
}
