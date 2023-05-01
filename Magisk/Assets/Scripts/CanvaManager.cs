using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvaManager : MonoBehaviour {
  
  [SerializeField]
  public GameObject dialogPanel;
  void Start() {
    dialogPanel.SetActive(false);
  }

  
  void Update() {
    
  }

  public void showDialog() {
    Time.timeScale = 0f;
    dialogPanel.SetActive(true);
  }

  public void dismissDialog() {
    Time.timeScale = 1f;
    dialogPanel.SetActive(false);
  }
}
