using TrenRezervasyon.Models;

namespace TrenRezervasyon.Services
{
    public class RezervasyonService
    {
        public RezervasyonResponse RezervasyonYap(RezervasyonRequest request)
        {
            var response = new RezervasyonResponse();
            int toplamRezervasyon = request.RezervasyonYapilacakKisiSayisi;

            foreach (var vagon in request.Tren.Vagonlar)
            {
                int bosKoltukSayisi = (int)(vagon.Kapasite * 0.7) - vagon.DoluKoltukAdet;

                if (bosKoltukSayisi > 0)
                {
                    if (toplamRezervasyon <= bosKoltukSayisi)
                    {
                        response.YerlesimAyrinti.Add(new YerlesimAyrinti { VagonAdi = vagon.Ad, KisiSayisi = toplamRezervasyon });
                        response.RezervasyonYapilabilir = true;
                        return response;
                    }
                    else if (request.KisilerFarkliVagonlaraYerlestirilebilir)
                    {
                        response.YerlesimAyrinti.Add(new YerlesimAyrinti { VagonAdi = vagon.Ad, KisiSayisi = bosKoltukSayisi });
                        toplamRezervasyon -= bosKoltukSayisi;
                    }
                }
            }

            if (toplamRezervasyon == 0)
            {
                response.RezervasyonYapilabilir = true;
            }

            return response;
        }
    }
}
