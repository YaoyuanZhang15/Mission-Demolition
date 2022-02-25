using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    static public bool goalMet = false;
    void OnTriggerEnter( Collider other)
    {
        if(other.gameObject.tag == "Projectile")
        {
            Goal.goalMet = true;
            Color c = renderer.material.color;
            c.a = 1;
            renderer.material.color = c;
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
