using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridMove : MonoBehaviour
{
    public float speed = 5f;
    public Transform movePoint;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0), .2f))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
                }                
            }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0, Input.GetAxisRaw("Vertical"), 0), .2f))
                {
                    movePoint.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
