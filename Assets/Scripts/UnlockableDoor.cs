using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockableDoor : MoveableObject
{
    private Animator animator;

    public bool allKeysCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockDoor()
    {
        Debug.Log("Unlock");
        animator.SetTrigger("Unlock");
    }
}
