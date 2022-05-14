using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private FrogController controller;


    private void OnCollisionEnter2D(Collision2D col)
    {
         var other = col.gameObject;
         if (other.CompareTag("Spike"))
         {
             var contact = col.GetContact(0);

             timer.TakeTime(5);
             controller.GetDamage(contact.point);
         }
    }
}
