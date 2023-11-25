Proje Tanımı;
 - Kütüphaneden boşta olan kitapları yeni birisine teslim alan ve tekrar teslim edilen bir uygulama.
 - Hafta sonu ve resmi tatiller hariç 15 gün sonunda teslim edilme zorunluluğu
 - 15 günü geçirmesi halinde ceza ücreti.

Proje kullanımı;
Proje 3 sayfadan oluşmakta;
-	Ana sayfa ; tüm kitaplar ve durumları listelenir.
-	CheckOut; kitap yeni sahibine devredilir.
- 	Checkin; kitap tekrar teslim alınır.

Sql migrations işlemleri için izlenmesi gerekilen komutlar;

dotnet tool install --global dotnet-ef --version 7.*
dotnet ef migrations add InitialCreate_New
dotnet ef database update
