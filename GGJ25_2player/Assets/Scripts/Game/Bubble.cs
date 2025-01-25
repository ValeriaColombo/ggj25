using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private float lastCollisionTime = -1;
    private Vector3 originalPosition;

    private void Awake()
    {
        originalPosition = transform.localPosition;
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
            if (Time.time - lastCollisionTime > 0.2f)
            {
                animator.enabled = true;
                StartCoroutine(ComeBackToOriginalPosition());
            }
        }
    }

    private IEnumerator ComeBackToOriginalPosition()
    {
        var speed = 0.025f;
        Vector3 currentPosition = transform.localPosition;
        while (transform.localPosition != originalPosition)
        {
            if (Mathf.Abs(currentPosition.x - originalPosition.x) < speed)
            {
                currentPosition.x = originalPosition.x;
            }
            else if (currentPosition.x > originalPosition.x)
            {
                currentPosition.x -= speed * Time.fixedDeltaTime;
            }
            else if (currentPosition.x < originalPosition.x)
            {
                currentPosition.x += speed * Time.fixedDeltaTime;
            }

            if (Mathf.Abs(currentPosition.y - originalPosition.y) < speed)
            {
                currentPosition.y = originalPosition.y;
            }
            else if (currentPosition.y > originalPosition.y)
            {
                currentPosition.y -= speed * Time.fixedDeltaTime;
            }
            else if (currentPosition.y < originalPosition.y)
            {
                currentPosition.y += speed * Time.fixedDeltaTime;
            }

            transform.localPosition = currentPosition;

            yield return new WaitForEndOfFrame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("palito"))
        {
            StopAllCoroutines();
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
