using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLeftScript : MonoBehaviour
{
    [SerializeField] private GameObject[] _rooms = new GameObject[8];
    [SerializeField] private Vector3[] _roomPosition = new Vector3[8];
    private int j;
    [SerializeField] private RotateRightScript Right;
    void Start()
    {
        
        j = 0;

        for (int i = 0; i < _rooms.Length; i++)
        {
            _rooms[i].transform.localPosition = _roomPosition[i];
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        j = Right.N - 1;
        if (j == -1)
            j = 7;

        for (int i = 0; i < _rooms.Length; i++)
        {
            if (j == 8)
                j = 0;
            _rooms[i].transform.localPosition = _roomPosition[j];
            j++;
        }

        Right.number--;
        if (Right.number == -1)
            Right.number = 7;
        Right.N--;
        if (Right.N == -1)
            Right.N = 7;
    }
}
