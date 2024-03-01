using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverDialog : Dialog
{
    public TMP_Text BestScoreText;

    public override void Show(bool isShow)
    {
        base.Show(isShow);

        if(BestScoreText != null)
        {
            BestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
        }

        AudioController.Ins.PlaySound(AudioController.Ins.gameover);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioController.Ins.PlaySound(AudioController.Ins.soundButton);
    }

    public void Quit()
    {
        Application.Quit();
        AudioController.Ins.PlaySound(AudioController.Ins.soundButton);
    }
}
