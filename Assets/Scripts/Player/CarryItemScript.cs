using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarryItemScript : MonoBehaviour
{
    [SerializeField] private GameObject _carriedItem;
    [SerializeField] private GameObject _item;
    [SerializeField] private Transform _itemSpot;
    private bool _canPickUp;
    private bool _carryingItem;
    private CameraScripts _cameraScript;
    private MovementScript _moveScript;

    private void Start()
    {
        _cameraScript = GameObject.Find("Camera").GetComponent<CameraScripts>();
        _moveScript = GetComponent<MovementScript>();
    }

    public void PickUp(bool item, GameObject itemObject)
    {
        _canPickUp = item;
        _item = itemObject;
    }

    void OnInteract()
    {
        if(_canPickUp && !_carryingItem)
        {
            _carriedItem = _item;
            _item.transform.position = _itemSpot.position;
            _item.gameObject.transform.parent = this.gameObject.transform;
            _item.SendMessage("InteractedWith", false);
            _carryingItem = true;
        }
        else if (_carryingItem)
        {
            _carriedItem.transform.localPosition = _moveScript.Looking;
            _carriedItem.transform.parent = _cameraScript.CameraPos[_cameraScript.CameraLocation].transform;
            _carriedItem.SendMessage("InteractedWith", true);
            _carryingItem = false;
            _carriedItem = null;
        }
    }
}
