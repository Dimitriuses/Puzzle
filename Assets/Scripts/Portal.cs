using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform PlayerTransform;
    public Transform OtherPortalCanwasTransform;
    public Camera Camera;
    public Transform TEST;
    private Transform PortalCanwasTransform;
    // Start is called before the first frame update
    void Start()
    {
        PortalCanwasTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(PlayerTransform.position - PortalCanwasTransform.position);
        Vector3 PVecPos = PlayerTransform.position;
        Vector3 PCVecPos = PortalCanwasTransform.position;
        Vector3 DCLPos = (PVecPos - PCVecPos) * -2;
        DCLPos.y = PVecPos.y;
        Camera.transform.localPosition = DCLPos;
        Vector2 a = new Vector2(PlayerTransform.position.x, PlayerTransform.position.z);
        Vector2 b = new Vector2(PortalCanwasTransform.position.x, PortalCanwasTransform.position.z);
        float c = Mathf.Sqrt(Mathf.Pow(b.x - a.x, 2) + Mathf.Pow(b.y - a.y, 2));
        //Debug.Log(c);
        TEST.localPosition = (PlayerTransform.position - PortalCanwasTransform.position) * -2;
        //float F = Mathf.Atan2(TEST.localPosition.z, TEST.localPosition.x);
        //Debug.Log(TEST.localPosition.x + " " + TEST.localPosition.z + " F=" + F);
        //TEST.eulerAngles = (PlayerTransform.eulerAngles + new Vector3(0, F, 0));
        //TEST.eulerAngles = new Vector3(0, F, 0);
        TEST.LookAt(OtherPortalCanwasTransform);
        //Camera.transform.eulerAngles = (PlayerTransform.eulerAngles + new Vector3(0, -90, 0));
        Camera.transform.LookAt(OtherPortalCanwasTransform);
        Camera.transform.eulerAngles = new Vector3(0, Camera.transform.eulerAngles.y, 0);
        Camera.focalLength = 30.0f + c*2;
    }
}
