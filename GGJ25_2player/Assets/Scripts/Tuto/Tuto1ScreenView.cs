using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tuto1ScreenView : MonoBehaviour
{
    [SerializeField] private Chaboncito player1;
    [SerializeField] private Chaboncito player2;

    private void Start()
    {
        Context.Instance.Hello();

        player1.GameStarted = true;
        player2.GameStarted = true;
    }

    public void ContinueToGame()
    {
        SceneManager.LoadScene("Tuto2");
    }
}
