using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public List<Collider2D> detectedObj = new List<Collider2D>();

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player") {
            detectedObj.Add(other);
        }
        
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Player") {
            detectedObj.Remove(other);
        }
    }

    
}
