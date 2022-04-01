using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="CardData", fileName ="CardBundleData")]
public class CardBundleDate : ScriptableObject
{
 
    [SerializeField] private CardData[] _cardDatas;
    public CardData[] CardData { get; set; }
}
