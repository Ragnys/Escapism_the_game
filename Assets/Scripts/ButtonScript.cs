using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _door;
    private CarryItemScript _carryScript;

    private void Start()
    {
        _carryScript = GameObject.Find("Player").GetComponent<CarryItemScript>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(_key.tag))
        {
            _key.GetComponent<ItemScript>().InteractedWith(false);
            _key.GetComponent<ItemScript>().enabled = false;
            _key.transform.parent = gameObject.transform;
            _key.transform.localPosition = new Vector3(0, 0, 0);
            Destroy(_door);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _carryScript.PickUp(false, null);
        _carryScript._canPickUp = false;
    }
}
