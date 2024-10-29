using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class buttonVR : MonoBehaviour
{
   [SerializeField]
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    [SerializeField]
    private GameObject waterTemplate;
    private float waterTimer = 8f;
    //AudioSource sound;
    bool isPressed;
    bool isWater;
    GameObject newWater;

    // Start is called before the first frame update
    void Start()
    {
        //sound = GetComponent<AudioSource>();
        isPressed = false;
        isWater = false;
    }

    void Update()
    {

        waterTimer -= Time.deltaTime;
              
        if((waterTimer < 0) && isWater){
            waterTimer = 8f;
            Destroy(newWater);
            isWater = false;
        }
    }

    private void OnTriggerEnter(Collider other){ //private

        if(!isPressed){

            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            //sound.Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other){ //private

        if (other.gameObject == presser){

            button.transform.localPosition = new Vector3(0, 0.015f, 0); // 0.15f is y of presser original position before pressed
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void SpawnWater(){ //public

        /*GameObject water = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        water.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        water.transform.localPosition = new Vector3(0, 1, 2);
        water.AddComponent<Rigidbody>();*/

       // to spawn multiple balls each time the button is pressed ie water 
        /*for(int i = 0; i < 10; i++){

            GameObject newWater = Instantiate(waterTemplate);

        }*/

        newWater = Instantiate(waterTemplate);
        isWater = true;

        return;
    }
    
}