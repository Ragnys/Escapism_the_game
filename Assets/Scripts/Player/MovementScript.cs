using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    private float movementX;
    private float movementY;
    [SerializeField] private float speed = 1;
    private Rigidbody2D _rb;
    public Vector2 Looking;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void Update()
    {
        Vector2 movement = new Vector2(movementX, movementY);
        //transform.Translate(movement * speed * Time.deltaTime);
        _rb.MovePosition(_rb.position + movement * speed * Time.deltaTime);


        if(movement != new Vector2(0,0))
            Looking = movement;
    }

}
