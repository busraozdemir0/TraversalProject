# Traversal Rezervasyon Projesi
## Projenin Genel Amacı
###
Traversal Rezervasyon Projesi; Kullanıcıların, admin kullanıcısının oluşturmuş olduğu gezi turlarını görüntüleyebilme ve bu turlara rezervasyon yapabilme imkanı sunan web uygulamasıdır. Kullanıcılar, site üzerinden çeşitli gezi turlarını inceleyebilir, tur detaylarını öğrenebilir ve tercih ettikleri turlara rezervasyon yaptırabilirler. 

Asp.Net Core MVC 5.0 kullanılarak geliştirilen bu uygulamada, Entity Framework Code First yaklaşımı kullanılmaktadır. N katmanlı mimari yapısı kullanılarak CRUD (Create, Read, Update, Delete) işlemleri daha etkili ve basit bir şekilde gerçekleştirilmektedir.
###

# Kullanılan Teknolojiler
- Asp.Net Core 5.0
- Entity Framework Code First
- MSSQL Server
- LINQ
- Rapid API
- AJAX
- Html
- Css
- Bootstrap
- Fluent Validation
- Identity
- MailKit
- AutoMapper
- CQRS Design Pattern
- Mediatr
- SignalR

# Teknik Özellikler
- N Katmanlı Mimari Yapısı
- Repository Tasarım Deseni
- CQRS Tasarım Deseni
- PagedList ile sayfalama yapısı
- Fluent Validation ile doğrulama
- Identity ile kullanıcı ve rol işlemleri
  
# Sitenin Öne Çıkan Özellikleri
- Üye Paneli ve Admin Paneli
- Identity kütüphanesi ile giriş yapma özelliği.
- Rolleme ve yetkilendirme ile erişim kısıtlamaları
- FluentValidation kütüphanesi yardımıyla doğrulamalar
- AJAX ile CRUD işlemler
- MailKit ile Mesajlaşma özelliği
- PagedList ile sayfalama yapısı
- Ana Sayfadaki bloglara yorum yapma, beğeni yapma
- Panellerde ilgili CRUD işlemleri
- Panellerde Profil ayarları sayfaları
- Şifremi Unuttum özelliği
- Kullanıcılara roller atama, silme ve güncelleme
- Üye panelinde çoklu dil desteği
- Arama işlemleri

# Admin Paneli Özellikleri
- İstatistikleri görme
- Profil düzenleme işlemleri
- Tüm turlar üzerinde CRUD işlemleri
- Rezervasyonları görüntüleme ve takip etme
- Site üzerindeki tüm yorumları görüntüleme
- Kullanıcıları görüntüleme
- Rehberler üzerinde CRUD işlemleri ve Aktif Pasif yapma özelliği
- Mesajlaşma sistemi
- Raporlamalar
- Mail gönderme
- AJAX ile tur üzerinde CRUD işlemler
- Apiler
- Site üzerindeki verilerde CRUD işlemleri
- Rolleme yapma

# Üye Paneli Özellikleri
- İstatistikleri görme
- Profil düzenleme işlemleri
- Aktif rota-gezileri görme ve rezervasyon oluşturma
- Onay bekleyen rezervasyonları görüntüleme
- Geçmiş rezervasyonları görüntüleme
- Menülerde çoklu dil desteği

# Sitenin Görselleri

### Ana Sayfa 
![Ana ekran](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/home1.png)

![Ana ekran2](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/home2.png)

![Ana ekran3](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/home3.png)


### Footer
![Ana ekran3](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/footer.png)


### Tur Rotaları Sayfası - Giriş/Çıkış/Kayıt Ol Menüsü
![Tur Rotaları](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/tourRoutes_logoutMenu.png)


### Tur'lara Yorum Yapma
![Tur Rotaları2](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/turaYorumYapmaİşlemi.png)


### Rehberler Sayfası
![Guides](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/guides.png)


### Hakkımızda Sayfası
![İletişim](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/hakkımızda.png)


### İletişim Sayfası
![İletişim](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/contact.png)


### Kayıt Ol Ekranı
![Kayıt Ol](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/register.png)


### Giriş Yap Ekranı
![Giriş Yap](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/login.png)


### Üye Paneli - Dashboard
![Member1](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/memberDashboard.png)


### Üye Paneli - Profil Bilgileri Güncelleme
![Member2](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/profileUpdatePage.png)

 
### Üye Paneli - Yeni Rezervasyon Oluşturma
![Member2](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/newReservation.png)


### Üye Paneli - Oluşturulan Son 4 Tur
![Member3](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/last4Tour.png)


### Üye Paneli - Dil Desteği Menüsü
Dil seçildiğinde sidebar(sol menü) dile göre değişkenlik gösteriyor.
![Member4](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/languageMenu.png)


### Admin Paneli - Dashboard
![Admin1](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/adminDashboard.png)


### Admin Paneli - Duyuru Oluşturma Sayfası
![Admin2](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/admin_newAnnouncement.png)


### Admin Paneli - Oluşturulan Rezervasyonlar Sayfası
![Admin6](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/adminReservation.png)


### Admin Paneli - Gelen Mesajlar Sayfası
![Admin3](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/adminMessages.png)


### Admin Paneli - Mail Gönderme Sayfası
![Admin4](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/adminMailSubmit.png)


### Admin Paneli - Rolleme İşlemleri
![Admin5](https://github.com/busraozdemir0/TraversalProject/blob/master/TraversalProject/wwwroot/TraversalScreenshots/adminRoles.png)












