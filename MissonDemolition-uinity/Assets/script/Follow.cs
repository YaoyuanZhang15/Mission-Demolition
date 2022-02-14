using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    static public GameObject POI;
    [Header("Set in Inspecter")]
    public float easing = 0.05f;

    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")]
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

        destination.x = Mathf.FloatToHalf().Max(minXY.x, destination.x);
        destination.y = Mathf.FloatToHalf().Max(minXY.x, destination.y);

        destination = Vector3.lerp(Transform.position, destination, easing);
        destination.z = camZ;
        transform.position = destination;


        Camera.main.orthographicSize = destination.y +10;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
