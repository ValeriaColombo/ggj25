using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviourWithContext
{
    [SerializeField] private Chaboncito player1;
    [SerializeField] private Chaboncito player2;

    public UnityEvent<int> OnFinishGame { get; private set; }

    private void Awake()
    {        
        OnFinishGame = new UnityEvent<int>();
        MySoundManager.PlayMusicLoop("Sound/musicGame");
    }

    private void Start()
    {
        player1.GameStarted = false;
        player2.GameStarted = false;
    }

    public void StartGame() //Se llama al finalizar la animacion del 3,2,1
    {
        player1.GameStarted = true;
        player2.GameStarted = true;
    }
}
