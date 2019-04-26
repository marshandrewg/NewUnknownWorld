using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizFunctions : MonoBehaviour
{
    public string SceneName;
    bool enter = false;
    public Animator anim;

    void Update(){
      if(enter && Input.GetKeyDown(KeyCode.UpArrow)){
        SceneManager.LoadScene(SceneName);
      }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.CompareTag("Player")){
        enter = true;
        anim.SetBool("open", false);
       }
    }

    void OnTriggerExit2D(Collider2D other)
    {
      if(other.CompareTag("Player")){
        enter = false;
        anim.SetBool("open", true);
      }
    }
}
