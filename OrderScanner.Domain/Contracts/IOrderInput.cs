﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderScanner.Domain.Contracts
{
    public interface IOrderInput
    {
        void ConfigureProcessor(IOrderProcessor processor);
    }
}
