using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maui_lotto.Models
{
    public class MenuItemDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Header { get; set; }
        public DataTemplate Item { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if(item is MainMenuItem)
                return Item;
            else if (item is MainMenuItemHeader)
                return Header;

            return null;
        }
    }
}
