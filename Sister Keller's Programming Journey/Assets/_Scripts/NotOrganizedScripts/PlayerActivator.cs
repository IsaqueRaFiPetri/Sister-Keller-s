using UnityEngine;

public class PlayerActivator : MonoBehaviour
{
    void Start()
    {
        var player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.SetActive(true); // Reativa o jogador caso ele tenha sido desativado
        }
    }
}
