using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoScreenView : MonoBehaviour
{
    public void ContinueToGame()
    {
        SceneManager.LoadScene("Game");
    }
}
