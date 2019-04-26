using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CaesarDisplayFunction : MonoBehaviour
{
  string answer = "i have your friend at the museum";
  string guess = "";
  bool showing = false;
  bool guessed = false;
  [SerializeField] Transform messageParentPanel;
  [SerializeField] GameObject messagePrefab;
  [SerializeField] Text hintText;

  public void setGuess(string guess)
  {
    this.guess = guess;
  }

  public void showHint()
  {
    showing = !showing;
    if(showing){
      hintText.text = "It's a simple Caesar shift of four";
    } else{
      hintText.text = "";
    }
  }

  public void ShowMessage()
  {
    if(guess != ""){
      GameObject clone = (GameObject) Instantiate(messagePrefab);
      clone.transform.SetParent(messageParentPanel);
      clone.transform.SetSiblingIndex(messageParentPanel.childCount - 2);
      if(guess.ToLower() == answer){
        clone.GetComponent<MessageFunction>().ShowMessage("Correct");
        SceneManager.LoadScene("Day1");
      }
      else{
        clone.GetComponent<MessageFunction>().ShowMessage("Wrong");
      }
    }
  }
}
