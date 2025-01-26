using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenPresenter : ClassWithContext
{
    private HomeScreenView view;

    public HomeScreenPresenter(HomeScreenView view)
    {
        Context.Instance.Hello();
        this.view = view;
        MySoundManager.PlayMusicLoop("Sound/musicMenu");
    }

    public void GoToPlayGame(string gameId)
    {
        switch (gameId)
        {
            case "game":
                SceneManager.LoadScene("Tuto1");
                break;
        }
    }
}
