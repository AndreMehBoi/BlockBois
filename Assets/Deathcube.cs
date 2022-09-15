using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathcube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = this.gameObject.transform.localPosition;
        position.x += 1f * Time.deltaTime;
        this.gameObject.transform.localPosition = position;
    }
}
