using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tuto2ScreenView : MonoBehaviour
{
    [SerializeField] private Chaboncito player1;
    [SerializeField] private Chaboncito player2;

    private void Start()
    {
        Application.targetFrameRate = 60;
        Context.Instance.Hello();

        player1.GameStarted = true;
        player2.GameStarted = true;
    }

    public void ContinueToGame()
    {
        SceneManager.LoadScene("Game");
    }
}
