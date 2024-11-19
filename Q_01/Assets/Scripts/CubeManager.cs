using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private CubeController _cubeController;
    private Vector3 _cubeSetPoint;

    private void Start()
    {
        CreateCube();
        SetCubePosition(3, 0, 3);
    }

    private void SetCubePosition(float x, float y, float z)
    {
        if (_cubeController == null)
        {
            Debug.Log("CubeController가 등록되지 않음");
            return;
        }
        _cubeSetPoint.x = x;
        _cubeSetPoint.y = y;
        _cubeSetPoint.z = z;
        _cubeController.SetPoint = _cubeSetPoint;
        _cubeController.SetPosition();
    }

    private void CreateCube()
    {
        GameObject cube = Instantiate(_cubePrefab);
        _cubeController = cube.GetComponent<CubeController>();
        _cubeSetPoint = _cubeController.SetPoint;
    }
}
