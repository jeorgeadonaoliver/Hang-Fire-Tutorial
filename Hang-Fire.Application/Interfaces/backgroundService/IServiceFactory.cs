﻿using Hang_Fire.Domain;

namespace Hang_Fire.Application.Interfaces.backgroundService;

public interface IServiceFactory
{
    IService Execute(ServiceType serviceType);
}
