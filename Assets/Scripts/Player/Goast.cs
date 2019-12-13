﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goast : MonoBehaviour
{
    public float speed = 2f;
    private Vector2 velocity;
    private GameObject shadow;
    private GameObject player;
    public float protectRange = 2f;
    public float attackRange = 2.5f;

    private void Awake()
    {
        shadow = GameObject.FindWithTag("Shadow");
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        Vector3 movePos = Composite();
        Move(movePos);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    private void Move(Vector2 move)
    {

        move = move * speed * Time.deltaTime;
        velocity = move;
        transform.Translate(move);
    }
    private Vector3 Composite()
    {
        Vector3 vec = new Vector3();
        if ((gameObject.transform.position - shadow.transform.position).magnitude < protectRange)
        {
            vec = -(shadow.transform.position - gameObject.transform.position).normalized;
        }
        else
        {
            if ((gameObject.transform.position - player.transform.position).magnitude < attackRange)
            {
                Debug.Log("Attack");
                vec = Vector3.zero;
            }
            else
            {
                vec = (player.transform.position - gameObject.transform.position).normalized;
                
            }
            if (Vector3.Angle((shadow.transform.position - player.transform.position), (transform.position - shadow.transform.position)) < 90f)
            {
                vec = GetVerticalDir((transform.position - shadow.transform.position));
                if (Vector3.Dot(vec, transform.position-player.transform.position) > 0)
                    vec = -vec;
            }
        }
        return vec;
    }
    public Vector3 GetVerticalDir(Vector3 dir)
    {
        return new Vector3(-dir.y, dir.x).normalized;
    }
}