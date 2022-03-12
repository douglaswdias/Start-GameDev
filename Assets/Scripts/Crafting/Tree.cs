using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField]
    private float treeHealth;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject woodPrefab;
    [SerializeField]
    private int woodAmount;
    [SerializeField]
    private ParticleSystem leaves;
    [SerializeField]
    private ParticleSystem wood;

    private bool isCutted;

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
        leaves.Play();

        if(treeHealth <= 0)
        {
            for(int i = 0; i < woodAmount; i++)
            {
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0f), transform.rotation);
            }
            anim.SetTrigger("Cut");

            isCutted = true;
        }
    }

    void OnCut()
    {
        if (treeHealth <= 0)
        {
            wood.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe") && !isCutted)
        {
            OnHit();
        }

        if (collision.CompareTag("Axe") && isCutted)
        {
            OnCut();
        }
    }
}
