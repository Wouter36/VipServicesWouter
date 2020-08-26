using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models
{
    /// <summary>
    /// A helper class 
    /// with the intention 
    /// to split off methods that need a lot of access to the containing objects
    /// </summary>
    public class ReservatieUtils
    {
        private IUnitOfWork uow;

        public ReservatieUtils(IUnitOfWork uow)
        {
            this.uow = uow;
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
            sb.Append(klant.KlantCategorie.ToString());
            sb.Append(Environment.NewLine);
            sb.Append("Klant adres: ");
            sb.Append(klant.WoonAdres);
            sb.Append(Environment.NewLine);
            sb.Append("Klant BTW-nummer: ");
            sb.Append(klant.BTWNummer);
            sb.Append(Environment.NewLine);
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
            sb.Append(reservatie.type.ToString());
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
