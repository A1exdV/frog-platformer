using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private FrogController controller;

    [SerializeField] private int takeTime;

    private void OnCollisionEnter2D(Collision2D col)
    {
         var other = col.gameObject;
         if (other.CompareTag("Spike"))
         {
             var contact = col.GetContact(0);

             timer.TakeTime(takeTime);
             controller.GetDamage(contact.point);
         }
    }
}
