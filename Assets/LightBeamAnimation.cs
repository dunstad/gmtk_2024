using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightBeamAnimation : MonoBehaviour
{
    IEnumerator animate;
    public float animationSlower;
    public float distanceShiftDecreaser;
    public float intensityDecreaser;

    // Start is called before the first frame update
    void Start()
    {
        animate = Animate();
        StartCoroutine(animate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Animate()
    {
        while (true) {
            // gameObject.GetComponent<Light2D>().intensity = Mathf.Abs(Mathf.Sin((Time.time  + (transform.position.x) / distanceShiftDecreaser) / animationSlower));
            gameObject.GetComponent<Light2D>().intensity = (Mathf.Sin((Time.time  + (transform.position.x) / distanceShiftDecreaser) / animationSlower) + 1) / intensityDecreaser;
            yield return null;
        }
    }
}
