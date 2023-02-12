using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public bool playOnAwake;
    public List<AudioClip> sounds = new List<AudioClip>();
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        if (playOnAwake)
        {
            GetComponent<AudioSource>().clip = sounds[0];
            GetComponent<AudioSource>().loop = true;
            GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<AudioSource>().volume = slider.value;
    }
    public void PlaySound(int index)
    {
        GetComponent<AudioSource>().clip = sounds[index];
        GetComponent<AudioSource>().loop = false;
        GetComponent<AudioSource>().Play();
    }
}
