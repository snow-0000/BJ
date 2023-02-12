using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrintCardCount : MonoBehaviour
{

    public TextMeshProUGUI text;


    // Update is called once per frame
    void Update()
    {
        int score = GetComponent<CardCount>().ownedCardCount;
        if (score > 0 & score < 22)
        {
            text.SetText(score.ToString());
        }
        else
        {
            text.SetText("");
        }
        
    }
}
