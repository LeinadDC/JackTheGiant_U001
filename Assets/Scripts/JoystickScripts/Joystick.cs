﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
    private PlayerJoystick playerMove;

    void Awake()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerJoystick>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(gameObject.name == "Left")
        {
            playerMove.SetMoveLeft(true);
        }
        else
        {
            playerMove.SetMoveLeft(false);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerMove.StopMoving();
    }

}
