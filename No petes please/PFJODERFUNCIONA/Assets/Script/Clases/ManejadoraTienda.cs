﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManejadoraTienda : MonoBehaviour
{
    public static int precio;
    public Canvas tienda;
    public Text texto;
    public Text descrip;
    public static string descripTexto;
    public Image imagenEspada;
    public GameObject espadaMedia;
    public GameObject espadaMediaLegendaria;
    public Text daño;
    public Text descripEspadas;
    public Text golpesArmadura;
    public GameObject CascoArmaduraMedia;
    public GameObject PechoArmaduraMedia;
    public GameObject PiernasArmaduraMedia;
    public Image cascoMedia;
    public Image torsoMedia;
    public Image piernasMedia;

    public static int golpesMedia;
    public static int golpesBasica;
    public static int golpesLegendaria;

    public GameObject cascoArmaduraRoto;
    public GameObject torsoArmaduraRoto;
    public GameObject piernasArmaduraRoto;


    private void Start()
    {
        golpesMedia = ConstantesArmaduras.golpesAguantaArmaduraMedia;
        golpesBasica = ConstantesArmaduras.golpesAguantaArmaduraBasica;
        golpesLegendaria = ConstantesArmaduras.golpesAguantaArmaduraLegendaria;
    }
    // Start is called before the first frame update
    public void cancelarCompra()
    {
        tienda.enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento>().velocidad = 6;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
    public void comprarObjeto()
    {

        if (tienda.isActiveAndEnabled) {

            int dineroActual = ScorePoint.puntos;

            switch (ActivacionTienda.tagObjetoCocado)
            {
                case "salud":
                    if (dineroActual >= ConstantesTeinda.PRECIOSALUD)
                    {
                        ControladorSalud.aumentarVidaPorCompra();
                        GetComponent<AudioSource>().Play();
                        cancelarCompra();
                        GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento>().velocidad = 6;
                        ScorePoint.puntos -= ConstantesTeinda.PRECIOSALUD;
                    }
                    else
                    {

                        GameObject.FindGameObjectWithTag("sound").GetComponent<AudioSource>().Play();
                    }
                    break;

                case "mana":
                    if (dineroActual >= ConstantesTeinda.PRECIOMANA)
                    {
                        ControladorSalud.recargarMana();
                        GetComponent<AudioSource>().Play();
                        cancelarCompra();
                        GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento>().velocidad = 6;
                        ScorePoint.puntos -= ConstantesTeinda.PRECIOMANA;
                    }
                    else
                    {
                        GameObject.FindGameObjectWithTag("sound").GetComponent<AudioSource>().Play();
                    }
                    break;

                case "espadaMedia":

                    if (dineroActual >= ConstantesTeinda.PRECIOESPADAMEDIA)
                    {
                        imagenEspada.sprite = espadaMedia.GetComponent<SpriteRenderer>().sprite;
                        daño.text = ConstantesEspadas.DANIOESPADAMEDIA.ToString();
                        descripEspadas.text = ConstantesEspadas.DESCRIPESPADAMEDIA;
                        GetComponent<AudioSource>().Play();
                        cancelarCompra();
                        GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento>().velocidad = 6;
                        ScorePoint.puntos -= ConstantesTeinda.PRECIOESPADAMEDIA;
                        AtributosJugador.espadaEquipada = "espadaMedia";
                    }
                    else
                    {
                        GameObject.FindGameObjectWithTag("sound").GetComponent<AudioSource>().Play();
                    }
                    break;

                case "espadaLegendaria":

                    if (dineroActual >= ConstantesTeinda.PRECIOESPALEGENDARIA)
                    {
                        imagenEspada.sprite = espadaMediaLegendaria.GetComponent<SpriteRenderer>().sprite;
                        daño.text = ConstantesEspadas.DANIOESPADALEGENDARIA.ToString();
                        descripEspadas.text = ConstantesEspadas.DESCRIPESPADALEGENDARIA;
                        GetComponent<AudioSource>().Play();
                        cancelarCompra();
                        GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento>().velocidad = 6;
                        ScorePoint.puntos -= ConstantesTeinda.PRECIOESPALEGENDARIA;
                        AtributosJugador.espadaEquipada = "espadaLegendaria";
                    }
                    else
                    {
                        GameObject.FindGameObjectWithTag("sound").GetComponent<AudioSource>().Play();
                    }
                    break;

                case "armaduraMedia":

                    if (dineroActual >= ConstantesTeinda.PRECIOARMADURAMEDIA)
                    {
                        cascoMedia.sprite = CascoArmaduraMedia.GetComponent<SpriteRenderer>().sprite;
                        torsoMedia.sprite = PechoArmaduraMedia.GetComponent<SpriteRenderer>().sprite;
                        piernasMedia.sprite = PiernasArmaduraMedia.GetComponent<SpriteRenderer>().sprite;
                        golpesArmadura.text = ConstantesArmaduras.golpesAguantaArmaduraMedia.ToString();
                        GetComponent<AudioSource>().Play();
                        cancelarCompra();
                        GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento>().velocidad = 6;
                        ScorePoint.puntos -= ConstantesTeinda.PRECIOARMADURAMEDIA;
                        AtributosJugador.armaduraEquipada = "armaduraMedia";


                    }
                    else
                    {
                        GameObject.FindGameObjectWithTag("sound").GetComponent<AudioSource>().Play();
                    }



                    break;
                default:
                    break;
            }
        }
     
           
    }

    private void Update()
    {
      
            texto.text = precio.ToString() + " $$$";
            descrip.text = descripTexto;

            switch (AtributosJugador.armaduraEquipada) {

                case "armaduraBasica":
                    golpesArmadura.text = golpesBasica.ToString();
                    if (golpesBasica < 0) {
                    golpesArmadura.text = 0.ToString();
                    cascoMedia.sprite = cascoArmaduraRoto.GetComponent<SpriteRenderer>().sprite;
                    torsoMedia.sprite = cascoArmaduraRoto.GetComponent<SpriteRenderer>().sprite;
                    piernasMedia.sprite = cascoArmaduraRoto.GetComponent<SpriteRenderer>().sprite;
                    AtributosJugador.armaduraEquipada = "sinArmadura";
                    golpesBasica = ConstantesArmaduras.golpesAguantaArmaduraBasica;

                }
                    break;

                case "armaduraMedia":
                    golpesArmadura.text = golpesMedia.ToString();
                    if (golpesMedia < 0) {
                    golpesArmadura.text = 0.ToString();
                    cascoMedia.sprite = cascoArmaduraRoto.GetComponent<SpriteRenderer>().sprite;
                    torsoMedia.sprite = cascoArmaduraRoto.GetComponent<SpriteRenderer>().sprite;
                    piernasMedia.sprite = cascoArmaduraRoto.GetComponent<SpriteRenderer>().sprite;
                    AtributosJugador.armaduraEquipada = "sinArmadura";
                    golpesMedia = ConstantesArmaduras.golpesAguantaArmaduraMedia;
                }
                    break;

               
            }
       
    }
}
