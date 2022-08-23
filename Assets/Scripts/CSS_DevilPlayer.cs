using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

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

    public bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    public void MouseDetection()
    {
        if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            //mousePos2D (vector2) = mousePos (vector3), converting the vector3 into a vector2
            mousePos2D = new Vector2(mousePos.x, mousePos.y);
            Summoning();
        }
        else if (IsMouseOverUI())
        {
            Debug.Log("UI DETECTED");
        }
    }

    public void Summoning()
    {
        if (spawnTimer <= 0.0f)
        {
            Instantiate(CSS_GameManager.Instance.selectedTrapRef, new Vector3(mousePos2D.x, mousePos2D.y, 0), Quaternion.identity);
            spawnTimer = 0.01f;
        }
        else
        {
            Debug.Log("no place >:(");
        }
    }
}
