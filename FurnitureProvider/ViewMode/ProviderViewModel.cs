using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureProvider.ViewMode
{
    public class ProviderViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название поставщика")]
        public string Name { get; set; }

        [DisplayName("ФИО менеджера, который с ним работает")]
        public string FIOManager { get; set; }

        [DisplayName("Рабочий телефон поставщика")]
        public string Number { get; set; }
    }
}
