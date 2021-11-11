using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class ManageMenuScrub : ScriptableObject
{
    public void CheckButton(string message)
    {
        Debug.Log(message);
    }

    public void OutOfTheWay(Animator animator)
    {
        animator.ResetTrigger("Out");
        animator.SetTrigger("Out");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
