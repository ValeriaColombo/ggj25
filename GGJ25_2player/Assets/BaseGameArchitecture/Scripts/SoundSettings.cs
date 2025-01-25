using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviourWithContext
{
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SFXSlider;

    public void Show()
    {
        MusicSlider.value = MySoundManager.MusicVolume;
        SFXSlider.value = MySoundManager.SFXVolume;

        MusicSlider.onValueChanged.AddListener(OnMusicSliderValueChange);
        SFXSlider.onValueChanged.AddListener(OnSFXSliderValueChange);
    }

    public void Hide()
    {
        MusicSlider.onValueChanged.RemoveAllListeners();
        SFXSlider.onValueChanged.RemoveAllListeners();
    }

    private void OnMusicSliderValueChange(float newValue)
    {
        MySoundManager.ChangeMusicVolume(MusicSlider.value);
    }

    private void OnSFXSliderValueChange(float newValue)
    {
        MySoundManager.ChangeSFXVolume(SFXSlider.value);
    }
}
