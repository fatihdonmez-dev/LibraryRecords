namespace LibraryRecords
{
    public static class Helper
    {
        public static DateTime DateAdd(DateTime startDate, int dayCount)
        {
            DateTime yeniTarih = startDate;
            int eklenenGunSayisi = 0;

            while (eklenenGunSayisi < dayCount)
            {
                yeniTarih = yeniTarih.AddDays(1);

                // Hafta sonu (Cumartesi veya Pazar) kontrolü
                if (yeniTarih.DayOfWeek == DayOfWeek.Saturday || yeniTarih.DayOfWeek == DayOfWeek.Sunday)
                    continue;

                if (ResmiTatilKontrolu(yeniTarih))
                    continue;

                eklenenGunSayisi++;
            }

            return yeniTarih;
        }

        static bool ResmiTatilKontrolu(DateTime tarih)
        {
            // Bu kısımda resmi tatil kontrolü yapabilirsiniz.
            // sabit bir tatil listesi veya başka bir kaynaktan alınan tatil bilgileri kullanılabilir.
            // Bu örnekte, herhangi bir resmi tatil olmadığını varsayıyoruz.
            return false;
        }
    }
}
