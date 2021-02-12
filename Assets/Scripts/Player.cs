﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private GameObject[] spellPrefab;

    [SerializeField]
    private Transform[] exitPoints;

    private int exitIndex = 3;

    private Vector2 shotDirection = Vector2.down;

    public bool canTurn = true;
    public bool spellActive = false;
    public bool falling = false;

    // Update is called once per frame
    protected override void Update()
    {
        if (canTurn && !spellActive)
        {
            GetInput();
        }

        if (falling)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, 2.0f * Time.deltaTime);

            if (transform.localScale.x < 0.1 && transform.localScale.y < 0.1 && transform.localScale.z < 0.1)
            {
                Destroy(gameObject, 1f);
            }
        }

        base.Update();
    }

    private void GetInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            exitIndex = 0;
            direction += Vector2.up;
            shotDirection = Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            exitIndex = 1;
            direction += Vector2.left;
            shotDirection = Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            exitIndex = 3;
            direction += Vector2.down;
            shotDirection = Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            exitIndex = 2;
            direction += Vector2.right;
            shotDirection = Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isAttacking && !IsMoving)
            {
                attackRoutine = StartCoroutine(Attack());
                canTurn = false;
                spellActive = true;
            }                
        }
    }

    private IEnumerator Attack()
    {      
        isAttacking = true;

        myAnimator.SetBool("attack", isAttacking);

        yield return new WaitForSeconds(1); //Hardcoded cast time

        CastSpell();

        StopAttack();
    }

    public void CastSpell()
    {
        Instantiate(spellPrefab[0], exitPoints[exitIndex].position, Quaternion.identity);

        speed = 1;

        myRigidBody.velocity = -(shotDirection * speed);
    }

    public Vector2 GetDirection()
    {
        return shotDirection;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void PlayerFall()
    {
        direction = Vector2.zero;
        direction = Vector2.down;
        myRigidBody.velocity = Vector2.zero;
        falling = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        myAudioSource.Play();
        SnapToGrid();
        canTurn = true;
        Debug.Log(collision.gameObject.name);        
    }
}
