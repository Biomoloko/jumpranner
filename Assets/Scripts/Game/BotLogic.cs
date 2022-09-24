using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotLogic : MonoBehaviour
{
    public bool isGrounded;
    [SerializeField] Vector3 neededPos;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] float jumpForce;
    [SerializeField] float botMoveSpeed;
    [SerializeField] private LayerMask hexMask;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        neededPos = transform.position;
    }

    void Update()
    {
        neededPos.y = transform.position.y;
        if (isGrounded == false)
        {
            return;
        }
        if (transform.position == neededPos)
        {
            FindDirection();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, neededPos, botMoveSpeed*Time.deltaTime);
        }
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision col)
    {
        //Debug.Log("EXIT !");
        isGrounded = false;
    }

    private void FindDirection()
    {
        Vector3 rayCastingPos = transform.forward + transform.position;
        Collider[] castingSphereHexs = new Collider[3];
        for (int i = 0; i < 6; i++)
        {
            //if (Physics.Raycast(rayCastingPos, Vector3.down, out RaycastHit hexHit, 2, hexMask))
            if (Physics.OverlapSphereNonAlloc(rayCastingPos, 0.1f, castingSphereHexs, hexMask) > 0)
            {
                neededPos = rayCastingPos;
                Debug.Log(castingSphereHexs.Length);
                return;
            }
            transform.Rotate(0, 60, 0);
            rayCastingPos = transform.forward + transform.position;
            Debug.Log(transform.rotation);
        }

        rigidbody.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.forward+transform.position + Vector3.up, transform.forward + transform.position + Vector3.down);
    }
}
