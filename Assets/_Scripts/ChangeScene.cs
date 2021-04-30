using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int sceneIndex;
    public void LoadScene(int sceneIndex)
    {
        Debug.Log("sceneName to load: " + sceneIndex);
        SceneManager.LoadScene(sceneIndex);
    }

}
