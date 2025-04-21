const sessionTimeoutMinutes = 20;
const warningBeforeMinutes = 1;

const timeoutInMs = sessionTimeoutMinutes * 60 * 1000;
const warningTime = timeoutInMs - (warningBeforeMinutes * 60 * 1000);

let countdownInterval;
let remainingSeconds = sessionStorage.getItem('remainingSeconds') || warningBeforeMinutes * 60; // sessionStorage'dan geri sayım süresini al

// Uyarı modalını gösterme fonksiyonu
function showSessionWarningModal() {
    const modal = new bootstrap.Modal(document.getElementById('sessionWarningModal'));
    modal.show();

    const countdownText = document.getElementById('countdownText');
    countdownText.innerText = `${remainingSeconds} saniye kaldı`;

    countdownInterval = setInterval(() => {
        remainingSeconds--; // Kalan süreyi bir saniye azalt

        countdownText.innerText = `${remainingSeconds} saniye kaldı`;
        console.log("Kalan süre:", remainingSeconds);

        // Kalan süre sıfıra yaklaşırsa
        if (remainingSeconds <= 0) {
            clearInterval(countdownInterval); // Geri sayım durdurulacak
            window.location.href = "/Login/WriterLogin"; // Oturum sona erdi, login sayfasına yönlendir
        }

        // Geri sayım güncel süresini sessionStorage'a kaydediyoruz
        sessionStorage.setItem('remainingSeconds', remainingSeconds);

    }, 1000);
}

// Oturumu uzatma butonuna tıklama işlemi
function refreshSession() {
    fetch('/Login/KeepAlive') // KeepAlive action'ı ile session süresi uzatılabilir
        .then(() => {
            clearInterval(countdownInterval); // Geri sayımı temizle
            remainingSeconds = sessionTimeoutMinutes * 60; // Oturum süresi sıfırlanır
            sessionStorage.removeItem('remainingSeconds'); // sessionStorage'dan geri sayım verisini kaldır
            location.reload(); // Sayfayı yeniden yükle
        });
}

// Sayfa başlatıldığında geri sayımı başlatma
function initSessionWarning() {
    // Eğer sessionStorage'da bir geri sayım süresi varsa, mevcut süreyi kullan
    if (!sessionStorage.getItem('remainingSeconds')) {
        setTimeout(showSessionWarningModal, warningTime);
    } else {
        showSessionWarningModal(); // Eğer zaten uyarı gösteriliyorsa, direkt olarak başlat
    }
}

// Sayfa yüklendiğinde sessionWarning'ı başlat
initSessionWarning();
