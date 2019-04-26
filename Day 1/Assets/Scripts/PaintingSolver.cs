using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PaintingSolver : MonoBehaviour
{

  string answer = "VENI VIDI VICI";
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
      hintText.text = "There is a word in each painting";
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
      if(guess.ToUpper() == answer){
        clone.GetComponent<MessageFunction>().ShowMessage("Correct");
        SceneManager.LoadScene("Day2");
      }
      else{
        clone.GetComponent<MessageFunction>().ShowMessage("Wrong");
        SceneManager.LoadScene("Puzzle2");
      }
    }
  }
}
