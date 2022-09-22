using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] List<CinemachineVirtualCamera> cameras;
    CinemachineVirtualCamera currentCamera;
    public void Initialize()
    {
        currentCamera = cameras[0];
        setCamera(CameraStates.IngameCam);
    }

    public void StartGame()
    {

    }

    public void Reload()
    {
        setCamera(CameraStates.IngameCam);
    }

    public void GameSuccess()
    {

        setCamera(CameraStates.VictoryCam);
    }
    public void GameOver()
    {

    }

    public void setCamera(CameraStates camState)
    {
        currentCamera.Priority = 0;
        currentCamera = cameras[(int)camState];
        currentCamera.Priority = 99;
    }
}

public enum CameraStates : int
{
    IngameCam,
    VictoryCam
}