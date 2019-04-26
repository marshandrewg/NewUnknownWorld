using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuseumFunctions : MonoBehaviour
{

  [SerializeField] Transform paintingParentPanel;
  [SerializeField] GameObject paintingPrefab;
  Sprite paint = null;
  public static bool showing = false;

  public void SetPainting(Sprite painting)
  {
    this.paint = painting;
  }

  public void ShowPainting()
  {
    if(paint && !showing){
      GameObject clone = (GameObject) Instantiate(paintingPrefab);
      clone.transform.SetParent(paintingParentPanel);
      clone.transform.SetAsLastSibling();
      clone.GetComponent<PaintingFunction>().ShowImage(paint);
      showing = true;
    }
  }
}
