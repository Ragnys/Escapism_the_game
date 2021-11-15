using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuAndEndScript : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Animator _left;
    [SerializeField] private Animator _right;
    [SerializeField] private Text _startText;

    private void Start()
    {
        _startText.text = "Start";
        _startText.fontSize = 300;
    }


    void OnMenu()
    {
        _player.GetComponent<MovementScript>().enabled = false;
        _startText.text = "Continue";
        _startText.fontSize = 180;
        AnimTrigger(_left);
        AnimTrigger(_right);
    }

    void AnimTrigger(Animator anim)
    {
        anim.ResetTrigger("In");
        anim.SetTrigger("In");
    }
}
