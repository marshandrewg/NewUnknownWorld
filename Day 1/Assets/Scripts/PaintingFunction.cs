using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintingFunction : MonoBehaviour
{

  [SerializeField] Image image;

  public void ShowImage(Sprite painting)
  {
      image.sprite = painting;
  }

  public void HideImage()
  {
    MuseumFunctions.showing = false;
    Destroy(gameObject);
  }
}
