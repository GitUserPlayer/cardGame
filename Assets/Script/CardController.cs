using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private Animator anim;
    private Collider col;

    public int card_id;

    public GameObject cardObject;

    public myCardManager cardManager;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider>();
        if (cardManager == null)
        {
            cardManager =
                GameObject.FindGameObjectWithTag("cardManager").GetComponent<myCardManager>();
        }
       

    }
    public void CardIint(CardClass card ) 
    {
        card_id = card.cardID;
        cardObject = card.Card_Ob;
    }
    private void OnMouseDown()
    {
       if (!cardManager.selcntIn)  return;

        Debug.Log("mouse");
        anim.Play("Open");

        cardManager.SendMessage("CardTime", new CardClass(card_id,gameObject));
    }
    public void Close() 
    {
        anim.Play("Close");
    }
     void Kill() 
    {
        Destroy(cardObject);
    }
    public void ColliderOn()
    {
        col.enabled = true;
    }

    public void ColliderOff()
    {
        col.enabled = false;
    }
}
