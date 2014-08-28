using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentStates_Biller.Models
{
    public class DocumentTagModel
    {
        public DocumentTagModel()
        {
            Tags = new ObservableCollection<Tag>();
        }

        public string DocumentType { get; set; }
        public string DocumentID { get; set; }
        public ObservableCollection<Tag> Tags { get; set; }
        
        [JsonIgnore]
        public string TagsInOneLine
        {
            get
            {
                var content = "";
                foreach (var tag in Tags)
                    if (String.IsNullOrEmpty(tag.Name))
                        continue;
                    else
                        if (String.IsNullOrEmpty(content))
                            content += tag.Name;
                        else
                            content += ", " + tag.Name;
                return content;
            }
        }
    }
}
