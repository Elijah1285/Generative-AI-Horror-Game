using UnityEngine;

[ExecuteInEditMode]
public class DynamicTextureTiling : MonoBehaviour
{
    [SerializeField] Vector2 material_tiling_multiplier;

    // Reference to the original material with the texture
     Material originalMaterial;

    void Start()
    {
        // Ensure we have a material
        originalMaterial = GetComponent<Renderer>().material;

        // Create a new material instance for this object
        Material materialInstance = new Material(originalMaterial);

        // Apply the new material to the object
        GetComponent<Renderer>().material = materialInstance;

        // Get the initial scale of the object
        Vector3 initialScale = transform.localScale;

        // Set the texture tiling based on the initial scale
        SetTextureTiling(materialInstance, initialScale);
    }

    void Update()
    {
        // Adjust texture tiling based on the current scale
        SetTextureTiling(GetComponent<Renderer>().material, new Vector3(1.0f, transform.localScale.y * material_tiling_multiplier.y, transform.localScale.z * material_tiling_multiplier.x));
    }

    void SetTextureTiling(Material material, Vector3 scale)
    {
        // Calculate tiling based on the scale
        Vector2 tiling = new Vector2(scale.z, scale.y);

        // Apply tiling to the material
        material.mainTextureScale = tiling;
    }
}
