using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    protected float speed;

    protected Animator myAnimator;
    protected Rigidbody2D myRigidBody;
    protected AudioSource myAudioSource;

    protected Vector2 direction;
    protected bool isAttacking = false;
    protected bool canInput1 = true;

    protected Coroutine attackRoutine;

    public bool IsMoving
    {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    protected virtual void Update()
    { 
        HandleLayers();
    }

    private void FixedUpdate()
    {
        //Move();
    }

    public void Move()
    {
        myRigidBody.velocity = direction.normalized * speed;
    }

    public void HandleLayers()
    {
        if (IsMoving)
        {
            ActivateLayer("WalkLayer");

            myAnimator.SetFloat("x", direction.x);
            myAnimator.SetFloat("y", direction.y);

            StopAttack();
        }
        else if (isAttacking)
        {
            ActivateLayer("AttackLayer");
        }
        else
        {
            ActivateLayer("IdleLayer");
        }
    }

    public void ActivateLayer(string layerName)
    {
        for (int i = 0; i < myAnimator.layerCount; i++)
        {
            myAnimator.SetLayerWeight(i, 0);
        }

        myAnimator.SetLayerWeight(myAnimator.GetLayerIndex(layerName), 1);
    }

    public void StopAttack()
    {
        if (attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
            isAttacking = false;
            myAnimator.SetBool("attack", isAttacking);
        }

    }
}
