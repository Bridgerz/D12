using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FaceCamera : MonoBehaviour, IPointerClickHandler
{

    private bool focused;

    private void Start()
    {
        focused = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("here1");
        if (eventData.button == PointerEventData.InputButton.Right) // right click
        {
            if (!focused)
            {
                Debug.Log("here2");
                var targetPosition = new Vector3(Camera.main.transform.position.x,
                    Camera.main.transform.position.y,
                    transform.position.z);
                transform.LookAt(targetPosition);
                focused = true;
            }
            else
            {
                transform.rotation = new Quaternion(0f, 90f, 90f, 0f);
                focused = false;
            }
        }
    }
}
