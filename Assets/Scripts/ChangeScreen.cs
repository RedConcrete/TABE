using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreen : MonoBehaviour
{
    public void swichtScreen(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
