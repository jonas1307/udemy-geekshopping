﻿using AutoMapper;
using GeekShopping.CouponAPI.Data.ValueObjects;
using GeekShopping.CouponAPI.Models.Context;
using GeekShopping.CouponAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CouponAPI.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly MySqlContext _context;
        private readonly IMapper _mapper;

        public CouponRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CouponVO> GetCouponByCouponCode(string couponCode)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.CouponCode == couponCode);
            
            return _mapper.Map<CouponVO>(coupon);
        }
    }
}
