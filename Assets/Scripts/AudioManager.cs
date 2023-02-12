using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    //list of sounds and volume slider
    public bool playOnAwake;
    public List<AudioClip> sounds = new List<AudioClip>();
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        //playe first sound of the list and loop 
        if (playOnAwake)
        {
            GetComponent<AudioSource>().clip = sounds[0];
            GetComponent<AudioSource>().loop = true;
            GetComponent<AudioSource>().Play();
        }
    }

   
    void Update()
    {
        //modify volume
        GetComponent<AudioSource>().volume = slider.value;
    }

    //this function plays a sound based on its index
    public void PlaySound(int index)
    {
        GetComponent<AudioSource>().clip = sounds[index];
        GetComponent<AudioSource>().loop = false;
        GetComponent<AudioSource>().Play();
    }
}
