﻿using DataLayer.Core.Repositories.Interfaces;
using DataLayer.Core.Utils;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Core.Repositories
{
    public class ProductRepository : GenericRepositoty<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context/*, ILogger logger*/) : base(context/*, logger*/)
        {
        }
    }
}
