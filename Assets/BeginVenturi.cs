using UnityEngine;

public class BeginVenturi : MonoBehaviour
{
    public float radius;
    public float radiusIn;
    //public float count;
    public float dr;
    public GameObject wave;
    public float dx;
    public float delayTime;
    private float delay;

    // Start is called before the first frame update
    void Start()
    {
        delay = delayTime;
    }

    private void FixedUpdate()
    {
        if(delay == delayTime)
        {
            delay = 0;
            Make();
        }
        else
        {
            delay++;
        }
        //transform.position = new Vector3(transform.position.x + dx, 0, 0);
    }

    private void Make()
    {
        for (float i = dr; i <= radius; i += dr)
        {
            for (float j = 0; j < 360; j += 18)
            {
                Instantiate(wave, new Vector3(0, i * Mathf.Cos(j), i * Mathf.Sin(j)), Quaternion.identity);
            }
        }
    }
}