using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatBoxFunctions : MonoBehaviour
{
  [SerializeField] ContentSizeFitter fitter;
  bool showing = false;
  [SerializeField] Text showButtonText;
  string message = "";
  [SerializeField] Transform messageParentPanel;
  [SerializeField] GameObject messagePrefab;

  void Start()
  {
    ToggleChat();
  }

  public void ToggleChat()
  {
    showing = !showing;
    if(showing){
      fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
      showButtonText.text = "Hide Chat";
    } else{
      fitter.verticalFit = ContentSizeFitter.FitMode.MinSize;
      showButtonText.text = "Show Chat";
    }
  }

  public void SetMessage( string message)
  {
    this.message = message;
  }

  public void ShowMessage()
  {
    if(message != ""){
      GameObject clone = (GameObject) Instantiate(messagePrefab);
      clone.transform.SetParent(messageParentPanel);
      clone.transform.SetSiblingIndex(messageParentPanel.childCount - 2);
      clone.GetComponent<MessageFunction>().ShowMessage(message);
    }
  }
}
