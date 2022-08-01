using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{

    [SerializeField] private Vector3 cursorOffset;
    void Start()
    {
        Cursor.visible = false;
    }


    void Update()
    {
        Cursor.visible = false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
            transform.position = raycastHit.point + cursorOffset;
    }
}
