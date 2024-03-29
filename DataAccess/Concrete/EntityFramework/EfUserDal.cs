﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Concretes;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, KoyunCoinDB>, IUserDal
    {
        public List<OperationClaim> GetClaim(User user)
        {
            using (var context = new KoyunCoinDB())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.userOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where user.Id == userOperationClaim.UserId
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
                return result.ToList();
            }
            
        }
    }
}
