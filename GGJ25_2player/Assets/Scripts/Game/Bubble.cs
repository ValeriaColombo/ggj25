using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private float lastCollisionTime = -1;

    private void Awake()
    {
        int rnd = Random.Range(1, 4);
        animator.Play("bubble_loop"+rnd);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.enabled = false;
        lastCollisionTime = Time.time;
    }

    private void Update()
    {
        if (!animator.enabled)
        {
            if(Time.time - lastCollisionTime > 0.2f)
                animator.enabled = true;
        }
    }
}
