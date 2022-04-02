using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class InitializeObjects : MonoBehaviour
{
    [SerializeField] private CardBundleDate letters;
    [SerializeField] private CardBundleDate newData;
    [SerializeField] private CardBundleDate numbers;
    [SerializeField] private Sprite[] lettersImages;
    [SerializeField] private Sprite[] numbersImages;
    private string alphabed = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private string digits = "1234567890";
    private string newdata = "";
    public string NewData
    {
        get => newdata;
        set { value = newdata; }
    }
    private string letterToFind;
    public string LetterToFind
    {
        get => letterToFind;
        private set { }
    }
    private GameObject[] sprites;
    private Spawn spawn;

    void Start()
    {
        spawn = GameObject.Find("SpawnManager").GetComponent<Spawn>();
        
        letters.CardData = new CardData[alphabed.Length];
        numbers.CardData = new CardData[digits.Length];
        SetData();
    }
    void SetData()
    {
        for (int i = 0; i < digits.Length; i++)
        {
            numbers.CardData[i] = new CardData();
            numbers.CardData[i].Sprite = numbersImages[i];
            numbers.CardData[i].Identifier = digits[i].ToString();
        }

        for (int i = 0; i < lettersImages.Length; i++)
        {
            letters.CardData[i] = new CardData();
            letters.CardData[i].Sprite = lettersImages[i];
            letters.CardData[i].Identifier = alphabed[i].ToString();
        }
    }


    public void SetSprites()
    {
        sprites = new GameObject[spawn.gameObjects.Length];
        FindRandom(spawn.levels.levelN);
        for (int i = 0; i < spawn.gameObjects.Length; i++)
        {
            int number = Random.Range(0, numbers.CardData.Length);
            sprites[i] = new GameObject();
            sprites[i].transform.parent = spawn.gameObjects[i].transform;
            sprites[i].transform.position = spawn.gameObjects[i].transform.position;
            sprites[i].transform.localScale *= 0.5f;
            sprites[i].AddComponent<SpriteRenderer>();
            sprites[i].GetComponent<SpriteRenderer>().sprite = newData.CardData[i].Sprite;
            sprites[i].name = newData.CardData[i].Identifier;
            sprites[i].AddComponent<Click>();
            sprites[i].GetComponent<SpriteRenderer>().sortingOrder = 2;
            sprites[i].AddComponent<BoxCollider2D>();
           
        }
    }
    CardBundleDate FindRandom(int level)
    {
        newData = new CardBundleDate();
        newdata = "";
        newData.CardData = new CardData[spawn.gameObjects.Length];
        var data = Random.Range(0, 2) == 0 ? numbers : letters;
        for (int i = 0; i < spawn.gameObjects.Length; i++) 
        {
            Random: int number = Random.Range(0, data.CardData.Length);
            newData.CardData[i] = data.CardData[number];
            foreach (var item in NewData)
            {
                if(newData.CardData[i].Identifier == item.ToString())
                 goto Random;
            }
            newdata += newData.CardData[i].Identifier;
        }
        letterToFind = newdata[Random.Range(0, newdata.Length)].ToString();

        return newData;
    }
}
