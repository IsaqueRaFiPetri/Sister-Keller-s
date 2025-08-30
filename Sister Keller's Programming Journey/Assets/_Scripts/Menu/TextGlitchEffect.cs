using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TextGlitchEffect : MonoBehaviour
{
    TMP_Text tmpText;
    Mesh mesh;
    Vector3[] vertices;

    [Header("Configura��o do Glitch")]
    [SerializeField] float minGlitchInterval = 0.2f;   // intervalo m�nimo entre glitches
    [SerializeField] float maxGlitchInterval = 1.5f;   // intervalo m�ximo
    [SerializeField] float minGlitchStrength = 1f;     // for�a m�nima
    [SerializeField] float maxGlitchStrength = 4f;     // for�a m�xima
    [SerializeField] float glitchDuration = 0.1f;      // quanto tempo dura o glitch
    [SerializeField] int lettersPerGlitch = 2;         // quantas letras bugam de cada vez

    void Awake()
    {
        tmpText = GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
        StartCoroutine(GlitchRoutine());
    }

    IEnumerator GlitchRoutine()
    {
        while (true)
        {
            // Espera intervalo aleat�rio antes de aplicar glitch
            float waitTime = Random.Range(minGlitchInterval, maxGlitchInterval);
            yield return new WaitForSeconds(waitTime);

            tmpText.ForceMeshUpdate();
            mesh = tmpText.mesh;
            vertices = mesh.vertices;

            TMP_TextInfo textInfo = tmpText.textInfo;

            // Define for�a aleat�ria para este glitch
            float glitchStrength = Random.Range(minGlitchStrength, maxGlitchStrength);

            // Escolhe letras aleat�rias
            for (int i = 0; i < lettersPerGlitch; i++)
            {
                int charIndex = Random.Range(0, textInfo.characterCount);
                if (!textInfo.characterInfo[charIndex].isVisible) continue;

                var charInfo = textInfo.characterInfo[charIndex];
                int vertexIndex = charInfo.vertexIndex;

                Vector3 glitchOffset = new Vector3(
                    Random.Range(-glitchStrength, glitchStrength),
                    Random.Range(-glitchStrength, glitchStrength),
                    0
                );

                // Move os v�rtices da letra
                for (int j = 0; j < 4; j++)
                {
                    vertices[vertexIndex + j] += glitchOffset;
                }
            }

            // Aplica mudan�a
            mesh.vertices = vertices;
            tmpText.canvasRenderer.SetMesh(mesh);

            // Espera o glitch acabar
            yield return new WaitForSeconds(glitchDuration);

            // Reatualiza para voltar ao normal
            tmpText.ForceMeshUpdate();
        }
    }
}
