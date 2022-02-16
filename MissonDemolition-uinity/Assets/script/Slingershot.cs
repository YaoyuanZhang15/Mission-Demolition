using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingershot : MonoBehaviour
{
    static private Slingershot S;


    [Header("Set in Inspectpr")]
    public GameObject prefabprojectile;

    public GameObject launchPoint;
    public float velocityMultipler = 8f;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    public Rigidbody projectileRB;


    static public Vector3 launch_Pos
    {
        get
        {
            if (S == null) return Vector3.zero;
            return S.launchPos;
        }



    }
    private void Awake()
    {
        S = this;

        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;

        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;



    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!aimingMode) return;
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 mouseDelta = mousePos3D - launchPos;

        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }
        Vector3 projectilePos = launchPos + mouseDelta;
        projectile.transform.position = projectilePos;

        if (Input.GetMouseButtonUp(0))
        {
            aimingMode = false;
            projectileRB.isKinematic = false;
            projectileRB.velocity = -mouseDelta * velocityMultipler;
            Follow.POI = projectile;
            projectile = null;
        }
    }

    public void OnMouseEnter()
    {
        launchPoint.SetActive(true);
        print("Slingshot: OnMouseEnter");

    }

    private void OnMouseExit()
    {
        launchPoint.SetActive(false);
        print("Slingshot: OnMouseExit");
    }

    private void OnMouseDown()
    {
        aimingMode = true;
        projectile = Instantiate(prefabprojectile) as GameObject;
        projectile.transform.position = launchPos;
        projectileRB = projectile.GetComponent<Rigidbody>();
        projectileRB.isKinematic = true;
    }
}


