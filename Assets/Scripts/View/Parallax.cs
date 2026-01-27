using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Parallax : MonoBehaviour
{
    private const string TextureName = "_MainTex";

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
        _material.SetTextureOffset(TextureName, Vector2.right * _distance);
    }
}
