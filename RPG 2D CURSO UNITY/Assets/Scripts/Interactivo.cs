﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Interactivo : MonoBehaviour,IPointerDownHandler {

    private Collider2D micolisionador;
    public UnityEvent OnInteraccion;
    private PlayerController player;
    

    private void Start()
    {
        micolisionador = GetComponent<Collider2D>();
        player = GameManager.instance.jugador.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnInteraccion.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Haciendo Click!!");
        Interactuar();
    }

    private void Interactuar()
    {
        foreach (RaycastHit2D interactivo in player.Interactuar())
        {
            if (interactivo.collider.gameObject==gameObject)
            {
                Interaccion();
            }
        }
    }

    public virtual void Interaccion()
    {
        Debug.Log("Interactuó con "+gameObject.name);
    }
}
