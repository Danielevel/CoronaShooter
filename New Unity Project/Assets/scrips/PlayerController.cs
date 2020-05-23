using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //--------------------------------------[VARIABLES CONTROL]----------------------------
    private float horizontalMove;
    private float verticalMove;
    private Vector3 playerInput;
    public CharacterController player;
    public float playerSpeed;
    private Vector3 movePlayer;
    
    //--------------------------------------------------------------------------

    //--------------------------------------[VARIABLES FISICAS]----------------------------
    public float gravity = 9.8f;
    public float fallVelocity;
    public float jumpForce;
    //--------------------------------------------------------------------------

    //--------------------------------------[VARIABLES CAMARA]----------------------------
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    //--------------------------------------------------------------------------
    public bool isOnSlope = false;
    private Vector3 hitNormal;
    public float slideVelocity;
    public float slopeForceDown;
    

    //------------------------------------------------[METODO START]------------------------------------------------
    void Start()
    {
        player = GetComponent <CharacterController>();
    }
    //--------------------------------------------------------------------------------------------------------------
    
    //------------------------------------------------[METODO UPDATE]-----------------------------------------------
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
       
        verticalMove = Input.GetAxis("Vertical");

        //creacion del vectorial del movimiento
        playerInput = new Vector3(horizontalMove,0,verticalMove);
       
        //limitador de movimiento
        playerInput = Vector3.ClampMagnitude(playerInput,playerSpeed);
        
        camDirection();
        
        // calcula en movimiento de moo que se mueva segun la direccion que tiene la camara
        movePlayer = playerInput.x*camRight + playerInput.z*camForward;

        movePlayer = movePlayer * playerSpeed;//----ojo, separar esta porqueria por si se neceita en un futuro

        //gira el objeto, para que de prente a la direccion donde esta avanzando
        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();
        PlayerSkills();

        //ejecucion del movimiento, limitandolo, asignandole la velocidad y estableciendo el moimiento a una razon de tiempo
        player.Move(movePlayer * Time.deltaTime);
        
    }
    //--------------------------------------------------------------------------------------------------------------
   
    //-------------------------------------------[METODO DE LA DIRECCION]-------------------------------------------
    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
    //--------------------------------------------------------------------------------------------------------------

    
    //--------------------------------------------[METODO DE LA SKILLS]---------------------------------------------
    public void PlayerSkills()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
        }
    }
    //--------------------------------------------------------------------------------------------------------------


    //-------------------------------------------[METODO DE LA GRAVEDAD]--------------------------------------------
    void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        SlideDown();
    }
    //--------------------------------------------------------------------------------------------------------------

    //-------------------------------------------[METODO DE RESBALAR]--------------------------------------------
    public void SlideDown()
    {
        isOnSlope = Vector3.Angle(Vector3.up, hitNormal) >= player.slopeLimit;
        if(isOnSlope)
        {
            movePlayer.x += ((1f - hitNormal.y)*hitNormal.x) * slideVelocity;
            movePlayer.z += hitNormal.z * slideVelocity;
            movePlayer.y += slopeForceDown;
            
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
    }
    //--------------------------------------------------------------------------------------------------------------


}
