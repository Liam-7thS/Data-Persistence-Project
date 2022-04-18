using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif


// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuManager : MonoBehaviour
{
    public Image startImage;
    public TMP_InputField Inputname;


    public void EnableStart()
    {
        startImage.gameObject.SetActive(true);
    }
    public void DisableStart()
    {
        startImage.gameObject.SetActive(false);
    }

    public void StartNew()
    {
        GameManager.Instance.playerName = Inputname.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    { 
#if UNITY_EDITOR
    EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }

    private void Start()
    {
               
    }

}