using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClass //: MonoBehaviour
{
    public int cardID;
    public GameObject Card_Ob;

    public CardClass(int ID,GameObject cardObject) 
    {
        cardID = ID;
        Card_Ob = cardObject;
    }
    
}
