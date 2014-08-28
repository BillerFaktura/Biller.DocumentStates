using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentStates_Biller.DocumentControl
{
    public class DocumentObserver : Biller.UI.Interface.IEditObserver
    {
        Storage storage;
        Biller.UI.ViewModel.MainWindowViewModel parentViewModel;
        public DocumentObserver(Storage storage, Biller.UI.ViewModel.MainWindowViewModel ParentViewModel)
        {
            this.storage = storage;
            this.parentViewModel = ParentViewModel;
        }

        public void ReceiveArticleEditViewModel(Biller.UI.ArticleView.Contextual.ArticleEditViewModel articleEditViewModel)
        {
            //
        }

        public void ReceiveCustomerEditViewModel(Biller.UI.CustomerView.Contextual.CustomerEditViewModel customerEditViewModel)
        {
            //
        }

        public void ReceiveDocumentEditViewModel(Biller.UI.DocumentView.Contextual.DocumentEditViewModel documentEditViewModel)
        {
            // Add a new Tab to set states
            var databaseitem = storage.DocumentTags.Where(x => x.DocumentID == documentEditViewModel.Document.DocumentID && x.DocumentType == documentEditViewModel.Document.DocumentType).FirstOrDefault();
            if (databaseitem == null)
                databaseitem = new Models.DocumentTagModel() { DocumentID = documentEditViewModel.Document.DocumentID, DocumentType = documentEditViewModel.Document.DocumentType };
            documentEditViewModel.EditContentTabs.Add(new EditTab() { DataContext = new ViewModel(parentViewModel, storage) { PlacedTags = databaseitem } });
            documentEditViewModel.BeforeDocumentSaved += documentEditViewModel_BeforeDocumentSaved;
        }

        void documentEditViewModel_BeforeDocumentSaved(object sender, EventArgs e)
        {
            
        }
    }
}
