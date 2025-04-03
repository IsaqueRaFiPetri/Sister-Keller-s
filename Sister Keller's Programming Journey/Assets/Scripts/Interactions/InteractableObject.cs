using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class InteractableObject : MonoBehaviour
{
    protected abstract void Interact(); //Obriga o filho a implementar

    protected void Teste() //O filho tem acesso
    {

    }

    protected virtual void Teste1() //Permite o uso no filho, mas permite que seja sobrescrito
    {
        print("Executando");
    }
}