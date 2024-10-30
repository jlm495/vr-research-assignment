using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spill : MonoBehaviour
{
    // Start is called before the first frame update
    ParticleSystem water;
    void Start()
    {
        water = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Angle(Vector3.down, transform.forward) >= 45f){

            water.Play();

        }

        else{

            water.Stop();

        }
    }
}
