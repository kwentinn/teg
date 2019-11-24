using System;
using System.Collections.Generic;
using System.Linq;

namespace PretImmo2018.Models
{
	public class Pret
	{
		#region  props saisies

		public string Nom { get; private set; }

		public double MontantAEmprunter { get; private set; }  
		public int DureeEnAnnees { get; private set; }
		public double TauxNominal { get; private set; }
		public DateTime DebutPret { get; private set; }

        private double _mensualitée;

        private SortedSet<Echeance> _echeances = new SortedSet<Echeance>();

        #endregion
         
        public Pret(string nom, double montantAEmprunter, int dureeEnAnnees, double tauxNominal, DateTime debutPret)
        {
            Nom = nom;
            MontantAEmprunter = montantAEmprunter;
            DureeEnAnnees = dureeEnAnnees;
            TauxNominal = tauxNominal; 
            DebutPret = debutPret;

            UpdateEcheancier();
        }

        #region props calculées

        public int GetDureeEnMois() => DureeEnAnnees * 12; 
		public double GetCoutTotal() => _echeances.Sum(e=>e.Mensualité) - MontantAEmprunter;

        public double GetMensualitée()
        {
            return _mensualitée;
        }

        public DateTime GetFinPret() => DebutPret.AddYears(DureeEnAnnees);
        public double GetTAEG()
        {
            return TauxNominal;
        }

        private void UpdateEcheancier()
        { 
            var montantRemboursé = 0.0; 
            _mensualitée = CalculRemboursementMensuel(MontantAEmprunter, TauxNominal, GetDureeEnMois());

            var echeances = new List<Echeance>();
            foreach (var t in Enumerable.Range(1, GetDureeEnMois()))
        	{
                var echeance = new Echeance(DebutPret.AddMonths(t), _mensualitée);
                var interets = (1.85 / 12)/100 * (MontantAEmprunter - montantRemboursé);
                echeance.MensualitéDontInterets = interets;
                echeances.Add(echeance);
                montantRemboursé += echeance.MensualitéDontCapital;
            }
            _echeances = new SortedSet<Echeance>(echeances);
            return;
        }

        #endregion

        public SortedSet<Echeance> GetEcheances()
        {
            return _echeances;
        }

        private static double CalculRemboursementMensuel(double montantEmprunte, double tauxAnnuel, int nbEcheances)
        {
            var remboursementMensuel = 0.0;
            if (tauxAnnuel > 0)
                remboursementMensuel = (montantEmprunte * tauxAnnuel / 12) / (1 - Math.Pow(1 + tauxAnnuel / 12, -nbEcheances));
            else
                remboursementMensuel = montantEmprunte / nbEcheances;

            return remboursementMensuel;
        }

        public double GetMontantTotal()
        {
            return MontantAEmprunter + GetCoutTotal();
        } 
    }
}
