using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float totalTime = 300f; // Toplam süre (5 dakika)
    private float currentTime; // Mevcut geçen süre

    public Text timerText; // UI'da süreyi göstermek için Text elemanı

    private void Update()
    {
        currentTime += Time.deltaTime; // Geçen süreyi güncelle

        // Zaman aşımını kontrol et
        if (currentTime >= totalTime)
        {
            // Zaman dolduğunda yapılması gereken işlemleri burada gerçekleştirebilirsiniz.
            // Örneğin, oyunu durdurabilir veya sonuçları değerlendirebilirsiniz.
        }

        UpdateTimerUI(); // Zamanlayıcıyı güncellemek için UI elemanını güncelle
    }

    public void StartTimer()
    {
        currentTime = 0f; // Geçen süreyi sıfırla
    }

    private void UpdateTimerUI()
{
    float remainingTime = totalTime - currentTime; // Kalan süreyi hesapla

    int minutes = Mathf.FloorToInt(remainingTime / 60f); // Kalan süreden dakikaları al
    int seconds = Mathf.FloorToInt(remainingTime % 60f); // Kalan süreden saniyeleri al

    // Kalan süreyi kullanıcı arayüzünde göstermek için güncelleme yap
    timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Dakika ve saniye formatını kullanarak süreyi Text elemanına gönder
}

}

