using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool redFood;
    public bool greenFood; 

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("RedFood"))
        {
            Debug.Log("collided with red Food");
        }

        if (other.gameObject.CompareTag("GreenFood"))
        {
            Debug.Log("collided with green food");
        }
    }
}
