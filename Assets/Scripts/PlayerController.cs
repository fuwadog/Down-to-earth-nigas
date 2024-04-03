using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    public WeaponController weapon;


    
    public PlayerJoyStick joyStick;
    public PlayerJoyStick shootJoystick;

    public bool canShoot = true;


    Vector2 moveDirection;
    //Vector2 mousePosition;


    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        if(joyStick.inputDir != Vector2.zero)
            moveInput = joyStick.GetMove();


        moveDirection = moveInput.normalized * speed;
       // mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
         rb.MovePosition(rb.position +moveDirection * Time.deltaTime);

         Vector2 aimDirection = shootJoystick.GetRotation() - rb.position;
         float aimAngle = Mathf.Atan2(shootJoystick.GetRotation().y,shootJoystick.GetRotation().x) * Mathf.Rad2Deg - 90f;
         rb.rotation = aimAngle;

     

    }
}


