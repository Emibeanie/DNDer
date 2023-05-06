using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    public AudioClip LobbyMusic;
    public AudioSource Source;

    public void Start()
    {
        Source.clip = LobbyMusic;
        Source.Play();
    }
    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("volume", volume);
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
