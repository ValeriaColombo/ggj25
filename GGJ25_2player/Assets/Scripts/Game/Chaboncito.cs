using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chaboncito : MonoBehaviour
{
    [SerializeField] private bool isPlayerOne;
    [SerializeField] private GameObject explosion;
    [SerializeField] private Transform palito;
    [SerializeField] private Rigidbody2D palitoRB;
    [SerializeField] private float speed;
    [SerializeField] private float palitoThreshold;
    [SerializeField] private float palitoRotationPerFrame;
    [SerializeField] private float rotatesAloneIfGreaterThan = 0.5f;
    [SerializeField] private float palitoInerciaRotationPerFrame = 0.25f;
    [SerializeField] private Vector2 TopLeftLimit;
    [SerializeField] private Vector2 BottomRightLimit;

    private float acumHorSpeed = 0;
    private float palitoY;
    private bool ControlsEnabled = false;
    private Vector2 startPostion;

    public bool GameStarted;

    private void Start()
    {
        ControlsEnabled = true;
        explosion.SetActive(false);
        startPostion = transform.position;
        palitoY = palito.position.y - transform.position.y;
    }

    private void Update()
    {
        if(!GameStarted)
        {
            palito.position = new Vector3(transform.position.x, transform.position.y + palitoY, 0);
        }
        else if (ControlsEnabled)
        {
            float currentSpeed = Time.deltaTime * speed;

            if(UsesSuperPower())
            {
                explosion.SetActive(true);
            }

            if (IsMovingUp())
            {
                transform.Translate(0, currentSpeed, 0);
            }
            else if (IsMovingDown())
            {
                transform.Translate(0, -currentSpeed, 0);
            }

            if (IsMovingLeft())
            {
                acumHorSpeed -= currentSpeed;
                transform.Translate(-currentSpeed, 0, 0);
            }
            else if (IsMovingRight())
            {
                acumHorSpeed += currentSpeed;
                transform.Translate(currentSpeed, 0, 0);
            }
            else
            {
                acumHorSpeed = 0;
            }

            Vector2 newPos = transform.position;
            newPos.x = MathF.Min(MathF.Max(TopLeftLimit.x, newPos.x), BottomRightLimit.x);
            newPos.y = MathF.Min(MathF.Max(BottomRightLimit.y, newPos.y), TopLeftLimit.y);
            transform.position = newPos;

            palito.position = new Vector3(transform.position.x, transform.position.y + palitoY, 0);

            if (acumHorSpeed > palitoThreshold)
            {
                palito.Rotate(0, 0, -palitoRotationPerFrame, Space.Self);
            }
            else if (acumHorSpeed < -palitoThreshold)
            {
                palito.Rotate(0, 0, palitoRotationPerFrame, Space.Self);
            }
            else
            {
                if (palito.rotation.eulerAngles.z > 180 && palito.rotation.eulerAngles.z < 359)
                {
                    palito.Rotate(0, 0, -palitoInerciaRotationPerFrame, Space.Self);
                }
                if (palito.rotation.eulerAngles.z > 1 && palito.rotation.eulerAngles.z < 180)
                {
                    palito.Rotate(0, 0, palitoInerciaRotationPerFrame, Space.Self);
                }
            }
    
            if (Math.Abs(palito.rotation.z) > 0.5f)
            {
                DropPalito();
            }
        }
    }

    private void DropPalito()
    {
        palitoRB.velocity = Vector2.zero;
        StartCoroutine(FailAndRestart());
    }

    private IEnumerator FailAndRestart()
    {
        ControlsEnabled = false;
        yield return new WaitForSeconds(1);
        transform.position = startPostion;
        yield return new WaitForEndOfFrame();
        palitoRB.velocity = Vector2.zero;
        palito.rotation = Quaternion.identity;
        acumHorSpeed = 0;
        ControlsEnabled = true;
    }

    private bool UsesSuperPower()
    {
        if (isPlayerOne)
        {
            return Input.GetKeyDown(KeyCode.E);
        }
        else
        {
            return Input.GetKeyDown(KeyCode.RightShift);
        }
    }
    
    private bool IsMovingRight()
    {
        if (isPlayerOne)
        {
            return Input.GetKey(KeyCode.D);
        }
        else
        {
            return Input.GetKey(KeyCode.RightArrow);
        }
    }

    private bool IsMovingLeft()
    {
        if (isPlayerOne)
        {
            return Input.GetKey(KeyCode.A);
        }
        else
        {
            return Input.GetKey(KeyCode.LeftArrow);
        }
    }

    private bool IsMovingDown()
    {
        if (isPlayerOne)
        {
            return Input.GetKey(KeyCode.S);
        }
        else
        {
            return Input.GetKey(KeyCode.DownArrow);
        }
    }

    private bool IsMovingUp()
    {
        if (isPlayerOne)
        {
            return Input.GetKey(KeyCode.W);
        }
        else
        {
            return Input.GetKey(KeyCode.UpArrow);
        }
    }

    public void OnPlopBubble()
    {
        DropPalito();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("meta"))
        {
            Debug.Log("Winner P" + (isPlayerOne ? "1" : "2") + "!!!!!");
            if (isPlayerOne)
            {
                SceneManager.LoadScene("WinP1");
            }
            else
            {
                SceneManager.LoadScene("WinP2");
            }
        }
    }
}
