using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour {

  [SerializeField]
  private string lootName;
    
  void Start() {
      
  }

  // Update is called once per frame
  void Update() {
      
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Player") {
      if (lootName == "Potion") {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        player.Health += 25;
        print("Player health += 25");
        print("Player health: " + player.Health);
        Destroy(gameObject);
      } else if (lootName == "SuperPotion") {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        player.Health += 50;
        print("Player health += 50");
        print("Player health: " + player.Health);
        Destroy(gameObject);
      } else if (lootName == "Damage") {
        PlayerController controller = other.GetComponent<PlayerController>();
        controller.basicAttack.damage += 10;
        print("Player damage += 10");
        print("Player damage: " + controller.basicAttack.damage);
        Destroy(gameObject);
      }
    }
  }
}
