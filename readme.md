Progetto:  selezionare nuovo progetto crossplatform, blank xaml app (portable). 

mainpage.xaml può avere un solo figlio, usare quindi scrollview dove puoi metterci dentro quello che vuoi.

Scroll view sovrascrive ogni elemento, mettendo 2 elementi vedrò solo il secondo.
Quindi dentro ci aggiungo     <StackLayout> e finalmente posso mettere quello che voglio.

Creo la cartella device sotto la app principale e ci sposto dentro app1.droid e app1.ios.

installo da nuget mvvmlighltlibs

creo  le cartelle:
view
model
viewmodel

ogni nuovo xaml form (page1) sotto view prende come namespace view.nomeform (quindi view.page1)

ogni volta che creo una page creo anche nella caretella viewmodel il rispetto vm.
Nuova classe -> vmPage1.cs. Rendo la class public, estendo la classe a :ViewModelBase e risolvo i conflitti.

Riapro il file CS della view, dopo initialize compontent aggiungo: 

this.BindingContext = new ViewModel.vmPage1();

TIP1: se schiaccio f12 mi porta alla definizione di variabile/funzione/classe
TIP2: se scrivo ctor e poi tab mi crea un costruttore vuoto di default

Nel file vmPage1.cs (dentro la classe public) aggiungo i getter e setter delle variabili che utilizzo poi in grafica e il costruttore.

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

in app.xaml.cs modificare la pagina caricata in avvio da quella di default a view.page1


per ogni testo o variabile creo un get e set in viewmodel.

BOTTONI E AZIONI.

Creo un bottone in grafica nello xaml con il relativo command (Command="{Binding CambiaTestoCommand})
Come per le var, avrò un getter relativo nel viewmodel di tipo Icommand (public Icommand CambiaTestoCommand) il cui get sarà il costruttore.
Il costruttore non fa altro che specificare che parametri accetta il metodo e la relativa funziona che esegue la logica.                
 return new RelayCommand
                                    			(
                                       				(x,y,z) => { CambiaTesto(x,y,z); }
                                   					);
  )
4) creo finalmente la funzione che esegue la logica, sempre nel viewmodel
private void CambiaTesto( logica che serve  )
