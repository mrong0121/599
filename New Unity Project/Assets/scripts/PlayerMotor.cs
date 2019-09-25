using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;

    private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    private bool isDead = false;

    private float animationDuration = 1.0f;

    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
      controller = GetComponent<CharacterController>();
      startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
      if (isDead) return;

        if (Time.time - startTime < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        moveVector = Vector3.zero;

        if (controller.isGrounded) {
        verticalVelocity = -1.0f;
            Debug.Log("isGrounded");
        } else { 
        verticalVelocity -= gravity * Time.deltaTime;
            Debug.Log("death");
            //Death();
            //SceneManager.LoadScene("Menu");
        }
      //x left right
      moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
      if (Input.GetMouseButton(0))
      {
        if (Input.mousePosition.x > Screen.width/2)
          moveVector.x = speed;
        else
          moveVector.x = -speed;
      }
      //y up down
      moveVector.y = verticalVelocity;
      //z forward backward
      moveVector.z = speed;
      controller.Move (moveVector * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit){
      if(hit.collider.tag=="coin")
      {
          //Destroy(GetComponent<Coin>());
      } else {
        if(hit.point.z > transform.position.z + controller.radius)
          Death();
      }

    }
    private void Death(){
      isDead = true;
      GetComponent<Score> ().OnDeath();
    }
    public void SetSpeed(int modifier) {
      speed = 5.0f + modifier;
    }
}
