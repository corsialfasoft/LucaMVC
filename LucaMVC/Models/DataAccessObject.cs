using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessObject {

	public enum TipoPiatto { primo = 1, secondo, contorno, dolce };

	public enum Giornata { lunedì = 1, martedì, mercoledì, giovedì, venerdì, sabato, domenica };

	public enum TipoPasto { pranzo, cena };

	public class Piatto{
		private TipoPiatto _type;
		private string _descrizione;

		public TipoPiatto Type{
			get { return _type; }
		}

		public string Descrizione {
			get { return _descrizione; }
		}

		public Piatto(int tipoPiatto, string descr){
			if (tipoPiatto >= 1 && tipoPiatto <= 4) {
				_type = (TipoPiatto) tipoPiatto;
				_descrizione = descr;
			} else {
				throw new Exception("Tipo piatto non valido! (deve essere un valore compreso tra 1 e 4)");
			}
		}   //Costruttore
	}

	public class Pasto {
		private TipoPasto _tipoPasto;	//Pranzo o cena
		private List<Piatto> _primo = new List<Piatto>();
		private List<Piatto> _secondo = new List<Piatto>();
		private List<Piatto> _contorno = new List<Piatto>();
		private List<Piatto> _dolce = new List<Piatto>();


		public TipoPasto Tipologia_Pasto {
			get { return _tipoPasto; }
		}

		public List<Piatto> Primo {
			get { return _primo; }
		}

		public List<Piatto> Secondo {
			get { return _secondo; }
		}

		public List<Piatto> Contorno {
			get { return _contorno; }
		}

		public List<Piatto> Dolce {
			get { return _dolce; }
		}


		public Pasto(int tipoPasto, List<Piatto> primo, List<Piatto> secondo, List<Piatto> contorno, List<Piatto> dolce) {
			try{
				if ( tipoPasto == 0 || tipoPasto == 1 ) {
					_tipoPasto = ( TipoPasto ) tipoPasto;
				} else {
					throw new Exception("Tipologia del pasto non valida! (deve essere 0 e 1)");
				}

				if ( primo != null && secondo != null && contorno != null && dolce != null ) {
					InserisciLista ( _primo , primo ) ;
					InserisciLista ( _secondo , secondo ) ;
					InserisciLista ( _contorno , contorno ) ;
					InserisciLista ( _dolce , dolce ) ;
				} else {
					throw new Exception("Inserimento del Piatto errata! (è null)");
				}
			} catch (Exception e) {
				throw e;
			}
		}   //Costruttore

		private void InserisciLista(List<Piatto> lista1, List<Piatto> lista2) {
			foreach ( Piatto p1 in lista2 ) {
				lista1.Add(p1);
			}
		}
	}

	public class Giorno{
		private DateTime _data;
		private Giornata _tGiorno;
		private Pasto _pranzo;
		private Pasto _cena;

		public DateTime Data{
			get { return _data; }
		}

		public Giornata TGiorno {
			get { return _tGiorno; }
		}

		public Pasto Pranzo{
			get { return _pranzo; }
		}

		public Pasto Cena {
			get { return _cena; }
		}

		public Giorno ( DateTime d, int tGiorno , Pasto pranzo , Pasto cena ) {
			try{
				if ( tGiorno >= 1 && tGiorno <= 7) {
					_tGiorno = (Giornata) tGiorno ;
				} else {
					throw new Exception("Tipologia giorno errata!! ( deve avere un valore compreso tra 1 e 7 )");
				}

				if (pranzo != null && cena != null ) {
					if ( pranzo.Tipologia_Pasto == (TipoPasto) 0 && cena.Tipologia_Pasto == (TipoPasto) 1 ) {
						_pranzo = pranzo;
						_cena = cena;
					} else {
						throw new Exception ("Tipologia pasti errata nella creazione del giorno");
					}
				} else {
					throw new Exception("Inserimento di pasto/i 'NULL' nella creazione del giorno");
				}
				_data = d;
			} catch ( Exception e ) {
				throw e;
			}
		}
	}

	//public class Settimana{
	//	private DateTime _dataInizio;
	//	private DateTime _dataFine;
	//	private Giorno _lunedi;
	//	private Giorno _martedi;
	//	private Giorno _mercoledi;
	//	private Giorno _giovedi;
	//	private Giorno _venerdi;
	//	private Giorno _sabato;
	//	private Giorno _domenica;

	//	public DateTime DataInizio{
	//		get { return _dataInizio; }
	//	}

	//	public DateTime DataFine {
	//		get { return _dataFine; }
	//	}

	//	public Giorno Lunedi{
	//		get { return _lunedi; }
	//	}

	//	public Giorno Martedi {
	//		get { return _martedi; }
	//	}

	//	public Giorno Mercoledi {
	//		get { return _mercoledi; }
	//	}

	//	public Giorno Giovedi {
	//		get { return _giovedi; }
	//	}

	//	public Giorno Venerdi {
	//		get { return _venerdi; }
	//	}

	//	public Giorno Sabato {
	//		get { return _sabato; }
	//	}

	//	public Giorno Domenica {
	//		get { return _domenica; }
	//	}

	//	public Settimana ( DateTime i, DateTime f, Giorno lunedi, Giorno martedi, Giorno mercoledi, Giorno giovedi, Giorno _venerdi, Giorno sabato, Giorno domenica) {
	//		bool l, ma, me, g, v, s, d;
	//		l = CheckData (lunedi, i, f);
	//		ma = CheckData(martedi, i, f);
	//		me = CheckData(mercoledi, i, f);
			

	//	}

	//	private bool CheckData (Giorno g, DateTime i, DateTime f) {
	//		return (g.Data.Date >= i.Date && g.Data.Date <= f.Date);
	//	}
	//}
}