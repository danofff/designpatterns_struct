﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaiviourPattern
{
    interface IIterator
    {
        bool HasNext();
        Object Next();
    }
}