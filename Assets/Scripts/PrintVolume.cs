using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PrintVolume : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //prints volume in percentage
        GetComponent<TextMeshProUGUI>().SetText(((Mathf.Round(slider.value * 100f) / 100f)*100).ToString() + "%");
    }
}
