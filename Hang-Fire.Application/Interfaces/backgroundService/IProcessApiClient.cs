﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hang_Fire.Application.Interfaces.backgroundService
{
    public interface IProcessApiClient
    {
        Task GetDataAsync(IApiClient apiClient);
    }
}
