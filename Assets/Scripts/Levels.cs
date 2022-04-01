using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class Levels : MonoBehaviour
{
    public int levelN;
    public bool isGameEnd =true;
    public bool levelComplete = false;

    Spawn spawn;
    InitializeObjects initializeObjects;
    DoGraphics graphics;

    private void Start()
    {
        spawn = GameObject.Find("SpawnManager").GetComponent<Spawn>();
        initializeObjects = GameObject.Find("SpawnManager").GetComponent<InitializeObjects>();
        graphics = GameObject.Find("SpawnManager").GetComponent<DoGraphics>();
        StartLevel();
    }
    public void StartLevel()
    {
        spawn.InitializeTiles();
        initializeObjects.SetSprites();
        graphics.findSymbolText.text = "Find '" + initializeObjects.letterToFind + "'";
        graphics.InitialGraphics(spawn.tiles.transform);
        isGameEnd = false;
        
    }
    private void Update()
    {
        if (levelComplete) levelN++;
    }


}
