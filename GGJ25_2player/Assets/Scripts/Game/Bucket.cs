using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    [SerializeField] private Transform transformToFollow;

    private void Update()
    {
        transform.position = transformToFollow.position;
    }
}
