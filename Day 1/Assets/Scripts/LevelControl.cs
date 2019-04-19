using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{


  public string RestartSceneName;
  public string EndSceneName;

    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.CompareTag("Player")){
        SceneManager.LoadScene(EndSceneName);
      }
    }

    void Update(){
      if(gameObject.transform.position.y < -7){
        SceneManager.LoadScene(RestartSceneName);
      }
    }
}
