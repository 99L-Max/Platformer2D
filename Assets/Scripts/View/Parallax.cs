using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Parallax : MonoBehaviour
{
    private Material _material;
    private float _distance;

    public float Speed { get; set; }

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        _distance += Time.deltaTime * Speed;
        _material.SetTextureOffset("_MainTex", Vector2.right * _distance);
    }
}
