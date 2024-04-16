using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 7.0f;
    private Rigidbody rb;
    private bool isGrounded;

    private float getH;
    private float getV;
   
   void Start()
   {
       rb = GetComponent<Rigidbody>();
   }

   //외부에서 값을 제어할 수 있는 함수
   public void SetHorizontal(float _h)
   {
       getH = _h;
   }
   
   //외부에서 값을 제어할 수 있는 함수
   public void SetVertical(float _v)
   {
       getV = _v;
   }

   void Update()
   {
       //키보드로 받아오는 값
       float moveHorizontal = Input.GetAxis("Horizontal");
       float moveVertical = Input.GetAxis("Vertical");

       //외부에서 제어한 값이 0이 아니면 그 값을 사용한다.
       if (getH != 0)
       {
           moveHorizontal = getH;
       }
       
       if (getV != 0)
       {
           moveVertical = getV;
       }

       Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
       rb.MovePosition(transform.position + movement * speed * Time.deltaTime);

       if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
       {
           rb.AddForce(new Vector3(0.0f, jumpForce, 0.0f), ForceMode.Impulse);
       }
   }

   void OnCollisionEnter(Collision collision)
   {
       if (collision.gameObject.CompareTag("Ground"))
       {
           isGrounded = true;
       }
   }

   void OnCollisionExit(Collision collision)
   {
       if (collision.gameObject.CompareTag("Ground"))
       {
           isGrounded = false;
       }
   }
}