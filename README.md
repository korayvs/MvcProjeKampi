# **MVC PROJECT CAMP**
Bu proje, Murat Yücedağ tarafından YouTube üzerinde ücretsiz olarak sunulan MVC Proje Kampı eğitim serisi kapsamında geliştirilmiştir. Eğitim sürecinde öğrenilen teknik ve kavramlar, gerçek hayata uygulanabilir bir sözlük sistemi projesiyle pekiştirilmiştir.
MVC Sözlük uygulaması, kullanıcıların farklı rollerle giriş yapabildiği, çok katmanlı mimariyle tasarlanmış bir platformdur. Sistemde üç temel kullanıcı rolü bulunmaktadır:
- Vitrin (Genel Kullanıcı Arayüzü): Vitrin sayfası, tüm kullanıcılara açık olup, sol kısımdaki menü (Sidebar) üzerinden tüm başlıklara erişim sağlanabilir. Kullanıcılar, başlıklar altında yer alan yazarların entry'lerini detaylı şekilde görüntüleyebilir.
- Yazar: Giriş yaptıktan sonra kendi kontrol panelinden içerik üretme ve düzenleme işlemleri gerçekleştirebilir.
- Admin: Tüm sistemi yönetme yetkisine sahiptir. Paneli üzerinden tüm verilere ve işlemlere erişebilir.
## Kullanılan Teknolojiler ve Mimariler
- Katmanlı Mimari (N-Tier Architecture): Business, DataAccess, Entity, UI olmak üzere dört temel katmandan oluşur.
- OOP (Nesne Yönelimli Programlama)
- Generic Repository Pattern ile veri erişim soyutlaması
- Authentication & Authorization mekanizmaları
- Code First yaklaşımıyla veritabanı yönetimi
- Entity Framework ve Fluent Validation ile model ve veri doğrulama işlemleri
- ASP.NET Core Identity ile kullanıcı yönetimi
- Session kullanımıyla kullanıcı bilgisi takibi
- Bootstrap ile modern arayüz tasarımı
- JavaScript ile etkileşimli sayfa elemanları
- Data Annotations kullanarak istemci tarafı (front-end) doğrulamalar
- LINQ sorguları ile etkili veri işleme
- PagedList ile sayfalama (pagination) işlemleri
- Entity State komutlarıyla nesne durum yönetimi
- Add-Migration komutu ile veritabanı güncellemeleri
- Özel hata sayfası (404 Error Page) tasarımı
- Session Allow Anonymous
- SOLID prensiplerine uygun yazılım mimarisi ve kodlama standartları
