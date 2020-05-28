using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    
    void Update()
    {
        Vector3 spin = new Vector3(.05f,.02f,Random.Range(0.01f,0.05f));
        transform.Rotate(spin);
    }
}
