using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void buttonNewScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("FlappyMars");
    }
    public void buttonSwitchBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("FlappyBird");
    }
}
