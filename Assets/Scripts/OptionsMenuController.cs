using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionsMenuController : MonoBehaviour
{
    [SerializeField] private AudioMixer mainMixer;

    public void setBGVolume(float sliderValue)
    {
        float decibles =  Mathf.Log10(sliderValue) * 20;
        mainMixer.SetFloat("BGVolume", sliderValue);
    }  // end of setBGVolume

    public void setSFXVolume(float sliderValue)
    {
        float decibles =  Mathf.Log10(sliderValue) * 20;
        mainMixer.SetFloat("SFXVolume", sliderValue);
    }  // end of setSFXVolume

    public void setVoicesVolume(float sliderValue)
    {
        float decibles =  Mathf.Log10(sliderValue) * 20;
        mainMixer.SetFloat("VoicesVolume", sliderValue);
    }  // end of setVoicesVolume

    public void onReturnButtonClicked()
    {
        SceneManager.LoadScene("StartMenu");
    }  // end of onReturnButtonClicked

}
