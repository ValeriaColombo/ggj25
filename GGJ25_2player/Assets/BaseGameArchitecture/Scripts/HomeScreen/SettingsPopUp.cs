using TMPro;
using UnityEngine;

public class SettingsPopUp : BasicPopup
{
    [SerializeField] private SoundSettings soundSettings;

    [SerializeField] private GameObject ENicon;
    [SerializeField] private GameObject ESicon;

    public override void Show()
    {
        base.Show();
        soundSettings.Show();
		
		ENicon.SetActive(MyLocalization.CurrentLang == "EN");
        ESicon.SetActive(MyLocalization.CurrentLang == "ES");
    }

    public override void Hide()
    {
        soundSettings.Hide();
        base.Hide();
    }

    public void OnLangButtonClick()
    {
        if (MyLocalization.CurrentLang == "EN")
            MyLocalization.SetLanguage("ES");
        else
            MyLocalization.SetLanguage("EN");

        ENicon.SetActive(MyLocalization.CurrentLang == "EN");
        ESicon.SetActive(MyLocalization.CurrentLang == "ES");
    }
}
