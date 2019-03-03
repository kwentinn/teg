
using PretImmo2018.Models;
using System;
using System.Collections.Generic;

namespace PretImmo2018
{
	class Program
	{
		static void Main(string[] args)
		{

            var montantBien = 263000;
            var apport = 91186;
            var fraisNotaires = 18410;
            var montantAEmprunter = montantBien - apport + fraisNotaires;
            var dureeEnAnnees = 15;  
     
            var pretSeul_1 = new Pret("Crédit immo (teg de 1,50%)", montantAEmprunter, dureeEnAnnees, 1.50 / 100, new DateTime(2018, 12, 1));
            AffichePret(montantBien, fraisNotaires, apport, pretSeul_1);
            
            var pretSeul_2 = new Pret("Crédit immo (teg de 1,65%)", montantAEmprunter, dureeEnAnnees, 1.65/100, new DateTime(2018, 12, 1));
            AffichePret(montantBien, fraisNotaires, apport, pretSeul_2);

            var fraisDeGarantie_3 = 2413;
            var pretSeul_3 = new Pret("Crédit immo sans frais de notaire (teg de 1,65%)", montantAEmprunter - fraisNotaires + fraisDeGarantie_3, dureeEnAnnees, 1.65 / 100, new DateTime(2018, 12, 1));
            AffichePret(montantBien, fraisNotaires, apport, pretSeul_3);

            // PretMultiple
            var fraisDeGarantie_A = 2500;
            var dureeEnAnnees_A = 14;
            var pret_A = new Pret("Crédit immo appart Carnon (1,52%)", montantAEmprunter - fraisNotaires, dureeEnAnnees_A, 1.520 / 100, new DateTime(2018, 12, 1));
            AffichePret(montantBien, fraisNotaires, apport, pret_A);

            var montantAEmprunterB = 19300;
            var dureeEnAnnees_B = 4;
            var pret_B = new Pret("Crédit pour frais de notaire", montantAEmprunterB, dureeEnAnnees_B, 0.946 / 100, new DateTime(2018, 12, 1));
            AffichePret(montantBien, fraisNotaires, apport, pret_B);

            var doublePret = new PretMultiple("Double prêt 1.52% + 0.946%", new List<Pret> { pret_A, pret_B });

            Console.WriteLine($"Montant total de {doublePret.GetMontantTotal().ToString("N2")}");
            Console.WriteLine($"Coût total de {doublePret.GetCoutTotal().ToString("N2")}");

            //var comp = new PretComparer();
            //var best = comp.GetBest(new List<Pret> { pretSeul, pretSeul2, pretSeul3 });

            Console.ReadLine();
        }
          
        /// <summary>
        /// Affiche les résultats dans la console.
        /// </summary>
        public static void AffichePret(double montantBien, double fraisNotariés, double apport, Pret pret)
        {
            Console.WriteLine("#############################################");
            Console.WriteLine($"CREDIT \"{pret.Nom}\"");
            Console.WriteLine();
            Console.WriteLine($"Montant du bien: {montantBien.ToString("N2")}");
            Console.WriteLine($"Frais de notaire: {fraisNotariés.ToString("N2")}");
            Console.WriteLine($"Montant apport: {apport.ToString("N2")}");
            Console.WriteLine($"TAEG: {pret.GetTAEG().ToString("P3")}");
            Console.WriteLine($"MontantAEmprunter: {pret.MontantAEmprunter.ToString("N2")}");
            Console.WriteLine($"Mensualités de {pret.GetMensualitée().ToString("N2")} sur {pret.GetDureeEnMois()/12} ans");
            Console.WriteLine($"Montant total du prêt {pret.GetMontantTotal().ToString("N2")}");
            Console.WriteLine($"Coût du prêt {pret.GetCoutTotal().ToString("N2")}");
            Console.WriteLine("#############################################");
            Console.WriteLine();
        }
    }
    
}
