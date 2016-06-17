using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static float volume = 1;
    public static float initialVolume;

    public Slider volSlider;
    public float volSliderValue = 0.0f;

    void Start()
    {
        initialVolume = volume;
    }

	public void ReduceVolume ()
    {
        volume = volSlider.value;
        initialVolume = volume;
        GetComponent<AudioSource>().volume = volume / 2;
        Debug.Log("Reducing Volume");
	}

    public void ResumeVolume ()
    {
        volume = volSlider.value;
        initialVolume = volume;
        GetComponent<AudioSource>().volume = initialVolume;
        Debug.Log("Resuming Volume");
    }

}
