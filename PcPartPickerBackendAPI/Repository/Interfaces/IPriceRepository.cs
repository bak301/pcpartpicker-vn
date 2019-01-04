using System;
using System.Collections.Generic;
using PcPartPickerBackendAPI.Models;

namespace PcPartPickerBackendAPI.Repository.Interfaces
{
    public interface IPriceRepository
    {

        List<Price> GetPricesByPartId(int partId);
    }
}