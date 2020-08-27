using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public AudioContainer audioContainer;

    private int spawnerCount = 0;

    private bool sourceTwo = false;
    private bool sourceThree = false;

    private void Start()
    {
        audioContainer.PlayMusicSource1();
        audioContainer.PlayMusicSource2(0);
        audioContainer.PlayMusicSource3(0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "SpawnPointTwo")
        {
            spawnerCount = 1;

            if (sourceTwo == false)
            {
                sourceTwo = true;
                audioContainer.StartCrossfadeOne();
                //audioContainer.StopMusicSource1();
                //audioContainer.PlayMusicSource2(1.0f);
            }
        }
        if (collision.collider.tag == "SpawnPointThree")
        {
            spawnerCount = 2;

            if (sourceThree == false)
            {
                sourceThree = true;
                audioContainer.StartCrossfadeTwo();
                //audioContainer.StopMusicSource2();
                //audioContainer.PlayMusicSource3(1.0f);
            }
        }
        if (collision.collider.tag == "Deadzone")
        {
            //print("deadzone");

            if (spawnerCount == 0)
            {
                transform.position = new Vector3(-12.08f, 0, -1);
            }
            if (spawnerCount == 1)
            {
                transform.position = new Vector3(50.85776f, -2.85f, -1);
            }
            if (spawnerCount == 2)
            {
                transform.position = new Vector3(84.88776f, -0.6399999f, -1);
            }

        }
    }
}
