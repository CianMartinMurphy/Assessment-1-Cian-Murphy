using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour{

    //movement settings
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float playerRunSpeed;
    private bool isPlayerRunning;
    public CharacterController CharacterController;
    [SerializeField]
    private bool allowJump = true;
    [SerializeField]
    private float jumpCoolDownTime;

    //mouse settings
    public float mouseSensitivity = 250f;
    private float rotation;
    [SerializeField]
    private Transform playerCam;

    //gravity settings
    public bool isGrounded = false;// these are public so the 
    public float gravityForce;     // fan script can access
    public float velocity = 0;     // them.
    [SerializeField]
    private GameObject gravityObject;
    [SerializeField]
    private LayerMask levelTag;
    
    private GameObject Settings;

    private void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        Settings = GameObject.Find("Setting");
        
        mouseSensitivity = Settings.GetComponent<OptionsScript>().PlayerSensitvity;
    }
    private void FixedUpdate(){
        playerRunCheck();
        mouseMovement();
        playerMovement();
         
    }
    private void Update(){
        //cam and movement controller based on a Brackeys tutorial with adjustments 
        jump();
        checkGravity();   
    }
    private void checkGravity() {

        if (isGrounded == false){
            applyGravity();
            // Debug.Log("grav on");
        }
        else{
            isGrounded = true;
            velocity = 0;
            //Debug.Log("grav of");
        }
        isGrounded = Physics.CheckSphere(gravityObject.transform.position, 0.001f, levelTag);
}
    public void jump(){
        if (Input.GetKey(KeyCode.Space)&&allowJump ==true) {
            
            velocity = jumpForce;
            isGrounded = false;
            StartCoroutine("jumpCooldown");
            //Vector3 jumpVector = transform.up * jumpForce;
            //CharacterController.Move(jumpVector * Time.deltaTime);
            // StartCoroutine("jumpCooldown");
            // allowJump = false;
            //Debug.Log("jump");
        }
        
    }
    IEnumerator jumpCooldown()
    {
        allowJump = false;
        yield return new WaitForSeconds(jumpCoolDownTime);
        allowJump = true;
        //for (int i = 0; i < 5; i++)
        //{

        //    Vector3 jumpVector = transform.up * jumpForce;
        //    CharacterController.Move(jumpVector * Time.deltaTime);
        //    velocity = 0;
        //    yield return new WaitForSeconds(jumpCoolDownTime);
        //}

        
    }
    private void applyGravity(){
        if (isGrounded==false){
            velocity += gravityForce*Time.deltaTime;
            //transform.Translate(gravityVector* Time.deltaTime);
        }
        Vector3 gravityVector= transform.up*velocity;
            
        CharacterController.Move(gravityVector * Time.deltaTime);
    }
    private void mouseMovement() {           
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        rotation -= mouseY;

        //locks the cam so you cant fully rotate
        rotation = Mathf.Clamp(rotation, -90f, 90f);
        transform.Rotate(Vector3.up * mouseX);

        playerCam.transform.localRotation = Quaternion.Euler(rotation, 0f, 0f);
    }
    private void playerMovement(){

        float playerX = Input.GetAxis("Horizontal");
        float playerZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * playerX + transform.forward * playerZ;

        if (isPlayerRunning==false){

            CharacterController.Move(move * playerSpeed * Time.deltaTime);
        }
        else if (isPlayerRunning ==true){

            CharacterController.Move(move * playerRunSpeed * Time.deltaTime);
        }
        
    }
    private void playerRunCheck()  {
        if(Input.GetKey(KeyCode.LeftShift)){

            isPlayerRunning = true;
        }
        else{

            isPlayerRunning = false;
        }
    }
   
}
