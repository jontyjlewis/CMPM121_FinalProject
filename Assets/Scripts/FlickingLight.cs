using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickingLight : MonoBehaviour
{
    new Light light;
    [SerializeField] private float minWaitTime = 0.1f;
    [SerializeField] private float maxWaitTime = 0.5f;
    int flickAmount;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponentInChildren<Light>();
        if (light != null)
        {
            StartCoroutine(FlickerLight());
        }
    }

    //	Turn on and off the light
    IEnumerator FlickerLight()
    {
        while (true)
        {
            flickAmount = Random.Range(1, 3);
            for (int i = 0; i < flickAmount; i++)
            {
                yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
                light.enabled = !light.enabled;
                yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
                light.enabled = !light.enabled;
            }
            yield return new WaitForSeconds(5);
        }
    }
}
