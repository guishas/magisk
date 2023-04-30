using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

  [SerializeField]
  private Sprite openedChestSprite;
  [SerializeField]
  private List<GameObject> droppableItems;
  private bool isOpen;

  void Start() {
    isOpen = true;
  }

  void Update() {
      
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Player") {
      if (isOpen) {
        isOpen = false;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = openedChestSprite;
        int randomN = UnityEngine.Random.Range(0, droppableItems.Count);
        GameObject item = Instantiate(droppableItems[randomN], transform.position, Quaternion.identity);

        Vector3 dropPos = transform.position;
        bool isInsidePlayer = true;
        while (isInsidePlayer) {
          dropPos = transform.position + Random.insideUnitSphere * 1.5f;
          dropPos.z = 0; // keep the item at ground level

          Collider[] colliders = Physics.OverlapSphere(dropPos, 0.5f);
          isInsidePlayer = false;
          foreach (Collider collider in colliders) {
            if (collider.CompareTag("Player")) {
              isInsidePlayer = true;
              break;
            }
          }
        }
        
        item.transform.position = dropPos;
      }
    }
  }
}
