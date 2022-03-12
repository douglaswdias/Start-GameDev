using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player Player;
    private Animator anim;

    private PlayerItems playerItems;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        playerItems = GetComponent<PlayerItems>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
    }

    #region Moviment

    void OnMove()
    {
        if (Player.direction.sqrMagnitude > 0)
        {
            if (Player.isRolling)
            {
                anim.SetTrigger("isRolling");
            }
            else
            {
                anim.SetInteger("Transition", 1);
            }
            
        }
        else
        {
            anim.SetInteger("Transition", 0);
        }

        if (Player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (Player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (Player.IsCutting)
        {
            anim.SetInteger("Transition", 3);
        }

        if (Player.IsDigging)
        {
            anim.SetInteger("Transition", 4);
        }

        if (Player.IsWatering && playerItems.CurrentWater > 0f)
        {
            anim.SetInteger("Transition", 5);
        }

        if (Player.IsWatering && playerItems.CurrentWater <= 0f)
        {
            anim.SetInteger("Transition", 6);
        }
    }

    void OnRun()
    {
        if (Player.isRunning)
        {
            anim.SetInteger("Transition", 2);
        }
    }

    #endregion
}
