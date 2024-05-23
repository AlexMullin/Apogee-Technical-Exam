using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the creation and access of card types
/// </summary>
[CreateAssetMenu (fileName = "Card Data", menuName = "CardGame/Cards", order = 1)]
public class Database_Cards : ScriptableObject
{
   [Serializable]
   public class CardType 
   {
        [SerializeField] public Color cardColorBase = Color.white;
        [SerializeField] public Color cardColorSelected = Color.yellow;

        [SerializeField, Min(1)] public int dpMin = 1;
        [SerializeField, Min(2)] public int dpMax = 2;
        
        [SerializeField, Min(1)] public int apMin = 1;
        [SerializeField, Min(2)] public int apMax = 2;
   }

    public CardType [] cards;
}
