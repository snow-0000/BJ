using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCount : MonoBehaviour
{
    public bool full;
    public bool animated;

    public int ownedCardCount;
    public int expectedCards;
    public int receivedCards;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider)
    {

        //checks if the colliding object is a card and adds it to the proper variable both the value and the number of cards

        if(collider.gameObject.tag == "Card")
        {
            int cardValue = collider.transform.parent.GetComponent<CardValue>().cardValue;

            if (receivedCards < expectedCards)
            {
                if(collider.transform.parent.GetComponent<CardValue>().isAce)
                {
                    receivedCards += 1;

                    if (ownedCardCount + cardValue > 21)
                    {                     
                        ownedCardCount += 1;
                    }
                    else
                    {
                        ownedCardCount += cardValue;
                    }
                }
                else
                {
                    receivedCards += 1;
                    ownedCardCount += cardValue;
                }
                

            }
        

        }
        
        
    }

    // Update is called once per frame
    void Awake()
    {
        expectedCards = 2;
    }
    void Update()
    {
        //check if the received cards are equal to the expected one s
        if(expectedCards == receivedCards)
        {
            full = true;
        }else
        {
            full = false;
        }

        //print burst if exceeding 21
        if (ownedCardCount > 21)
        {
            GetComponent<SetText>().text.SetText("Burst");

            //animate loss
            if (!animated)
            {
                animated = true;
                GetComponent<Animator>().SetBool("lose", true);

            }
            else
            {
                GetComponent<Animator>().SetBool("lose", false);
            }
        }
    }
}
