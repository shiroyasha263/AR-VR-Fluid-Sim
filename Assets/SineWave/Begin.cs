using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begin : MonoBehaviour
{
    public float radius;
    //public float count;
    public float dr;
    public GameObject wave;
    public float dx;
    private float inity;
    private float initz;
    public float amp;
    public float T;

    // Start is called before the first frame update
    void Start()
    {
        for (float i = dr; i <= radius; i += dr)
        {
            for (float j = 0; j < 2 * Mathf.PI; j += 2*Mathf.PI*i/radius)
            {
                var temp = Instantiate(wave, new Vector3(0, i * Mathf.Cos(j), i * Mathf.Sin(j)), Quaternion.identity);
                temp.transform.parent = transform;
            }
        }
        inity = transform.position.y;
        initz = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + dx, inity + amp * Mathf.Sin(2 * Mathf.PI * transform.position.x / T), initz);
        transform.rotation = Quaternion.Euler(0, 0, 45 * Mathf.Cos(2 * Mathf.PI * transform.position.x / T));
    }
}
