using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;

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
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement)){
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    ChangeAnimation("runRight");
                }
                else
                {
                    ChangeAnimation("runLeft");
                }

            } else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement)){
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    ChangeAnimation("runUp");
                }
                else
                {
                    ChangeAnimation("runDown");
                }

            }
        }
    }

    private void ChangeAnimation(string an)
    {
        animator.SetTrigger(an);
    }
}
