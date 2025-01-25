using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaboncito : MonoBehaviour
{
    [SerializeField] private Transform palito;
    [SerializeField] private float speed;
    [SerializeField] private float palitoThreshold;
    [SerializeField] private float palitoRotationPerFrame;
    [SerializeField] private float rotatesAloneIfGreaterThan = 0.5f;
    [SerializeField] private float palitoInerciaRotationPerFrame = 0.25f;

    public float acumHorSpeed = 0;

    private float palitoY;

    private void Start()
    {
        palitoY = palito.position.y - transform.position.y;
    }

    private void Update()
    {
        float currentSpeed = Time.deltaTime * speed;

        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, currentSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -currentSpeed, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            acumHorSpeed -= currentSpeed;
            transform.Translate(-currentSpeed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            acumHorSpeed += currentSpeed;
            transform.Translate(currentSpeed, 0, 0);
        }
        else
        {
            acumHorSpeed = 0;
        }

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
            if(palito.rotation.eulerAngles.z > 180 && palito.rotation.eulerAngles.z < 359)
            {
                palito.Rotate(0, 0, -palitoInerciaRotationPerFrame, Space.Self);
            }
            if (palito.rotation.eulerAngles.z > 1 && palito.rotation.eulerAngles.z < 180)
            {
                palito.Rotate(0, 0, palitoInerciaRotationPerFrame, Space.Self);
            }
        }
    }
}
