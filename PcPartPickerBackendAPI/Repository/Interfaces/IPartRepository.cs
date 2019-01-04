using System;
using System.Collections.Generic;
using PcPartPickerBackendAPI.ViewModels;

namespace PcPartPickerBackendAPI.Repository.Interfaces
{
    public interface IPartRepository
    {
        List<PartViewModel> GetPartViewModels(
            string partType,
            KeyValuePair<string,string> filterOption, 
            string sortProperty,
            string direction,
            int pageNumber
        );
    }
}