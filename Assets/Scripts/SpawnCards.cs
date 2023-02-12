using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCards : MonoBehaviour
{
    public AudioManager audioManager;

    //bool needed for different stages and modes
    public bool active;
    public bool random;
    public bool giveCards;
    //spawned cards
    public List<int> usedCards = new List<int>();
    //where to spawn cards relative to main camera
    public Vector3 throwingPos;
    public Vector3 holdingPos;
    //parent of spawned Cards
    public Transform parent;
    public DealerCards dealerCard;

    //offset when holding cards
    public float offset;

    //index when not shuffling
    public int count;


    private void Start()
    {
        offset = -0.02f;
        count = 0;    
    }


    private void OnMouseDown()
    {

       
        
            //if mechanics is active
            if (active)
            {

                var resources = Resources.LoadAll("");
                //spawn a card that has either to be thrown or held by the dealer, from a shuffled set or not
                if (giveCards)
                {
                    if (random)
                    {
                    //istantiate gameobject and add components and positional values
                        int index = ReturnRandomCard();

                        GameObject instance = Instantiate(Resources.Load(resources[index].name) as GameObject);
                        instance.transform.SetParent(parent);

                        instance.transform.position = new Vector3(transform.position.x, transform.position.y +0.05f, transform.position.z);
                        instance.transform.eulerAngles = Vector3.zero;

                        instance.AddComponent<SlideCard>();
                        instance.AddComponent<MoveAndDestroy>().target = transform;
                    

                    }
                    else
                    {
                    //istantiate gameobject and add components and positional values
                        GameObject instance = Instantiate(Resources.Load(resources[count].name) as GameObject);
                        instance.transform.SetParent(parent);

                        instance.transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
                        instance.transform.eulerAngles = Vector3.zero;

                        instance.AddComponent<SlideCard>();
                        instance.AddComponent<MoveAndDestroy>().target = transform;

                        count += 1;
                    }
                }
                else
                {
                    if (random)
                    {

                    //istantiate gameobject and add components and positional values
                        int index = ReturnRandomCard();

                        GameObject instance = Instantiate(Resources.Load(resources[index].name) as GameObject);
                        instance.transform.SetParent(parent);

                        instance.AddComponent<MoveAndDestroy>().target = transform;

                        instance.transform.position = new Vector3(-0.2f + offset, 0.75f - (offset/100), 0.15f);

                        //ADD CARD TO DEALER CARD LIST CHECK IF ITS AN ACE
                        int dealerCardCount = 0;
                        for (int i = 0; i < dealerCard.cardValues.Count; i++)
                        {
                            dealerCardCount += dealerCard.cardValues[i];
                        }

                        if (dealerCardCount > 10)
                        {
                            if (instance.GetComponent<CardValue>().isAce)
                            {
                                dealerCard.cardValues.Add(1);
                            }
                            else
                            {
                                dealerCard.cardValues.Add(instance.GetComponent<CardValue>().cardValue);
                            }


                        }
                        else
                        {
                            dealerCard.cardValues.Add(instance.GetComponent<CardValue>().cardValue);
                        }

                        offset -= 0.03f;
                    }
                    else
                    {
                    //istantiate gameobject and add components and positional values
                        GameObject instance = Instantiate(Resources.Load(resources[count].name) as GameObject);
                        instance.transform.SetParent(parent);

                        instance.AddComponent<MoveAndDestroy>().target = transform;

                        instance.transform.position = new Vector3(-0.2f + offset, 0.75f - (offset / 100), 0.15f);

                         //ADD CARD TO DEALER CARD LIST CHECK IF ITS AN ACE
                        int dealerCardCount = 0;
                        for (int i = 0; i < dealerCard.cardValues.Count; i++)
                        {
                            dealerCardCount += dealerCard.cardValues[i];
                        }

                        if (dealerCardCount > 10)
                        {
                            if (instance.GetComponent<CardValue>().isAce)
                            {
                                dealerCard.cardValues.Add(1);
                            }
                            else
                            {
                                dealerCard.cardValues.Add(instance.GetComponent<CardValue>().cardValue);
                            }


                        }
                        else
                        {
                            dealerCard.cardValues.Add(instance.GetComponent<CardValue>().cardValue);
                        }


                        offset -= 0.03f;
                        count += 1;
                    }
                }
            
        }
       

    }

    //checks if cards already exists and return index of a non existing one
    private int ReturnRandomCard()
    {
        var resources = Resources.LoadAll("");
        
        bool different = false;
        int index = 0;

        while (!different)
        {
            index = Random.Range(0, resources.Length - 1);
            different = true;

            for (int i = 0; i < usedCards.Count; i++)
            {
                if (index == usedCards[i])
                {
                    different = false;
                }
            }
        }




        return index;
    }


    //set the random bool on for a shuffled card set
    public void Shuffle()
    {
        audioManager.PlaySound(0);
        random = true;
    }
    

}
