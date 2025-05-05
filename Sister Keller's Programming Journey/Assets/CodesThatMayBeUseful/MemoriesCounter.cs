using TMPro;
using UnityEngine;
public class MemoriesCounter : MonoBehaviour
{
    public static MemoriesCounter Instance;
    public TextMeshProUGUI memoriesCounter;
    public int memoriesCount;
    public Animator animator;
    public GameObject Exit, InimigoNormal, InimigoInv;

    public int Artifact = 5;

    public bool[] whatScene = new bool[3];

    private void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        memoriesCount = 0;
    }
    private void Update()
    {
        memoriesCounter.text = "Collect " + Artifact.ToString() + " Artifacts ";

         
             if (Artifact == 0) 
            {
                Exit.SetActive(true);
                memoriesCounter.text = "FIND the white door";
                InimigoNormal.SetActive(false);
                InimigoInv.SetActive(true);
            }
            animator.SetFloat("Artifacts", Artifact);

    }

}
