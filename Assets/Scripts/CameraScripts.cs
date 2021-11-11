using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScripts : MonoBehaviour
{
    public GameObject[] CameraPos = new GameObject[9];
    public int CameraLocation;
    private int _lastLocation;

    private void Start()
    {
        CameraLocation = 0;
        _lastLocation = 0;
        transform.position = new Vector3(CameraPos[0].transform.localPosition.x, CameraPos[0].transform.localPosition.y, -10);
    }

    void Update()
    {
        if(CameraLocation != _lastLocation)
        {
            CameraCheck(CameraLocation);
            _lastLocation = CameraLocation;
        }
    }

    void CameraCheck(int number)
    {
        if(CameraLocation == number)
        {
            transform.position = new Vector3(CameraPos[number].transform.localPosition.x, CameraPos[number].transform.localPosition.y, -10);
        }
    }
}
