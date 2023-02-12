using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighlightText : MonoBehaviour
{
    public List<TextMeshProUGUI> list = new List<TextMeshProUGUI>();

    private int last;
    private void Start()
    {
        last = 0;
    }

    //highlight text from list based on index, sets color to black to last called text
    public void Highlight(int index)
    {

        list[last].color = Color.black;
        list[index].color = Color.red;
        
        last = index;
    }
}
