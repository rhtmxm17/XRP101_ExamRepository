using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotater : MonoBehaviour
{
    [SerializeField] float rotateSpeedMultiplier = 100f;

    private void Update()
    {
        transform.Rotate(GameManager.Intance.Score * Time.deltaTime * rotateSpeedMultiplier * Vector3.up);
    }
}
