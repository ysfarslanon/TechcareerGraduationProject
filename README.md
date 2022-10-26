# Techcareer .Net Core Backend Bootcamp 3 Bitirme projesi

Techcareer tarafından verilen proje isterlerinin [ayrıntıları](https://github.com/ysfarslanon/TechcareerGraduationProject/blob/main/Images/Proje%20tan%C4%B1m%C4%B1.pdf)

## Proje amacı
Kullanıcıların alışveriş süreçlerini kolaylaştırmak adına almayı planladıkları ürünlerin listelerini ve bu listelerin takibini yapabilmek için oluşturulmuştur.

## Kurulum
Proje kurulumu Backend ve Frontend olarak ikiye ayırılmıştır. Her iki parçanın da kurulum ayrıntıları kendi klasörlerinde anlatılmıştır.
1. Projeyi Sağ üstte yeşil renkli butona tıklayıp *Download ZIP* seçeneği ile indiriniz ve klasöre çıkartınız.
2. Veya boş bir klasör oluşturup terminalde oluşturduğunuz klasöre yerleşin ve aşağıdaki komutu çalıştırın
```
git clone https://github.com/ysfarslanon/TechcareerGraduationProject.git
``` 
- [Backend kurulumu için](https://github.com/ysfarslanon/TechcareerGraduationProject/tree/main/TechcareerShoppingTracking)
- [Frontend kurulumu için](https://github.com/ysfarslanon/TechcareerGraduationProject/tree/main/AngularShoppingList)

## Bilgilendirme
Bu proje [Backend(.Net 6 (API))](https://github.com/ysfarslanon/TechcareerGraduationProject/tree/main/TechcareerShoppingTracking) ve [Frontend(Angular)](https://github.com/ysfarslanon/TechcareerGraduationProject/tree/main/AngularShoppingList) olarak iki kısımdan oluşmaktadır. İki alanda da kullanılan teknolojiler kendi klasörlerinde belirtilmiştir. Veri tabanı olarak MSSQL kullanılmıştır. Veri tabanı [tasarımı](https://raw.githubusercontent.com/ysfarslanon/TechcareerGraduationProject/main/Images/Db-Diagram.png)

## Uygulama yetenekleri
- Uygulamada iki adet rol vardır. Bunlar Admin ve Normal olarak adlandırılmıştır. Her rol kendilerine tanımlanan API tarafında enpoint'lere ve UI tarafında sayfalara erişim imkanı vardır. Örneğin ürün ekleme/güncelleme sayfasına normal rolüne sahip kullanıcı(lar) erişim sağlayamaz. Alışveriş listesi ekleme/güncelleme/listeleme sayfasına admin rolüne sahip kullanıcı(lar) erişim sağlayamaz. 
- Kullanıcı sisteme giriş yapmadan herhangi bir işlem yapamamaktadır. Sisteme giriş kayıt olurken verilen email ve şifre ile giriş yapılmalıdır.
- Kullanıcılar kayıt olurken Ad, Soyad, Email, Şifre ve Şifre Tekrarı olanlarını doldurması ve bu alanların VALID olması gerekmektedir. Kullanıcı kayıt olurken otamatik olarak Normal rolüne sahip olmaktadır.
  - Ad: En az 2 karakter olmalıdır.
  - Soyad: En az 2 karakter olmalıdır.
  - Email: Email formatında olmalıdır. Sistemde var olan bir email kullanılamaz.
  - Şifre: En az 8 karakter olmalıdır. En az bir adet büyük harf olmalıdır. En az bir adet küçük harf olmalıdır. En az bir adet rakam olmalıdır.
  - Şifre tekrarı: Şifre ile aynı olmalıdır.
- Admin rolüne sahip kullanıcı sisteme Kategori ekleme/güncelleme/silme yetkisine sahiptir.
  - Kategori ekleme/güncelleme kuralları
  - Kategori ismi: En az 2 karakter olmalıdır. Sistemde var olan kategori ismi olamaz.
- Admin rolüne sahip kullanıcı sisteme Ürün ekleme/güncelleme/silme yetkisine sahiptir.
  - Ürün güncellerken ürün adına ve kategorisine göre filitreleme yapabilirler.
  - Ürün ekleme/güncelleme kuralları
  - Ürün ismi: En az 2 karakter olmalıdır. Sistemde var olan ürün adı olamaz.
  - Ürün kategorisi: Sistemde var olan bir kategoride olmak zorundadır. Bir ürünün sadece bir adet kategorisi olabilir.
  - Ürün resmi: Boş bırakılamaz. Bir ürünün sadece bir adet resmi olabilir.
- Sistemde var olan Admin bilgisi: Email:admin@admin.com Şifre: TechCareer42

- Normal rolüne sahip kullanıcılar istedikleri kadar alışveriş listesi oluşturabilir/güncelleyebilir/silebilirler.
  - Alışveriş listesi olutururken/güncellerken alışveriş listesi ismi girmek zorundadır ve bu isim önceki alışveriş listelerinin adıyla aynı olamaz.
  - Alışveriş listesinde Alışverişe çıkdım olarak işaretlenirse bu listeye bir ürün eklenemez/güncellenemez/silinemez.
  - Alışveriş listesinde Alışverişi tamamladım seçeneği işaretlenirse bu listeye ürün eklenebilir/güncellenemebilir/silinebilir.
  - Alışveriş listesine ürün eklerken istelerse ürün ismine göre filitreleyebilirler.
  - Alışveriş listesine ürün eklerken istelerse ürün kategorisine göre filitreleyebilirler.
  - Alışveriş listelerine sistemde var olan ürünleri ekleyebilir ve isterlerse açıklama/not girebilirler.
  - Alışveriş listesinde yer alan ürünleri aldım olarak işaretleyebilirler.
  - Alışveriş listesinde yer alan ürünlerin açıklamalarını güncelleyebilirler.
  - Alışveriş listesinde yer alan ürünleri silebilirler.
- Sistemde var olan Normal bilgisi: 
  - Email:14arslan.yusuf@gmail.com Şifre:TechCareer42
  - Email:tech@career.com Şifre:TechCareer42
  
## Veri tabanı tasarımı
![Db](https://raw.githubusercontent.com/ysfarslanon/TechcareerGraduationProject/main/Images/Db-Diagram.png)
