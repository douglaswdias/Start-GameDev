using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField]
    private float treeHealth;
    [SerializeField]
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnHit()
    {
        treeHealth--;

        anim.SetTrigger("IsHit");

        if(treeHealth <= 0)
        {
            anim.SetTrigger("Cut");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe"))
        {
            OnHit();
        }
    }
}
