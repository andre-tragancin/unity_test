using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Transform filhoTransform = transform.Find("Helpers/FaseManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
