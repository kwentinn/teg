using PretImmo2018.Model;

namespace PretImmo2018.Services.Interfaces
{
	/// <summary>
	/// calcul de tous les éléments d'un prêt (échéances, coût total)
	/// </summary>
	public interface IPretCalculator
	{
		void LancerCalculs(Pret pret);
		void LancerCalculs(PretMultiple pretMultiple);
	}
}
