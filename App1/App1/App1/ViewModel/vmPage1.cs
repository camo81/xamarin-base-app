using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App1.ViewModel
{
    public class vmPage1: ViewModelBase
    {

        #region bind
        public String maintext = "pippo";
        public String MainText
        {
            get { return maintext; }
            set
            {
                maintext = value;
                Set(nameof(MainText), ref value);
            }
        }

        public String oldstring = "---";
        public String OldString
        {
            get { return oldstring; }
            set
            {
                oldstring = value;
                Set(nameof(OldString), ref value);
            }
        }

        public ICommand CambiaTestoCommand {

            get {
                    return new RelayCommand
                                    (
                                       () => { CambiaTesto(); }
                                    );

                }

        }

        #endregion

        public vmPage1()
        {

        }

        private void CambiaTesto()
        {
            Random rnd = new Random();
            int text = rnd.Next(0, 1000);
            string vecchioValore = MainText;
            MainText = ""+text;
            OldString = vecchioValore;

        }

    }
}
