using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DoGraphics : MonoBehaviour
{
    Spawn spawn;
    InitializeObjects initializeObjects;
    Levels levels;
    public TextMeshProUGUI findSymbolText;
    private void Start()
    {
        findSymbolText.DOFade(0, 0);
        spawn = GameObject.Find("SpawnManager").GetComponent<Spawn>();
        levels = GameObject.Find("SpawnManager").GetComponent<Levels>();
        initializeObjects = GameObject.Find("SpawnManager").GetComponent<InitializeObjects>();
        
    }
    public void InitialGraphics(Transform transformobject)
    {
        if (levels.levelN == 1)
        {
            spawn.tiles.transform.DOScale(1f, 1);
            DOTween.Sequence().Append(transformobject.DOScale(1.5f, 1)).
                Append(transformobject.DOScale(0.75f, 2)).
                Append(transformobject.DOScale(1f, 1)).
                Append(findSymbolText.DOFade(1, 2));
            levels.isGameEnd = false;
        }
        
    }
    public void BackGroundFade(SpriteRenderer renderer)
    {
        renderer.DOFade(0.5f, 1);
    }
    public void Shake(Transform transformobject)
    {
        transformobject.DOShakePosition(1f, new Vector3(0.1f, 0, 0));
    }


}
