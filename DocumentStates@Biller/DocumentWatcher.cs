using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentStates_Biller
{
    /// <summary>
    /// Adds the tags to the displayed documents
    /// </summary>
    public class DocumentWatcher
    {
        Biller.UI.ViewModel.MainWindowViewModel parentViewModel;
        Storage storage;

        public static DocumentWatcher CurrentWatcher;

        public DocumentWatcher(Biller.UI.ViewModel.MainWindowViewModel parentViewModel, Storage storage)
        {
            this.parentViewModel = parentViewModel;
            this.storage = storage;
            parentViewModel.DocumentTabViewModel.DisplayedDocuments.CollectionChanged += DisplayedDocuments_CollectionChanged;
            UpdateAllDisplayedDocuments();
            CurrentWatcher = this;
        }

        void DisplayedDocuments_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                if (e.NewItems != null)
                    foreach(dynamic item in e.NewItems)
                    {
                        var databaseitem = storage.DocumentTags.Where(x => x.DocumentID == item.DocumentID && x.DocumentType == item.DocumentType).FirstOrDefault();
                        if (databaseitem != null)
                            item.state = databaseitem.TagsInOneLine;
                    }
        }

        public void UpdateAllDisplayedDocuments()
        {
            foreach (dynamic item in parentViewModel.DocumentTabViewModel.DisplayedDocuments)
            {
                var databaseitem = storage.DocumentTags.Where(x => x.DocumentID == item.DocumentID && x.DocumentType == item.DocumentType).FirstOrDefault();
                if (databaseitem != null)
                    item.state = databaseitem.TagsInOneLine;
            }
        }
    }
}
