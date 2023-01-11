using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : SingletonMonobehaviour<CamManager>
{
    [SerializeField] private CinemachineVirtualCamera followCam;
    [SerializeField] private CinemachineVirtualCamera endPointCam;
    [SerializeField] private CinemachineBrain current;


    public void CamChange()
    {
        followCam.gameObject.SetActive(!followCam.gameObject.activeSelf);
        endPointCam.gameObject.SetActive(!endPointCam.gameObject.activeSelf);
    }

}
