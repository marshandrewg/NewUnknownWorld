using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScreen : MonoBehaviour
{

    public string sceneName;

    public void clickNext()
    {
        SceneManager.LoadScene(sceneName);
    }

}
