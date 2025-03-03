using UnityEngine;

public class WaterRise : MonoBehaviour
{
    [Header("Su Ayarlarý")]
    public float targetHeight = 2f; // Suyun ulaþacaðý maksimum yükseklik
    public float riseSpeed = 0.5f; // Su yükselme hýzý (birim/sn)

    private Vector3 startScale; // Su nesnesinin baþlangýç boyutu
    private Vector3 targetScale; // Su nesnesinin ulaþacaðý boyut

    void Start()
    {
        // Su nesnesinin baþlangýç boyutunu kaydet
        startScale = transform.localScale;

        // Hedef boyutu belirle
        targetScale = new Vector3(startScale.x, targetHeight, startScale.z);
    }

    void Update()
    {
        // Su nesnesini yavaþça hedef boyuta doðru ölçekle
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, riseSpeed * Time.deltaTime);
    }
}
