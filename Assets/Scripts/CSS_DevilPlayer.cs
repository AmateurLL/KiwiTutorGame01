using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class CSS_DevilPlayer : MonoBehaviour
{
    //CHEF PLAYER
    [SerializeField] Vector2 mousePos2D;
    [SerializeField] private float spawnTimer;
    [SerializeField] private float spawnCooldown = 6.5f;
    private float TtimeModifier = 1.0f;

    private void Awake()
    {
        spawnTimer = 0.0f;
    }
    void Update()
    {
        if (!CSS_GameManager.Instance.GetIsGameOver())
        {
            spawnTimer -= (TtimeModifier * Time.deltaTime);
            MouseDetection();
        }
    }
    public bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private bool IsTouchingPlayer()
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return CSS_GameManager.Instance.playerRef.transform.GetChild(2).GetComponent<CircleCollider2D>().OverlapPoint(point);
    }

    public void MouseDetection()
    {
        if (Input.GetMouseButtonDown(0) && !IsMouseOverUI() && !IsTouchingPlayer())
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
            //Debug.Log("UI DETECTED");
        }
        else if (IsTouchingPlayer())
        {
            //Debug.Log("yes touching player");
        }
    }

    public void Summoning()
    {
        if (spawnTimer <= 0.0f)
        {
            if (CSS_GameManager.Instance.selectedTrapRef != null)
            {
                Instantiate(CSS_GameManager.Instance.selectedTrapRef, new Vector3(mousePos2D.x, mousePos2D.y, 0), Quaternion.identity);
                spawnTimer = spawnCooldown;
            }
            else
            {
                //Debug.Log("Click a thing to place :(");
            }
        }
        else
        {
            //Debug.Log("no place >:(");
        }
    }
}
