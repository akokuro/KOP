using FurnitureProvider.BindingModel;
using FurnitureProvider.ViewMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureProvider.Interfaces
{
    public interface IProviderService
    {
        List<ProviderViewModel> GetList();

        ProviderViewModel GetElement(int id);

        void AddElement(ProviderBindingModel model);

        void UpdElement(ProviderBindingModel model);

        void DelElement(int id);
    }
}
