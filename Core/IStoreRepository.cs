﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core;


public interface IStoreRepository
{
    Task<List<Store>> GetStores(string storeName, string zipCode);

}
