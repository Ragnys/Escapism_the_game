using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private Collider2D _collider;
    private Transform _child;
    private CarryItemScript _carryScript;

    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _child = transform.GetChild(0);
        _carryScript = GameObject.Find("Player").GetComponent<CarryItemScript>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _carryScript.PickUp(true, gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _carryScript.PickUp(false, null);
    }


    public void InteractedWith(bool carried)
    {
        _collider.enabled = carried;
        _child.gameObject.SetActive(carried);
    }

    private void End()
    {
        Destroy(gameObject);
    }
}
