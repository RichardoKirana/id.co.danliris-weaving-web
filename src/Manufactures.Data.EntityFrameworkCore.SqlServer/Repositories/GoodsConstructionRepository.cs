﻿using Infrastructure.Data.EntityFrameworkCore;
using Manufactures.Domain.Entities;

namespace Manufactures.Domain.Repositories
{
    public class GoodsConstructionRepository : EntityRepository<GoodsConstruction>, IGoodsConstructionRepository
    {
        
    }
}
