using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TimerController : MonoBehaviour
{
    public float totalTime = 300f; // Toplam süre (5 dakika)
    private float currentTime; // Mevcut geçen süre

    public Text timerText; // UI'da süreyi göstermek için Text elemanı

    private bool isTimerRunning; // Timer'ın çalışıp çalışmadığını kontrol etmek için bool değişkeni
    internal static object instance;

    private void Start()
    {
        currentTime = 0f; // Geçen süreyi sıfırla
        isTimerRunning = true; // Timer'ı başlat
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            currentTime += Time.deltaTime; // Geçen süreyi güncelle

            // Zaman aşımını kontrol et
            if (currentTime >= totalTime)
            {
                // Zaman dolduğunda yapılması gereken işlemleri burada gerçekleştirebilirsiniz.
                // Örneğin, oyunu durdurabilir veya sonuçları değerlendirebilirsiniz.
                isTimerRunning = false; // Timer'ı durdur
                SceneManager.LoadScene(2); // Ana menü sahnesine geçiş yap
            }

            UpdateTimerUI(); // Zamanlayıcıyı güncellemek için UI elemanını güncelle
        }
    }

    private void UpdateTimerUI()
    {
        float remainingTime = totalTime - currentTime; // Kalan süreyi hesapla

        int minutes = Mathf.FloorToInt(remainingTime / 60f); // Kalan süreden dakikaları al
        int seconds = Mathf.FloorToInt(remainingTime % 60f); // Kalan süreden saniyeleri al

        // Kalan süreyi kullanıcı arayüzünde göstermek için güncelleme yap
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Dakika ve saniye formatını kullanarak süreyi Text elemanına gönder

        if (remainingTime <= 0f)
        {
            isTimerRunning = false; // Timer'ı durdur
            timerText.text = "00:00"; // Süre dolunca ekranda 00:00 göster
            SceneManager.LoadScene(2); // Ana menü sahnesine geçiş yap
        }
    }
    


}
