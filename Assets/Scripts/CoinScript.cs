using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    public AudioContainer audioContainer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            audioContainer.PlayCoinSFX();
            //print("it worked");
        }
    }
}
