# Base app per xamarin #

App sviluppata con xamarin forms e mvvmlightlibs.
L'app consiste di una pagina con un bottone che aggiorna una label con un numero random. il valore sovrascritto andrà in una seconda label.

# Linee guida per MVVM # 

Ogni nuovo xaml form (page1) sotto view prende come namespace view.nomeform (quindi view.page1)
Per ogni nuovo xaml form è necessario creare anche il rispettivo viewmodel nella caretella apposita (Nuova classe -> vmPage1.cs)
La classe dovrà essere public, estendo la classe a :ViewModelBase risolvendo i conflitti.
in app.xaml.cs modificare la pagina caricata in avvio da quella di default a view.page1

# Binding, getter e setter#

Per ogni page, nel rispettivo file CS della view è necessario aggiungere dopo initialize: 

this.BindingContext = new ViewModel.vmPage1();

Nel file vmPage1.cs (dentro la classe public) aggiungere i getter e setter delle variabili e il costruttore.

        public String tutente = Traduzioni.PageLoginUtente;
        public String TUtente
        {
            get { return tutente; }
            set
            {
                tutente = value;
                Set(nameof(TUtente), ref value);
            }
        }



# Bottoni e azioni #

Ogni bottone dovrà avere il relativo command (Command="{Binding CambiaTestoCommand})
Come per le variabili, anche il binding per il command avrà un un getter relativo, nel viewmodel, di tipo Icommand (public Icommand CambiaTestoCommand) il cui get sarà il costruttore.

## Costruttore ##
Il costruttore specifica i parametri accettati dal metodo e la relativa funziona che esegue la logica.                
 return new RelayCommand
                                    			(
                                       				(x,y,z) => { CambiaTesto(x,y,z); }
                                   					);
  )

Si può a questo punto creare la funzione finale che esegue la logica desidearata nel viewmodel:

private void CambiaTesto( logica che serve  )

# Varie ed eventuali #

TIP1: se schiaccio f12 mi porta alla definizione di variabile/funzione/classe
TIP2: se scrivo ctor e poi tab mi crea un costruttore vuoto di default
