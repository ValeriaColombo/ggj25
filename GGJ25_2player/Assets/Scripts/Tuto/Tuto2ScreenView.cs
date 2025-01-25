using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tuto2ScreenView : MonoBehaviour
{
    public void ContinueToGame()
    {
        SceneManager.LoadScene("Game");
    }
}
