using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models
{
    public class ReservatieManager
    {
        private IUnitOfWork uow;

        public ReservatieManager(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public string GetReservatieSummary()
        {

            return "";
        }

        public string GetReservatieInfo(Reservatie reservatie)
        {
            StringBuilder sb = new StringBuilder();

            Klant klant = uow.Klanten.GetKlant(reservatie.KlantId);
            sb.Append("Klant ID: ");
            sb.Append(klant.Id);
            sb.Append(Environment.NewLine);
            sb.Append("Klant naam: ");
            sb.Append(klant.Naam);
            sb.Append(Environment.NewLine);
            sb.Append("Klant categorie: ");
            sb.Append(klant.KlantCategorie);
            sb.Append(Environment.NewLine);
            sb.Append("Klant adres: ");
            sb.Append(klant.WoonAdres);
            sb.Append(Environment.NewLine);
            sb.Append("Klant BTW-nummer: ");
            sb.Append(klant.BTWNummer);
            sb.Append(Environment.NewLine);

            // Hier Loopt hij vast
            //sb.Append(reservatie.Limosine.Naam);
            //// Dit kan hij normaal
            // sb.Append(reservatie.Klant.Naam);
            Limosine limosine = reservatie.Limosine;
            sb.Append("Limosine ID: ");
            sb.Append(limosine.Id);
            sb.Append(Environment.NewLine);
            sb.Append("Limosine Naam: ");
            sb.Append(limosine.Naam);
            sb.Append(Environment.NewLine);

            sb.Append("Reservatie ID: ");
            sb.Append(reservatie.Id);
            sb.Append(Environment.NewLine);
            sb.Append("Reservatie begin: ");
            sb.Append(reservatie.Startmoment.ToString());
            sb.Append(Environment.NewLine);
            sb.Append("Reservatie uren: ");
            sb.Append(reservatie.Duur);
            sb.Append(Environment.NewLine);
            sb.Append("Reservatie type: ");
            sb.Append(reservatie.type);
            sb.Append(Environment.NewLine);
            sb.Append("Reservatie vertrek: ");
            sb.Append(reservatie.VertrekPlaats);
            sb.Append(Environment.NewLine);
            sb.Append("Reservatie aankomst: ");
            sb.Append(reservatie.AankomstPlaats);
            sb.Append(Environment.NewLine);
            sb.Append("Reservatie prijs: ");
            sb.Append(reservatie.GetPrice());
            return sb.ToString();
        }
    }
}
