using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardData 
{
    [SerializeField]
    private string _identifier;

    [SerializeField]
    private Sprite _sprite;

    public string Identifier { get; set; }
    public Sprite Sprite { get; set; }
}
