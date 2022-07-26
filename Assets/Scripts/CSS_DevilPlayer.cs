using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_DevilPlayer : MonoBehaviour
{
    [SerializeField] Vector2 mousePos2D;
    [SerializeField] private float spawnTimer = 3.0f;
    private float TtimeModifier = 1.0f;

    private void Awake()
    {
        spawnTimer = 0.0f;
    }
    void Update()
    {
        spawnTimer -= (TtimeModifier * Time.deltaTime);
        MouseDetection();
    }

    public void MouseDetection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            //mousePos2D (vector2) = mousePos (vector3), converting the vector3 into a vector2
            mousePos2D = new Vector2(mousePos.x, mousePos.y);
            Summoning();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            //mousePos2D (vector2) = mousePos (vector3), converting the vector3 into a vector2
            mousePos2D = new Vector2(mousePos.x, mousePos.y);
            Summoning2();
        }
    }

    public void Summoning()
    {
        if (spawnTimer <= 0)
        {
            Instantiate(CSS_GameManager.Instance.TBlockTrapRef, new Vector3(mousePos2D.x, mousePos2D.y, 0), Quaternion.identity);
            spawnTimer = 3.0f;
        }
        else
        {
            Debug.Log("no place >:(");
        }
    }

    public void Summoning2()
    {
        if (spawnTimer <= 0)
        {
            Instantiate(CSS_GameManager.Instance.TBearTrapRef, new Vector3(mousePos2D.x, mousePos2D.y, 0), Quaternion.identity);
            spawnTimer = 3.0f;
        }
        else
        {
            Debug.Log("no place >:(");
        }
    }
}
