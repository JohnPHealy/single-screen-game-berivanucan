﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    public float speed = 6;

    public bool canClimb = false;
    public bool bottomLadder = false;
    public bool topLadder = false;

    private void ClimbMovement()
    {
        if (canClimb && Mathf.Abs(Input.GetAxis("Verical")) > .1f)
        {

        }
    }

}
