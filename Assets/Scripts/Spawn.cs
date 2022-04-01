using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;
public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePref;

    private int columnNumber = 3;
    
    [SerializeField]
    private float x_Space, y_Space;

    [SerializeField]
    private float x_Start, y_start;
    public GameObject[] gameObjects;
    public GameObject tiles;
    public Levels levels;
    void Awake()
    {
        levels = GameObject.Find("SpawnManager").GetComponent<Levels>();
        gameObjects = new GameObject[columnNumber * levels.levelN];
    }
    public void InitializeTiles()
    {
        gameObjects = new GameObject[columnNumber * levels.levelN];
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i] = Instantiate(tilePref, new Vector3(x_Start + (x_Space * (i % columnNumber)), y_start + (-y_Space * (i / columnNumber))), Quaternion.identity);
            gameObjects[i].transform.parent = tiles.transform;
            
        }
    }
}
