using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DocumentStates_Biller
{
    public class EntryPoint : Biller.UI.Interface.IPlugIn
    {
        private List<Biller.UI.Interface.IViewModel> vms;
        private Biller.UI.ViewModel.MainWindowViewModel parentViewModel;

        public EntryPoint(Biller.UI.ViewModel.MainWindowViewModel parentViewModel)
        {
            vms = new List<Biller.UI.Interface.IViewModel>();
            this.parentViewModel = parentViewModel;            
        }

        public string Name
        {
            get { return "DocumentStates @ Biller"; }
        }

        public string Description
        {
            get { return "Speichern Sie beliebige Dokumentzustände"; }
        }

        public double Version
        {
            get { return 1.00140828; }
        }

        public void Activate()
        {
            parentViewModel.DocumentTabViewModel.DocumentTabContent.AddNewColumn("Status", "state", 0.7);
            vms.Add(new DocumentControl.ViewModel(parentViewModel, null));
            parentViewModel.UpdateManager.Register(new Biller.Core.Models.AppModel() { Title = Name, Description = Description, GuID = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), true)[0]).Value.ToLower(), Version = Version, UpdateSource = "https://raw.githubusercontent.com/LastElb/Biller.App/master/update.json" });
        }

        public List<Biller.UI.Interface.IViewModel> ViewModels()
        {
            return vms;
        }
    }
}
