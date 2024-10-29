using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class waterShoot : MonoBehaviour
{
    public InputActionReference triggerLeft;
    public InputActionReference triggerRight;
    [SerializeField]
    private GameObject waterTemplate;
    GameObject newWaterL;
    GameObject newWaterR;
    bool isWaterL;
    bool isWaterR;
    public GameObject leftHand;
    public GameObject rightHand;
    float shootPower = 30f;
    /*
    1. detect trigger values
    2. if both are initiated, go to shootWater function
    3. shoot water from both hands, stop when triggers are no longer being held
    maybe update location in update function to correspond with hands..?
    variables: waterTemplate, bool?, left hand, right hand, left trigger, right trigger
    */
    // Start is called before the first frame update
    void Start()
    {
        isWaterL = false;
        isWaterR = false;
        triggerLeft.action.performed += ShootWaterL;
        triggerRight.action.performed += ShootWaterR;
    }

    // Update is called once per frame
    void Update()
    {
        /*float leftTriggerVal = triggerLeft.action.ReadValue<float>();
        float rightTriggerVal = triggerRight.action.ReadValue<float>();

        else if (!isWater){
            
            Release();
        }
        */

        if(!isWaterL || !isWaterR){

            Release();
        }
    }

    void ShootWaterR(InputAction.CallbackContext obj){
 
        //Vector3 leftHandPos = new Vector3(0,0,0);
        Vector3 rightHandPos = new Vector3(0,0,0);
        //leftHandPos = leftHand.transform.position;
        rightHandPos = rightHand.transform.position;
        //newWaterL = Instantiate(waterTemplate, transform.position, transform.rotation);
        //newWaterR = Instantiate(waterTemplate, transform.position, transform.rotation);
        //newWaterL.transform.position = leftHandPos;
        //newWaterR.transform.position = rightHandPos;
        //isWaterL = true;
        //isWaterR = true;*/

        newWaterR = Instantiate(waterTemplate, transform.position, transform.rotation);
        newWaterR.transform.position = rightHandPos;
        isWaterR = true;
        //newWaterR.GetComponent<Rigidbody>().AddForce(transform.forward * shootPower);
        newWaterR.transform.rotation = rightHand.transform.rotation;



        return;
    }

    void ShootWaterL(InputAction.CallbackContext obj){

        Vector3 leftHandPos = new Vector3(0,0,0);
        leftHandPos = leftHand.transform.position;

        newWaterL = Instantiate(waterTemplate, transform.position, transform.rotation);
        newWaterL.transform.position = leftHandPos;
        newWaterL.transform.rotation = leftHand.transform.rotation;
        isWaterL = true;
        //newWaterL.GetComponent<Rigidbody>().AddForce(transform.forward * shootPower);

        return;
    }

    void Release(){

        if(isWaterL){

            Destroy(newWaterL);
            isWaterL = false;

        }
        
        if(isWaterR){

            Destroy(newWaterR);
            isWaterR = false;
        }
        
        return;
    }
}
