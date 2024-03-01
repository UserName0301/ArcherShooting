using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GuiManager : Singleton<GuiManager>
{
    public GameObject HomeGui;
    public GameObject GameGui;
    public TMP_Text AppleCountingText;
    public GameOverDialog GameOverDialog;
    public GameObject SettingPanel;

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public void ShowGameGui(bool isShow)
    {
        if (GameGui)
            GameGui.SetActive(isShow);

        if(HomeGui) 
            HomeGui.SetActive(!isShow);
    }

    public void UpdateApple(int apples)
    {
        if(AppleCountingText)
            AppleCountingText.text = apples.ToString();
    }

    public void ShowSetting()
    {
        SettingPanel.SetActive(true);
    }

    public void CloseShowSetting()
    {
        SettingPanel.SetActive(false);
    }
}
