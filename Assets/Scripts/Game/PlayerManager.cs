using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidB;
    [SerializeField] private Animator anim;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private float forceCofficient = 0.025f ;

    [SerializeField] private float timeNotOnHex;
    private Coroutine currentCoroutine;

    public FixedJoystick joystick;
    public int moveSpeed;

    public bool temp;
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rigidB.velocity = new Vector3(joystick.Horizontal * moveSpeed * Time.deltaTime,
                                      rigidB.velocity.y,
                                      joystick.Vertical * moveSpeed * Time.deltaTime);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            Vector3 ignoreYmovement = new Vector3(rigidB.velocity.x, 0, rigidB.velocity.z);
            anim.SetBool("IsMoving", true);
            transform.rotation = Quaternion.LookRotation(ignoreYmovement);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            //anim.SetBool("IsGrounded", false);
            rigidB.AddForce(new Vector3(0, 1, 1) * forceCofficient, ForceMode.Impulse);
            
        }


    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        anim.SetBool("IsGrounded", true);
    }
    public void OnCollisionExit(Collision col)
    {
        ExitCollision();
    }
    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(timeNotOnHex);
        anim.SetBool("IsGrounded", false);

    }
    public void ExitCollision()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(Waiter());
    }

    //private void OnCollisionEnter(Collision col)
    //{

    //    if (col.gameObject.tag == "Ground")
    //    {
    //        if (currentCoroutine != null)
    //        {
    //            StopCoroutine(currentCoroutine);
    //        }
    //        isGrounded = true;
    //        anim.SetBool("IsGrounded", true);
    //    }

    //}
    //public void OnCollisionExit(Collision col)
    //{
    //    if (currentCoroutine != null)
    //    {
    //        StopCoroutine(currentCoroutine);
    //    }
    //    isGrounded = false;
    //    currentCoroutine = StartCoroutine(Waiter());
    //}
    //IEnumerator Waiter()
    //{
    //    yield return new WaitForSeconds(0.3f);
    //    anim.SetBool("IsGrounded", false);
    //}
}

