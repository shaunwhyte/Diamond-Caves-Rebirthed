using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 6f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float maxSpeed = 1.0f;
        switch (collision.gameObject.tag)
        {
            case "BlueDiamond":

                if (Mathf.Abs(collision.relativeVelocity.y) > maxSpeed)
                {
                    Destroy(this.gameObject);
                }
                Destroy(collision.gameObject);
                break;
            case "GreenDiamond":
                Destroy(collision.gameObject);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") == 0f && Input.GetAxisRaw("Horizontal") == 0f)
        {
                if (Input.GetAxisRaw("Vertical") == 0f && Input.GetAxisRaw("Horizontal") == 0f)
                {
                    ChangeAnimation("goIdle");
                }
        }

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
            {
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    ChangeAnimation("runRight");
                }
                else
                {
                    ChangeAnimation("runLeft");
                }
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .1f, whatStopsMovement)){
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }


            } else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0)
            {
                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    ChangeAnimation("runUp");
                }
                else
                {
                    ChangeAnimation("runDown");
                }
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement)){
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }


            }
        }
    }

    private void ChangeAnimation(string an)
    {
        animator.SetTrigger(an);
    }
}
