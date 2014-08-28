using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentStates_Biller.Models
{
    public class SaveableItem : Biller.Core.Interfaces.IXMLStorageable
    {
        public SaveableItem()
        {
            Tags = new ObservableCollection<Tag>();
        }

        public string ID
        {
            get { return "1"; }
        }

        public Biller.Core.Interfaces.IXMLStorageable GetNewInstance()
        {
            return new SaveableItem();
        }

        public XElement GetXElement()
        {
            var data = new XElement(XElementName);
            data.Add(new XElement(IDFieldName, ID));
            data.Add(new XElement("Tags", Newtonsoft.Json.JsonConvert.SerializeObject(Tags)));
            data.Add(new XElement("DocumentTags", Newtonsoft.Json.JsonConvert.SerializeObject(DocumentTags)));
            return data;
        }

        public void ParseFromXElement(XElement source)
        {
            if (source.Name != XElementName)
                return;
            Tags = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Tag>>(source.Element("Tags").Value);
            DocumentTags = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<DocumentTagModel>>(source.Element("DocumentTags").Value);
        }

        public string XElementName
        {
            get { return "TagDocument"; }
        }

        public string IDFieldName
        {
            get { return "ID"; }
        }

        public ObservableCollection<Tag> Tags;
        public ObservableCollection<DocumentTagModel> DocumentTags;
    }
}
