using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    private PlayerItems playerItems;

    public static PlayerAnim Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
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
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.isRolling)
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

        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (player.IsCutting)
        {
            anim.SetInteger("Transition", 3);
        }

        if (player.IsDigging)
        {
            anim.SetInteger("Transition", 4);
        }

        if (player.IsWatering && playerItems.CurrentWater > 0f)
        {
            anim.SetInteger("Transition", 5);
        }

        if (player.IsWatering && playerItems.CurrentWater <= 0f)
        {
            anim.SetInteger("Transition", 6);
        }

        if(player.IsGettingWater)
        {
            anim.SetInteger("Transition", 7);
        }
    }

    void OnRun()
    {
        if (player.isRunning)
        {
            anim.SetInteger("Transition", 2);
        }
    }

    #endregion

    public void OnFishingBegin()
    {
        anim.SetTrigger("isFishing");
        Player.Instance.isPaused = true;
    }

    public void OnFishingEnd()
    {
        Fishing.Instance.OnFishing();
        Player.Instance.isPaused = false;
    }


    public void OnBuildingBegin()
    {
        anim.SetBool("Hammering", true);
        Player.Instance.isPaused = true;
    }

    public void OnBuildingEnd()
    {
        anim.SetBool("Hammering", false);
        Player.Instance.isPaused = false;
    }
}
