using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentStates_Biller.DocumentControl
{
    public class ViewModel : Biller.Core.Utils.PropertyChangedHelper, Biller.UI.Interface.IViewModel
    {
        Storage storage;

        public ViewModel(Biller.UI.ViewModel.MainWindowViewModel parentViewModel, Storage storage)
        {
            ParentViewModel = parentViewModel;
            SelectedTag = new Models.Tag();
            this.storage = storage;
        }

        public Biller.UI.ViewModel.MainWindowViewModel ParentViewModel { get; set; }

        public async Task LoadData()
        {
            storage = new Storage(ParentViewModel.Database);
            ParentViewModel.DocumentTabViewModel.RegisterObserver(new DocumentControl.DocumentObserver(storage, ParentViewModel));
            await ParentViewModel.Database.RegisterStorageableItem(new Models.SaveableItem());
            storage.Load();
            DocumentWatcher watcher = new DocumentWatcher(ParentViewModel, storage);
        }

        public void ReceiveData(object data)
        {
            if (data is Models.Tag)
            {
                storage.DocumentTags.Remove(PlacedTags);
                PlacedTags.Tags.Add(data as Models.Tag);
                storage.DocumentTags.Add(PlacedTags);
                if (!storage.Tags.Any(x => x.Name == (data as Models.Tag).Name))
                    storage.Tags.Add(data as Models.Tag);
                storage.Save();
                DocumentWatcher.CurrentWatcher.UpdateAllDisplayedDocuments();
                SelectedTag = new Models.Tag();
            }
        }

        public ObservableCollection<Models.Tag> Tags { get { return storage.Tags; } }

        public Models.Tag SelectedTag { get { return GetValue(() => SelectedTag); } set { SetValue(value); } }

        public Models.DocumentTagModel PlacedTags { get; set; }
    }
}
