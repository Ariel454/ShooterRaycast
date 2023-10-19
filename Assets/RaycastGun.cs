using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(LineRenderer))]
public class RaycastGun : MonoBehaviour
{
    public Camera playerCamera;
    public Transform laserOrigin;
    public TMPro.TextMeshProUGUI contadorTexto;
    public float gunRange = 50f;
    public float fireRate = 0.2f;
    public float laserDuration = 0.05f;
    private int shotsHit = 0;
    private int cubosDestruidos = 0;
    private int esferasDestruidas = 0;
    private string textoContador;


    LineRenderer laserLine;
    float fireTimer;
 
    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }
 
    void Update()
    {
        fireTimer += Time.deltaTime;
        if(Input.GetButtonDown("Fire1") && fireTimer > fireRate)
        {
            fireTimer = 0;
            laserLine.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
            {
                laserLine.SetPosition(1, hit.point);

                // Comprueba si el objeto impactado tiene la etiqueta "Terreno"
                if (hit.transform.CompareTag("Terreno"))
                {
                    // Ignora el terreno y no hace nada
                }
                else if (hit.transform.CompareTag("Cubo"))
                {
                    // Si es un cubo, se destruye con 2 disparos
                    shotsHit++;
                    if (shotsHit >= 2)
                    {
                        Destroy(hit.transform.gameObject);
                        shotsHit = 0;
                            cubosDestruidos++;
                    }
                }
                else if (hit.transform.CompareTag("Esfera"))
                {
                    // Si es una esfera, se destruye con 3 disparos
                    shotsHit++;
                    if (shotsHit >= 3)
                    {
                        Destroy(hit.transform.gameObject);
                        shotsHit = 0;
                            esferasDestruidas++;
                    }
                }
                else
                {
                    // Si no tiene ninguna etiqueta, se destruye con 1 disparo
                    shotsHit++;
                    if (shotsHit >= 1)
                    {
                        Destroy(hit.transform.gameObject);
                        shotsHit = 0;
                    }
                }
                textoContador = "Cubos destruidos: " + cubosDestruidos + "\nEsferas destruidas: " + esferasDestruidas;
                contadorTexto.text = textoContador;
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
            }
            StartCoroutine(ShootLaser());
        }
    }
 
    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
}