using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInput;

    public void NameValueChanged(string text)
    {
        if (text == string.Empty)
        {
            GameManager.Instance.playerName = "Guy Hero";
        }
        else
        {
            GameManager.Instance.playerName = text;
        }
        Debug.Log(GameManager.Instance.playerName);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        nameInput.onValueChanged.AddListener(NameValueChanged);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        GameManager.Instance.SaveGame();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
