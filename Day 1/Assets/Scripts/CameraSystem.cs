using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{

    public Transform player;
    public float xMin;
    public float xMax;

    void LateUpdate()
    {
      float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
      gameObject.transform.position = new Vector3(x,gameObject.transform.position.y,gameObject.transform.position.z);
    }
}
