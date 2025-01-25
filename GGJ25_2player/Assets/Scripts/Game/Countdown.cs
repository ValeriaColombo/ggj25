using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] private Game game;

    public void FinishCountdown()
    {
        game.StartGame();
        gameObject.SetActive(false);
    }
}
