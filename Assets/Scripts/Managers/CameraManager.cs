using System;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera[] _cameras;
    [SerializeField] private int _activeCamera;
    private static CameraManager _cameraManager;

    public static CameraManager Instance
    {
        get => _cameraManager;
        set => _cameraManager = value;
    }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        EnableCamera(_activeCamera);
    }

    private void EnableCamera(int cameraToEnable)
    {
        if (cameraToEnable < 0 || cameraToEnable >= _cameras.Length)
        {
            throw new System.Exception("Indice de camera a habilitar fuera de rango");
        }

        if (_cameras == null)
        {
            throw new System.Exception("No hay cameras");
        }

        for (int i = 0; i < _cameras.Length; i++)
        {
            _cameras[i].gameObject.SetActive(i == cameraToEnable);
        }

    }

    public void ChangeCamera()
    {
        _activeCamera++;
        //asegurarnos que no excede el tamanio
        _activeCamera %= _cameras.Length;
        EnableCamera(_activeCamera);
    }
}
