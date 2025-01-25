using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    public UnityEvent<int> OnFinishGame { get; private set; }

    private void Start()
    {
        OnFinishGame = new UnityEvent<int>();
    }
}
