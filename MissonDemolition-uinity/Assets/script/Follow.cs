using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    static public GameObject POI;
    public float camz;
    public void Awake()
    {
        camz = this.transform.position.z;

    }

    private void FixedUpdate()
    {

        if (POI == null) return;
    }

        Vector3 destination = POI.transform.position;
        
        destination.z = camZ;
        transform.position = destination;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
