using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour  {

  [SerializeField]
  public GameObject pauseMenuPanel;
  public static bool isPaused;

  void Start() {
    pauseMenuPanel.SetActive(false);
    isPaused = false;
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.Escape)) {
      if (pauseMenuPanel.activeSelf) {
        ResumeGame();
      } else {
        PauseGame();
      }
    }
  }

  public void ResumeGame() {
    isPaused = false;
    Time.timeScale = 1f;
    pauseMenuPanel.SetActive(false);
  }

  public void PauseGame() {
    isPaused = true;
    Time.timeScale = 0f;
    pauseMenuPanel.SetActive(true);
  }

  public void QuitToMainMenu() {
    Time.timeScale = 1f;
    pauseMenuPanel.SetActive(false);
    SceneManager.LoadScene("MenuScene");
  }
}
