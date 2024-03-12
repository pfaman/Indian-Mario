using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{

    public Slider volumeSlider;
    public AudioMixer mixer;
    private float value;


    private void Start()
    {
        Time.timeScale = 1;
        mixer.GetFloat("Volume", out value);
        volumeSlider.value = value;
    }
    public void SetVolume()
    {
        Debug.Log("SetVolume");
        mixer.SetFloat("Volume", volumeSlider.value);

    }
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
