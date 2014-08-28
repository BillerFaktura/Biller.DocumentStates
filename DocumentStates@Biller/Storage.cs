using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentStates_Biller
{
    public class Storage
    {
        Biller.Core.Interfaces.IDatabase database;

        public Storage(Biller.Core.Interfaces.IDatabase database)
        {
            this.database = database;
        }
        public async void Save() 
        {
            await database.SaveOrUpdateStorageableItem(new Models.SaveableItem() { Tags = Tags, DocumentTags = DocumentTags });
        }

        public async void Load() 
        {
            var result = await database.AllStorageableItems(new Models.SaveableItem());
            var item = result.FirstOrDefault();
            if (item != null)
            {
                Tags = (item as Models.SaveableItem).Tags;
                DocumentTags = (item as Models.SaveableItem).DocumentTags;
            }
            else
            {
                Tags = new ObservableCollection<Models.Tag>();
                DocumentTags = new ObservableCollection<Models.DocumentTagModel>();
            }
        }

        public ObservableCollection<Models.Tag> Tags { get; set; }

        public ObservableCollection<Models.DocumentTagModel> DocumentTags { get; set; }
    }
}
