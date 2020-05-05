using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int value;
    float spin = 0.5f;

    void Update()
    {
        transform.Rotate(0, 0, spin);
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
