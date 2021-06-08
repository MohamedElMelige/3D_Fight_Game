using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private CharacterController charController;
    private CharactarAni playerAni;

    public float movement_Speed = 3f;
    public float gravity = 908f;
    public float rotation_speed = 0.15f;
    public float rotateDegreePerSecand = 180f;

    // Start is called before the first frame update
    void Awake()
    {
        charController = GetComponent<CharacterController>();
        playerAni = GetComponent<CharactarAni>();

    }

    // Update is called once per frame
    void Update()
    {
        Move1();
        Rotate();
        walkAnimation();
    }

    void Move1()
    {
        print("the value is" + Input.GetAxisRaw("Vertical"));
        if (Input.GetAxis(Axis.VERTICAL_AIXS) > 0)
        {
            Vector3 moveDirecation = transform.forward;
            moveDirecation.y -= gravity * Time.deltaTime;
            charController.Move(moveDirecation * movement_Speed * Time.deltaTime);
        }
        else if (Input.GetAxis(Axis.VERTICAL_AIXS) < 0)
        {
            Vector3 moveDirecation = -transform.forward;
            moveDirecation.y -= gravity * Time.deltaTime;
            charController.Move(moveDirecation * movement_Speed * Time.deltaTime);
        }
        else
        {
            charController.Move(Vector3.zero);
        }
    }
    void Rotate()
    {
        Vector3 rotation_Direcation = Vector3.zero;
        if (Input.GetAxis(Axis.HORIZONTAL_AIXS) < 0)
        {
            rotation_Direcation = transform.TransformDirection(Vector3.left);
        }
         if(Input.GetAxis(Axis.HORIZONTAL_AIXS) > 0)
        {
            rotation_Direcation = transform.TransformDirection(Vector3.right);
        }
         if(rotation_Direcation !=Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rotation_Direcation), rotateDegreePerSecand * Time.deltaTime);
        }
    }

    void walkAnimation()
    {
        if(charController.velocity.sqrMagnitude != 0f)
        {
            playerAni.Walk(true);
        }
        else
        {
            playerAni.Walk(false);
        }
    }


}//class
