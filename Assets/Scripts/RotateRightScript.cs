using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRightScript : MonoBehaviour
{
    [SerializeField] private GameObject[] _rooms = new GameObject[8];
    [SerializeField] private Vector3[] _roomPosition = new Vector3[8];
    private int j;
    public int number = 1;
    public int N;
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
        N = 0 + number;
        j = N;

        for (int i = 0; i < _rooms.Length; i++)
        {
            if (j == 8)
                j = 0;
            _rooms[i].transform.localPosition = _roomPosition[j];
            j++;
        }

        number++;
        if (number == 8)
            number = 0;
    }
}
