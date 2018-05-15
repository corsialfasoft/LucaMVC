using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessObject;

namespace DataTransferObjects {

	public class DTPiatto {
		private TipoPiatto _type;
		private string _nomePiatto;
		private string _descrizione;

		public TipoPiatto Type {
			get { return _type; }
		}

		public string NomePiatto {
			get { return _nomePiatto; }
		}

		public string Descrizione {
			get { return _descrizione; }
		}

		public DTPiatto ( int tipoPiatto, string descr ) {
			if (tipoPiatto >= 1 && tipoPiatto <= 4) {
				_type = (TipoPiatto)tipoPiatto;
				_descrizione = descr;
			} else {
				throw new Exception("Tipo piatto non valido! (deve essere un valore compreso tra 1 e 4)");
			}
		}   //Costruttore
	}

	public class DTMenu {
		private DateTime _dataMenu;
		private TipoPasto _tipoPasto;   //Pranzo o cena
		private List<DTPiatto> _primo = new List<DTPiatto>();
		private List<DTPiatto> _secondo = new List<DTPiatto>();
		private List<DTPiatto> _contorno = new List<DTPiatto>();
		private List<DTPiatto> _dolce = new List<DTPiatto>();

		public DateTime DataMenu {
			get { return _dataMenu; }
		}

		public TipoPasto Tipologia_Pasto {
			get { return _tipoPasto; }
		}

		public List<DTPiatto> Primo {
			get { return _primo; }
		}

		public List<DTPiatto> Secondo {
			get { return _secondo; }
		}

		public List<DTPiatto> Contorno {
			get { return _contorno; }
		}

		public List<DTPiatto> Dolce {
			get { return _dolce; }
		}


		public DTMenu(DateTime d, int tipoPasto, List<DTPiatto> primo, List<DTPiatto> secondo, List<DTPiatto> contorno, List<DTPiatto> dolce) {
			try {
				if (tipoPasto == 0 || tipoPasto == 1) {
					_tipoPasto = (TipoPasto)tipoPasto;
				} else {
					throw new Exception("Tipologia del pasto non valida! (deve essere 0 e 1)");
				}

				if (primo != null && secondo != null && contorno != null && dolce != null) {
					InserisciLista(_primo, primo);
					InserisciLista(_secondo, secondo);
					InserisciLista(_contorno, contorno);
					InserisciLista(_dolce, dolce);
				} else {
					throw new Exception("Inserimento del Piatto errata! (è null)");
				}
				_dataMenu = d;
			} catch (Exception e) {
				throw e;
			}
		}   //Costruttore

		private void InserisciLista(List<DTPiatto> lista1, List<DTPiatto> lista2) {
			foreach (DTPiatto p1 in lista2) {
				lista1.Add(p1);
			}
		}
	}

	public class DTGiorno {
		private DateTime _dataG;
		private Giornata _tGiorno;
		private DTMenu _pranzo;
		private DTMenu _cena;

		public DateTime DataG {
			get { return _dataG; }
		}

		public Giornata TGiorno {
			get { return _tGiorno; }
		}

		public DTMenu Pranzo {
			get { return _pranzo; }
		}

		public DTMenu Cena {
			get { return _cena; }
		}

		public DTGiorno(DateTime d, int tGiorno, DTMenu pranzo, DTMenu cena) {
			try {
				if (tGiorno >= 1 && tGiorno <= 7) {
					_tGiorno = (Giornata)tGiorno;
				} else {
					throw new Exception("Tipologia giorno errata!! ( deve avere un valore compreso tra 1 e 7 )");
				}

				if (pranzo != null && cena != null) {
					if (pranzo.Tipologia_Pasto == (TipoPasto)0 && cena.Tipologia_Pasto == (TipoPasto)1) {
						_pranzo = pranzo;
						_cena = cena;
					} else {
						throw new Exception("Tipologia pasti errata nella creazione del giorno");
					}
				} else {
					throw new Exception("Inserimento di pasto/i 'NULL' nella creazione del giorno");
				}
				_dataG = d;
			} catch (Exception e) {
				throw e;
			}
		}
	}
}