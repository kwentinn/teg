using System.Collections.Generic;
using System.Linq;

namespace PretImmo2018.Models
{
    public class PretMultiple
    {
        #region Propriétés

        private List<Pret> _prets = new List<Pret>();
        private SortedSet<Echeance> _echeances;

        public string Nom { get; private set; }

        public PretMultiple(string nom, List<Pret> prets)
        {
            Nom = nom;
            _prets = prets;

            UpdateEcheancier();
        }

        public double GetMontantTotal()
        { 
            if (!_prets.Any())
                return 0d;
            return _prets.Sum(p => p.MontantAEmprunter + p.GetCoutTotal()); 
        }
        public double GetCoutTotal()
        { 
           if (!_prets.Any())
               return 0d;
           return _prets.Sum(p => p.GetCoutTotal()); 
        }

        private void UpdateEcheancier()
        {
            var debutPret = _prets.Min(e => e.DebutPret);
            var finPret = _prets.Max(e => e.GetFinPret());

            var unionEcheances = _prets.SelectMany(e => e.GetEcheances()).ToList();

            var echeances = new List<Echeance>();
            var t = debutPret;
            var montantRemboursé = 0d;
            while (t <= finPret)
            {
                var echeance = new Echeance(t, _prets.Sum(e=>e.GetMensualitée()));
                var echeancesDate = unionEcheances.Where(e => e.Date == t).ToList(); 
                echeance.MensualitéDontInterets = echeancesDate.Sum(e=>e.MensualitéDontInterets);
                echeances.Add(echeance);
                montantRemboursé += echeancesDate.Sum(e => e.MensualitéDontCapital);
                t = t.AddMonths(1);
            }
            _echeances = new SortedSet<Echeance>(echeances);
            return;
        }

        #endregion

        public SortedSet<Echeance> GetEcheances()
        {
            return _echeances;
        }
          
    } 

}