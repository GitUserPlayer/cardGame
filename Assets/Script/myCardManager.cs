using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myCardManager : MonoBehaviour
{
    private int[] CardId = new int[12];
    public GameObject[] CardOb;

    public Vector3 pos = new Vector3(-1.5f, 0f, 2.5f);

    public CardClass[] classes = new CardClass[2];

    int selcnt = 0;
    float timer = 0;
    int clearCount = 0;
    public bool selcntIn = true;

    public GameObject reset;
    
    void Start()
    {
        
        selcntIn = true;
        for (int i = 0;i<classes.Length ;i++) 
        {
            classes[i] = new CardClass(0,null);
        }
        CreateCard();
    }
    public void CardTime(CardClass cardClass)
    {
        classes[selcnt] = cardClass;
        selcnt++;
        if (selcnt > 1)
        {
            selcntIn = false;
            timer = 0;
        }
    }
   
    void Update()
    {
        if(selcntIn == false) 
        {
            timer += Time.deltaTime;
            if (timer>1) 
            {
                if (classes[0].cardID==classes[1].cardID) 
                {
                    classes[0].Card_Ob.SendMessage("Kill");
                    classes[1].Card_Ob.SendMessage("Kill");

                    Debug.Log("AAA");
                    clearCount += 2;
                    if (clearCount >= 12)
                    {
                        Debug.Log("Success");
                        reset.SetActive(true);
                        clearCount = 0;
                    }
                    
                }
                else
                {
                    for (int i = 0; i < classes.Length; i++)
                    {
                        classes[i].Card_Ob.SendMessage("Close");
                    }
                }
                selcnt = 0;
                selcntIn = true;
            }
        }
    }
    

    public void CreateCard() 
    {
        int num = 0;
        int ID = 0;
        for (int i = 0; i < CardId.Length / 2; i++)
        {
            CardId[num] = ID;
            num++;
            CardId[num] = ID;
            num++;
            ID++;
        }

        int count = 0;
        Shuffle.myShuffle(CardId);

        for (int i=0;i <3;i++) 
        {
            for (int j = 0;j<4 ;j++) 
            {
                GameObject obj = Instantiate(CardOb[CardId[count]],pos,Quaternion.identity);
                obj.SendMessage("CardIdOb", CardId[count]);
                pos += new Vector3(1, 0, 0);
                count++;
            }
            pos -= new Vector3(4f, 0, 1.3f);
        }
        pos = new Vector3(-1.5f, 0f, 2.5f);
        reset.SetActive(false);
    }
}
