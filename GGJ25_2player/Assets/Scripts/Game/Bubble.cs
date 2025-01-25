using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private float lastCollisionTime = -1;

    private void Awake()
    {
        Respawn();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("palito"))
        {
            animator.Play("bubble_plop");
            if(collision.name == "palito1")
                GameObject.Find("chaboncito1").GetComponent<Chaboncito>().OnPlopBubble();
            if (collision.name == "palito2")
                GameObject.Find("chaboncito2").GetComponent<Chaboncito>().OnPlopBubble();
        }
    }

    public void Respawn()
    {
        int rnd = Random.Range(1, 4);
        animator.Play("bubble_loop" + rnd);
    }
}
