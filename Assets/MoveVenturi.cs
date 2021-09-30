using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVenturi : MonoBehaviour
{
    public float dx;
    private float inity;
    private float initz;
    public float T;

    private float bigLength = 3;
    private float smallLength = 3;
    private float slopeLength = 3;

    public float radius;
    public float radiusIn;

    public TrailRenderer trail;


    // Start is called before the first frame update
    void Start()
    {
        inity = transform.position.y;
        initz = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position.x < bigLength)
        {
            var speedFactor = 1;
            transform.position += new Vector3(speedFactor * dx, 0, 0);
        }
        else if (transform.position.x < bigLength + slopeLength)
        {
            var slopey = (inity * radiusIn / radius - inity) / (slopeLength);
            var slopez = (initz * radiusIn / radius - initz) / (slopeLength);
            var slope = (radiusIn - radius) / (slopeLength);
            var speedFactor = (radius * radius) / Mathf.Pow(radius + slope * (transform.position.x - bigLength), 2);
            transform.position = new Vector3(transform.position.x, inity + slopey * (transform.position.x - bigLength), initz + slopez * (transform.position.x - bigLength));
            transform.position += new Vector3(speedFactor * dx, 0, 0);
        }
        else if (transform.position.x < bigLength + slopeLength + smallLength)
        {
            var speedFactor = radius * radius / (radiusIn * radiusIn);
            transform.position += new Vector3(speedFactor * dx, 0, 0);
        }
        else if (transform.position.x < bigLength + slopeLength + smallLength + slopeLength)
        {
            var slopey = -(inity * radiusIn / radius - inity) / (slopeLength);
            var slopez = -(initz * radiusIn / radius - initz) / (slopeLength);
            var slope = -(radiusIn - radius) / (slopeLength);
            var speedFactor = (radius * radius) / Mathf.Pow(radiusIn + slope * (transform.position.x - bigLength - slopeLength - smallLength), 2);
            transform.position = new Vector3(transform.position.x, inity * radiusIn / radius + slopey * (transform.position.x - bigLength - slopeLength - smallLength), initz * radiusIn / radius + slopez * (transform.position.x - bigLength - slopeLength - smallLength));
            transform.position += new Vector3(speedFactor * dx, 0, 0);
        }
        else if (transform.position.x < bigLength + slopeLength + smallLength + slopeLength + bigLength)
        {
            var speedFactor = 1;
            transform.position += new Vector3(speedFactor * dx, 0, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
