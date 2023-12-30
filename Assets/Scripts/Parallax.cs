using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshrenderrer;
    public  float animationSpeed = 1f;

    private void Awake()
    {
        meshrenderrer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        meshrenderrer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
