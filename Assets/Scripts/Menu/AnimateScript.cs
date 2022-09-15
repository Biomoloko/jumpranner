using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnimateScript : MonoBehaviour
{
    public string nameScene = "Game";

    public void loadScene()
    {
        SceneManager.LoadScene(nameScene);
    }
}
