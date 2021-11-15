using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarryItemScript : MonoBehaviour
{
    [SerializeField] private GameObject _carriedItem;
    [SerializeField] private GameObject _item;
    [SerializeField] private Transform _itemSpot;
    public bool _canPickUp;
    private bool _carryingItem;
    private CameraScripts _cameraScript;
    private MovementScript _moveScript;
    [HideInInspector] public bool UnlockedDoor;
    [HideInInspector] public GameObject Door;

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

    public void SetDoor(GameObject door)
    {
        Door = door;
    }

    void OnInteract()
    {
        if(_canPickUp && !_carryingItem)
        {
            _carriedItem = _item;
            _carriedItem.transform.position = _itemSpot.position;
            _carriedItem.gameObject.transform.parent = this.gameObject.transform;
            _carriedItem.SendMessage("InteractedWith", false);
            _carryingItem = true;
            _canPickUp = false;
        }
        else if (UnlockedDoor)
        {
            AnimTrigger(_carriedItem);
            AnimTrigger(Door);
        }
        else if (_carryingItem && !_canPickUp)
        {
            _carriedItem.transform.localPosition = _moveScript.Looking;
            _carriedItem.transform.parent = _cameraScript.CameraPos[_cameraScript.CameraLocation].transform;
            _carriedItem.SendMessage("InteractedWith", true);
            _carryingItem = false;
            _carriedItem = null;
            _canPickUp = false;
        }
    }

    void AnimTrigger(GameObject item)
    {
        item.GetComponent<Animator>().ResetTrigger("Unlocked");
        item.GetComponent<Animator>().SetTrigger("Unlocked");
    }
}
