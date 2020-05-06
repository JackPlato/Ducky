using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int value;
    float spin = 0.5f;

    void FixedUpdate()
    {
        transform.Rotate(0, 0, spin);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().GetCoin(value);
            Destroy(gameObject);
        }
    }
}
