using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_Trap : MonoBehaviour
{
    [SerializeField] private float lifeTime = 10.0f;
    [SerializeField] private float timeModifier = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Deterioration();
    }

    void Deterioration()
    {
        lifeTime -= (timeModifier * Time.deltaTime);
        if (lifeTime <= 0.0f)
        {
            Debug.Log("adios");
            Object.Destroy(this.gameObject);
        }
    }
}
