using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour {

  [SerializeField]
  private GameObject dialogPanel;
  void Start() {
    Time.timeScale = 0f;
  }

  void Update() {
    
  }

  public void DismissDialog() {
    Time.timeScale = 1f;
    dialogPanel.SetActive(false);
  }
}
