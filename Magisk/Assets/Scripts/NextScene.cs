using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {
  
  void Start() {
    
  }

  void Update() {
    
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Player") {
      string sceneName = SceneManager.GetActiveScene().name;
      if (sceneName == "TempleScene") {
        SceneManager.LoadScene("JungleScene");
      } else {
        SceneManager.LoadScene("ChurchScene");
      }
    }
  }
}
