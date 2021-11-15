using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToCameraScript : MonoBehaviour
{
    [SerializeField] private int _nextLocation;

    private CameraScripts _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GameObject.Find("Camera").GetComponent<CameraScripts>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _camera.CameraLocation = _nextLocation;
    }
}
