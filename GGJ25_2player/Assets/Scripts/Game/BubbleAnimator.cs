using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleAnimator : MonoBehaviour
{
    [SerializeField] private Bubble bubble;

    public void PlopAnimEnd()
    {
        bubble.Respawn();
    }
}
