using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{

    public List<GameObject> activePlayers = new List<GameObject>();

    public SpawnCards spawner;
    public GameObject runtimeCanvas;

    public bool firstStage;
    public bool secondStage;
    public bool thirdStage;
    public bool fourthStage;
    public bool fifthStage;


    // Start is called before the first frame update
    void Start()
    {
        firstStage = true;
    }

    // Update is called once per frame
    void Update()
    {

        //for each stage stands a function
        if (firstStage)
        {
            FirstCardDistribution();
        }
        if (secondStage)
        {
            CallForDecisions();
            
        }
        if (thirdStage)
        {
            SecondCardDistribution();
        }
        if (fourthStage)
        {

            DealerCards();
        }
        if (fifthStage)
        {
            DealerDecision();
        }
    }


    //this function compares the scores of the player and the dealer
    //ans triggers reactions or text for each specific case win lose or draw
    public void Compare()
    {
        //Set canvas button
        runtimeCanvas.transform.GetChild(3).gameObject.SetActive(true);
        
        //get the dealer total score
        int dealerScore = 0;
        

        for (int i = 0; i < GetComponent<DealerCards>().cardValues.Count; i++)
        {
            dealerScore += GetComponent<DealerCards>().cardValues[i];
        }

        if (dealerScore > 21)
        {
            // if dealer bursts everyone mocks the dealer by cheering 

            runtimeCanvas.transform.GetChild(4).GetComponent<TextMeshProUGUI>().SetText("Dealer Bursts");
            for (int i = 0; i < activePlayers.Count; i++)
            {
                activePlayers[i].GetComponent<Animator>().SetBool("win", true);
               
            }
        }
        else
        {
            //check score for each player 
            for (int i = 0; i < activePlayers.Count; i++)
            {
                if (activePlayers[i].GetComponent<CardCount>().ownedCardCount <= 21)
                {
                    int playerCardCount = activePlayers[i].GetComponent<CardCount>().ownedCardCount;
                    //lose
                    if (playerCardCount < dealerScore)
                    {
                        activePlayers[i].GetComponent<SetText>().text.SetText("Lose");
                        activePlayers[i].GetComponent<Animator>().SetBool("lose", true);
                    }
                    //draw
                    if (playerCardCount == dealerScore)
                    {
                        activePlayers[i].GetComponent<SetText>().text.SetText("Draw");
                    }
                    //Win
                    if (playerCardCount > dealerScore)
                    {
                        activePlayers[i].GetComponent<Animator>().SetBool("win", true);
                       
                        if (playerCardCount == 21)
                        {
                            activePlayers[i].GetComponent<SetText>().text.SetText("BlackJack");
                        }
                        else
                        {
                            activePlayers[i].GetComponent<SetText>().text.SetText("Win");
                            
                        }
                        
                    }
                }


            }
        }

      
    }





    //this function manages UI for the first set of cards
    void FirstCardDistribution()
    {
        //Set Canvas buttons
        runtimeCanvas.transform.GetChild(2).gameObject.SetActive(false);
        runtimeCanvas.transform.GetChild(3).gameObject.SetActive(false);
   

        //Check who is the first in line to miss cards
        spawner.giveCards = true;
        for (int i = 0; i < activePlayers.Count; i++)
        {
            if (activePlayers[i].GetComponent<CardCount>().full)
            {
                activePlayers[i].GetComponent<SetText>().text.SetText("");

            }
            if (!activePlayers[i].GetComponent<CardCount>().full)
            {
                activePlayers[i].GetComponent<SetText>().text.SetText("Card");
                
            }
        }


        //Check if everyone has starting cards
        int count = 0;
        for (int i = 0; i < activePlayers.Count; i++)
        {
            if (activePlayers[i].GetComponent<CardCount>().full)
            {
                count += 1;

            }
        }
        if (count == activePlayers.Count)
        {
            firstStage = false;
            secondStage = true;
        }
    }
    void DealerCards()
    {

        //allow dealer to get his cards
        spawner.giveCards = false;
        if (GetComponent<DealerCards>().cardValues.Count == 2)
        {
            fourthStage = false;
            fifthStage = true;
        }

    }
    void CallForDecisions()
    {
        //Make Players decide to hit or stay
        for (int i = 0; i < activePlayers.Count; i++)
        {
            activePlayers[i].GetComponent<BlackJackAI>().MakeDecision();
        }
        thirdStage = true;
        secondStage = false;
    }

    void SecondCardDistribution()
    {
        //Check who is the first in line to miss cards
        spawner.giveCards = true;
        for (int i = 0; i < activePlayers.Count; i++)
        {
            if (!activePlayers[i].GetComponent<CardCount>().full)
            {
                activePlayers[i].GetComponent<SetText>().text.SetText("Card");
                
            }
            else
            {
                if(activePlayers[i].GetComponent<SetText>().text.text != "Burst")
                {
                    activePlayers[i].GetComponent<SetText>().text.SetText("Stay");
                }
            }
        }
        //Check if everyone has their cards
        int count = 0;
        for (int i = 0; i < activePlayers.Count; i++)
        {
            if (activePlayers[i].GetComponent<CardCount>().full)
            {
                count += 1;

            }
        }
        if (count == activePlayers.Count)
        {
            fourthStage = true;
            thirdStage = false;
        }
    }

    //Allow dealer to pick more cards
    private void DealerDecision()
    {
        //Set Canvas button
        runtimeCanvas.transform.GetChild(2).gameObject.SetActive(true);


        spawner.giveCards = false;

        int cardCount = 0;
        for (int i = 0; i < GetComponent<DealerCards>().cardValues.Count; i++)
        {
            cardCount += GetComponent<DealerCards>().cardValues[i];
        }

        if (cardCount > 21)
        {
            Compare();
        }

    }
    public void Collect()
    {
        //enables first stage
        fifthStage = false;
        firstStage = true;

        //clear cards on the table
        spawner.usedCards.Clear();
        for (int i = 0; i < spawner.parent.childCount; i++)
        {
            Object.Destroy(spawner.parent.GetChild(i).gameObject);
        }


        //Resets player card count values and canvas text
        for (int i = 0; i < activePlayers.Count; i++)
        {
            activePlayers[i].GetComponent<SetText>().text.SetText("");
            activePlayers[i].GetComponent<CardCount>().ownedCardCount = 0;
            activePlayers[i].GetComponent<CardCount>().expectedCards = 2;
            activePlayers[i].GetComponent<CardCount>().receivedCards = 0;
            activePlayers[i].GetComponent<CardCount>().full = false;
            activePlayers[i].GetComponent<CardCount>().animated = false;

        }
        //reset dealer cards
        GetComponent<DealerCards>().cardValues.Clear();

        //reset canvas 
        runtimeCanvas.transform.GetChild(4).GetComponent<TextMeshProUGUI>().SetText("");

        //reset offsets
        spawner.offset = -0.02f;
    }
}
