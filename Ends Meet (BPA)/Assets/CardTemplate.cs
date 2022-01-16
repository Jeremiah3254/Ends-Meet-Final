using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card Template", menuName = "Card Template")]
public class CardTemplate : ScriptableObject
{
   public CommandCard[] commandCardsOriginal; 
   public CommandCard[] commandCards; 
}
