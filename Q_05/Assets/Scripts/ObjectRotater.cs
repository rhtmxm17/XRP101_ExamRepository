using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotater : MonoBehaviour
{
    [SerializeField] float rotateSpeedMultiplier = 100f;

    private void Update()
    {
        // 회전 속도가 deltaTime의 영향을 받게(timescale의 영향을 받게) 수정
        transform.Rotate(GameManager.Intance.Score * Time.deltaTime * rotateSpeedMultiplier * Vector3.up);
    }
}
