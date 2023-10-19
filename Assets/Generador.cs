using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject cuboPrefab;
    public GameObject esferaPrefab;
    public float minX = 0f;
    public float maxX = 10f;
    public float minY = 0f;
    public float maxY = 5f;
    public float minZ = 0f;
    public float maxZ = 10f;

    public int cantidadInicialCubos = 10;
    public int cantidadInicialEsferas = 10;

    private int cubosGenerados = 0;
    private int esferasGeneradas = 0;

    void Start()
    {
        // Genera la cantidad inicial de cubos y esferas al inicio
        GenerarObjetos("Cubo", cantidadInicialCubos);
        GenerarObjetos("Esfera", cantidadInicialEsferas);
    }

    public void GenerarObjetos(string tipo, int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            GenerarObjeto(tipo);
        }
    }

    public void GenerarObjeto(string tipo)
    {
        GameObject nuevoObjeto = null;

        if (tipo == "Cubo" && cubosGenerados < 100000)
        {
            nuevoObjeto = Instantiate(cuboPrefab, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), Quaternion.identity);
            nuevoObjeto.tag = "Cubo";
            cubosGenerados++;
        }
        else if (tipo == "Esfera" && esferasGeneradas < 100000)
        {
            nuevoObjeto = Instantiate(esferaPrefab, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), Quaternion.identity);
            nuevoObjeto.tag = "Esfera";
            esferasGeneradas++;
        }
    }
}
