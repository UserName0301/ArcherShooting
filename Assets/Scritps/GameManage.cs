using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : Singleton<GameManage>
{
    public enum GameState
    {
        Starting,
        Playing,
        Gameover
    }

    public GameState State;
    public TargetController TargetPb;
    int _score;

    public int Score { get => _score;
        set
        {
            _score = value;
            if(_score >PlayerPrefs.GetInt("BestScore",0))
                PlayerPrefs.SetInt("BestScore",_score);
        }
    }

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public override void Start()
    {
        base.Start();

        State = GameState.Starting;

        GuiManager.Ins.ShowGameGui(false);

        GuiManager.Ins.UpdateApple(Score);

        AudioController.Ins.PlayMusic(AudioController.Ins.backgroundMusics);
    }

    IEnumerator SpawnTargetCo()
    {
        float xPos = Random.Range(0f, 8f);
        float yPos = Random.Range(-2f, 4f);

        yield return new WaitForSeconds(0.3f);

        if (TargetPb)
        {
            Instantiate(TargetPb, new Vector3(xPos,yPos,0),Quaternion.identity);
        }
    }

    public void SpawnTarget()
    {
        if (State == GameState.Gameover) return;

        StartCoroutine(SpawnTargetCo());
    }

    public void PlayGame()
    {
        AudioController.Ins.PlaySound(AudioController.Ins.soundButton);
        State = GameState.Playing;
        GuiManager.Ins.ShowGameGui(true);
        SpawnTarget();
    }

    public void GameOver()
    {
        if (GuiManager.Ins.GameOverDialog)
            GuiManager.Ins.GameOverDialog.Show(true);
    }
}
