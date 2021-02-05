using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform PlayerTransform;
    public Transform PortalCanwasTransform;
    public Camera Camera;
    public Transform TEST;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(PlayerTransform.position - PortalCanwasTransform.position);
        Camera.transform.localPosition = (PlayerTransform.position - PortalCanwasTransform.position) * -2;
        Vector2 a = new Vector2(PlayerTransform.position.x, PlayerTransform.position.z);
        Vector2 b = new Vector2(PortalCanwasTransform.position.x, PortalCanwasTransform.position.z);
        float c = Mathf.Sqrt(Mathf.Pow(b.x - a.x, 2) + Mathf.Pow(b.y - a.y, 2));
        //Debug.Log(c);
        //TEST.localPosition = (PlayerTransform.position - PortalCanwasTransform.position) * -2;
        //TEST.eulerAngles = (PlayerTransform.eulerAngles + new Vector3(0, -90, 0));
        Camera.transform.eulerAngles = (PlayerTransform.eulerAngles + new Vector3(0, -90, 0));
        Camera.focalLength = 30.0f + c;
    }
}
