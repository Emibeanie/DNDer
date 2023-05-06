using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer masterMixer;
    [SerializeField] Slider VolSlider;
    public void SetVolume(float volume)
    {
        masterMixer.SetFloat("volume", VolSlider.value);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void BackToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
