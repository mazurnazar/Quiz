using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour
{
    InitializeObjects initializeObjects;
    Levels levels;
    DoGraphics graphics;

    private void Start()
    {
        initializeObjects = GameObject.Find("SpawnManager").GetComponent<InitializeObjects>();
        levels = GameObject.Find("SpawnManager").GetComponent<Levels>();

        graphics = GameObject.Find("SpawnManager").GetComponent<DoGraphics>();
    }
    private void OnMouseDown()
    {
        if (levels.isGameEnd == false) 
        {
            if (this.gameObject.name == initializeObjects.LetterToFind)
            {
                Debug.Log("found");

                if (levels.levelN + 1 < 4)
                {
                    levels.levelN++;
                    var objects = GameObject.FindGameObjectsWithTag("tile");
                    foreach (var item in objects)
                    {
                        Destroy(item);
                    }
                    initializeObjects.NewData = "";
                    levels.StartLevel();
                }
                else levels.isGameEnd = true;
            }
            else
            {
                graphics.Shake(gameObject.transform);
            }
        }

    }



}
