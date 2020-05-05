using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int value;

    void Update()
    {
        transform.Rotate(0, 0, 0.3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //add value to player score
            Destroy(gameObject);
        }
    }
}
