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
    public void Highlight(int index)
    {
        list[index].color = Color.red;
        list[last].color = Color.black;
        last = index;
    }
}
