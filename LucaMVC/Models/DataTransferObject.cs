using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessObject;

namespace DataTransferObjects {

	public class DTPrimo{
		private string _nomePrimo;
		
		public string NomePrimo {
			get { return _nomePrimo; }
		}

		public DTPrimo(string nome) {
			_nomePrimo = nome;
		}   //Costruttore
	}

	public class DTSecondo {
		private string _nomeSecondo;

		public string NomeSecondo {
			get { return _nomeSecondo; }
		}

		public DTSecondo(string nome) {
			_nomeSecondo = nome;
		}   //Costruttore
	}

	public class DTContorno {
		private string _nomeContorno;

		public string NomeContorno {
			get { return _nomeContorno; }
		}

		public DTContorno(string nome) {
			_nomeContorno = nome;
		}   //Costruttore
	}

	public class DTDolce {
		private string _nomeDolce;

		public string NomeDolce {
			get { return _nomeDolce; }
		}

		public DTDolce(string nome) {
			_nomeDolce = nome;
		}   //Costruttore
	}

	public class DTMenu {
		private DateTime _dataMenu;
		private TipoPasto _tipoPasto;   //Pranzo o cena
		
		private List<DTPrimo> _primo = new List<DTPrimo>();
		private List<DTSecondo> _secondo = new List<DTSecondo>();
		private List<DTContorno> _contorno = new List<DTContorno>();
		private List<DTDolce> _dolce = new List<DTDolce>();

		public DateTime DataMenu {
			get { return _dataMenu; }
		}

		public TipoPasto Tipologia_Pasto {
			get { return _tipoPasto; }
		}

		public List<DTPrimo> Primo {
			get { return _primo; }
		}

		public List<DTSecondo> Secondo {
			get { return _secondo; }
		}

		public List<DTContorno> Contorno {
			get { return _contorno; }
		}

		public List<DTDolce> Dolce {
			get { return _dolce; }
		}

		public DTMenu(){ }

		public DTMenu(DateTime d, int tipoPasto, List<DTPrimo> primo, List<DTSecondo> secondo, List<DTContorno> contorno, List<DTDolce> dolce) {
			try {
				if (tipoPasto == 0 || tipoPasto == 1) {
					_tipoPasto = (TipoPasto)tipoPasto;
				} else {
					throw new Exception("Tipologia del pasto non valida! (deve essere 0 e 1)");
				}

				if (primo != null && secondo != null && contorno != null && dolce != null) {
					InserisciLista<DTPrimo>(_primo, primo);
					InserisciLista<DTSecondo>(_secondo, secondo);
					InserisciLista<DTContorno>(_contorno, contorno);
					InserisciLista<DTDolce>(_dolce, dolce);
				} else {
					throw new Exception("Inserimento del Piatto errata! (è null)");
				}
				_dataMenu = d;
			} catch (Exception e) {
				throw e;
			}
		}   //Costruttore

		private void InserisciLista<T> (List<T> lista1, List<T> lista2) {
			foreach (T p1 in lista2) {
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