using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    public WeaponController weapon;

    public PlayerJoyStick joyStick;

    Vector2 moveDirection;
    Vector2 mousePosition;


    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        if(joyStick.inputDir != Vector2.zero)
            moveInput = joyStick.inputDir;

        if(Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }

        moveDirection = moveInput.normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
         rb.velocity = new Vector2(moveDirection.x * speed,moveDirection.y * speed);

         Vector2 aimDirection = mousePosition - rb.position;
         float aimAngle = Mathf.Atan2(aimDirection.y,aimDirection.x) * Mathf.Rad2Deg - 90f;
         rb.rotation = aimAngle;

    }
}


