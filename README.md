## BookStore

Bu proje, temel bir e-ticaret sistemini simüle eden bir kitap mağazası uygulamasıdır. Uygulama, hem sunucu (backend) hem de istemci (frontend) bileşenlerini içerir ve kitap satış işlemlerini gerçekleştirmek için gerekli demo altyapı sağlar.

### BookStoreServer
Sunucu tarafı uygulaması, kitap verilerini yönetmek, siparişleri işlemek ve kullanıcı hesaplarıyla ilgili işlemleri gerçekleştirmek için tasarlanmıştır. API servisleri aracılığıyla istemci tarafı uygulamayla iletişim kurar.

#### Kullanılan Kütüphaneler:
- **AutoMapper**
- **Entity Framework Core**
- **Iyzipay**
- **Microsoft.AspNetCore.Authentication.JwtBearer**
- **GenericEmailService**

### BookStoreClient
İstemci tarafı uygulaması, kullanıcıların kitapları görüntüleyebileceği, sepete ekleyebileceği ve satın alabileceği kullanıcı arayüzünü sunar. Sunucudan gelen verileri alır ve kullanıcıya sunar.

Bu proje, e-ticaret sistemlerinin temel işleyişini öğrenmek ve geliştirmek için iyi bir başlangıç noktasıdır.
