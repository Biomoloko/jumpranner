using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovingInGame : MonoBehaviour, IBotState
{
    [SerializeField] Vector3 neededPos;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] float jumpForce;
    [SerializeField] private float botMoveSpeed;
    [SerializeField] private LayerMask hexMask;
    [SerializeField] private GameObject center;
    private Animator anim;
    public bool isGrounded;
    public void UpdateAction()
    {
        neededPos.y = transform.position.y;
        if (isGrounded == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(center.transform.position.x, transform.position.y, center.transform.position.z), botMoveSpeed * Time.deltaTime);
            return;
        }
        if (transform.position == neededPos)
        {
            FindDirection();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, neededPos, botMoveSpeed * Time.deltaTime);
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        neededPos = transform.position;

        
    }

    private void FindDirection()
    {

        Vector3 rayCastingPos = transform.forward + transform.position;
        for (int i = 0; i < 6; i++)
        {
            if (Physics.Raycast(rayCastingPos, Vector3.down, out RaycastHit hexHit, 2, hexMask))
            {
                neededPos = rayCastingPos;
                return;
            }
            transform.Rotate(0, 60, 0);
            rayCastingPos = transform.forward + transform.position;
        }
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            neededPos = transform.position;
        }
    }
    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            anim.SetBool("IsGrounded", true);
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision col)
    {
        anim.SetBool("IsGrounded", false);
        isGrounded = false;
    }
}
