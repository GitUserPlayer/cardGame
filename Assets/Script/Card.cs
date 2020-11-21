using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    
    
    public GameObject card;

    public void CardIdOb(int cardID) 
    {
        card.SendMessage("CardIint",new CardClass(cardID,gameObject));
    } 
}
