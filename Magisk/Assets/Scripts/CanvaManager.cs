using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvaManager : MonoBehaviour {
  
  [SerializeField]
  public GameObject dialogPanel;
  [SerializeField]
  public GameObject bossDialogPanel;
  [SerializeField]
  public GameObject endGamePanel;
  void Start() {
    dialogPanel.SetActive(false);
    bossDialogPanel.SetActive(false);
    endGamePanel.SetActive(false);
  }

  
  void Update() {
    
  }

  public void showDialog() {
    Time.timeScale = 0f;
    dialogPanel.SetActive(true);
  }

  public void showFinalDialog() {
    Time.timeScale = 0f;
    bossDialogPanel.SetActive(true);
  }

  public void dismissDialog() {
    Time.timeScale = 1f;
    dialogPanel.SetActive(false);
  }

  public void dismissBossDialog() {
    Time.timeScale = 1f;
    bossDialogPanel.SetActive(false);
    endGamePanel.SetActive(true);
  }

  public void MainMenu() {
    SceneManager.LoadScene("MenuScene");
  }
}
