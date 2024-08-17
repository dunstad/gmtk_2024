using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightBeamAnimation : MonoBehaviour
{
    IEnumerator animate;
    public float animationSlower;
    public float distanceShiftDecreaser;

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
            gameObject.GetComponent<Light2D>().intensity = Mathf.Abs(Mathf.Sin((Time.time  + (transform.position.x) / distanceShiftDecreaser) / animationSlower));
            // transform.Rotate(new Vector3(0, 0, Mathf.Sin(Time.time) / 2));
            // var newScale = originalScale * ((Mathf.Sin(Time.time) / 2) + 1.25f);
            // transform.localScale = new Vector3(newScale, newScale, newScale);
            yield return null;
        }
    }
}
