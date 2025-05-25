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

    void CreateGameObject(PuzzleObjectCreationData p) {
        switch(p.type) {
            case PuzzleObjectType.EMITTER:
                GameObject obj = Instantiate(objects[0], new Vector3(p.pos.x, .5f, p.pos.y), Quaternion.Euler(0, p.getRot(), 0));
                obj.GetComponent<ColoredPuzzleObject>().setColor(p.col);
                obj.GetComponent<LaserSpawningObject>().spawners[0].color = p.col;
                return;
            case PuzzleObjectType.RECIEVER:
                Instantiate(objects[1], new Vector3(p.pos.x, .5f, p.pos.y), Quaternion.Euler(0, p.getRot(), 0)).GetComponent<ColoredPuzzleObject>().setColor(p.col);
                return;
            case PuzzleObjectType.REFLECTOR:
                Instantiate(objects[2], new Vector3(p.pos.x, 1, p.pos.y), Quaternion.Euler(0, p.getRot(), 0)).GetComponent<PuzzleObject>();
                return;
            case PuzzleObjectType.SPLITTER:
                Instantiate(objects[3], new Vector3(p.pos.x, 1, p.pos.y), Quaternion.Euler(0, p.getRot(), 0)).GetComponent<PuzzleObject>();
                return;
            case PuzzleObjectType.MERGER:
                Instantiate(objects[4], new Vector3(p.pos.x, 1, p.pos.y), Quaternion.Euler(0, p.getRot(), 0)).GetComponent<PuzzleObject>();
                return;
            case PuzzleObjectType.TRIGGER:
                Instantiate(objects[5], new Vector3(p.pos.x, 1, p.pos.y), Quaternion.Euler(0, p.getRot(), 0)).GetComponent<ColoredPuzzleObject>().setColor(p.col);
                return;
            case PuzzleObjectType.STOPPER:
                Instantiate(objects[6], new Vector3(p.pos.x, 1, p.pos.y), Quaternion.Euler(0, p.getRot(), 0)).GetComponent<PuzzleObject>();
                return;
        }
    
    }
}
