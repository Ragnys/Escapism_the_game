using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoorScript : MonoBehaviour
{
    [SerializeField] private GameObject _key;
    private CarryItemScript _carryScript;

    private void Start()
    {
        _carryScript = GameObject.Find("Player").GetComponent<CarryItemScript>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _carryScript.SetDoor(gameObject);
        _carryScript.UnlockedDoor = true;
    }

    void End()
    {
        Destroy(gameObject);
    }
}
