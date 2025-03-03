using UnityEngine;

public class WaterRise : MonoBehaviour
{
    [Header("Su Ayarlar�")]
    public float targetHeight = 2f; // Suyun ula�aca�� maksimum y�kseklik
    public float riseSpeed = 0.5f; // Su y�kselme h�z� (birim/sn)

    private Vector3 startScale; // Su nesnesinin ba�lang�� boyutu
    private Vector3 targetScale; // Su nesnesinin ula�aca�� boyut

    void Start()
    {
        // Su nesnesinin ba�lang�� boyutunu kaydet
        startScale = transform.localScale;

        // Hedef boyutu belirle
        targetScale = new Vector3(startScale.x, targetHeight, startScale.z);
    }

    void Update()
    {
        // Su nesnesini yava��a hedef boyuta do�ru �l�ekle
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, riseSpeed * Time.deltaTime);
    }
}
