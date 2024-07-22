using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour
{
    Collider2D[] hitColliders;
    public float radius ;
    target tar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, 1 << 7);
        //Debug.Log(hitColliders.Length);
        foreach (var hitCollider in hitColliders)
        {
            tar = hitCollider.GetComponent<target>();
            if(tar.available==true)
            {
                tar.holdPoints -= 0.5f;
            }
        }
        
    }
}
