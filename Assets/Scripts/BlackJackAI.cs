using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BlackJackAI : MonoBehaviour
{
    [Range(0.1f,0.5f)]
    public float courage;


    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<SetText>().text;
        courage = Random.Range(0.2f, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {



    }


    //Make a decision based on the variable courage and a random number
    public void MakeDecision()
    {
        if(transform.GetComponent<CardCount>().ownedCardCount <11)
        {
            Card();
        }
        else
        {
            if (transform.GetComponent<CardCount>().ownedCardCount > 17)
            {
                float value = Random.Range(0f, 1f);
                if (value < courage)
                {
                    Stop();
                }
                else
                {
                    Card();
                }
            }
            else
            {
                Stop();
            }
        }
      


    }

    void Stop()
    {
        text.SetText("Stay");
        Debug.Log("Stay");
    }
    void Card()
    {
        text.SetText("Stay");
        Debug.Log("Card");
        GetComponent<CardCount>().expectedCards += 1; GetComponent<CardCount>().full = false;
    }

}