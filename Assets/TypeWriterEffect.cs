using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeWriterEffect : MonoBehaviour
{
    public float delay = 0.1f; // La velocidad de aparición del texto
    public string fullText; // El texto completo que se va a mostrar
    private string currentText = ""; // El texto que se va a ir mostrando
    private TMP_Text textMesh; // La referencia al componente TMP_Text

    private void Awake()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    private IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i + 1);
            textMesh.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }

    private void OnEnable()
    {
        currentText = "";
        StartCoroutine(ShowText());
    }
}