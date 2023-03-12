﻿using AutoMapper;
using GeekShopping.CartAPI.Data.ValueObjects;
using GeekShopping.CartAPI.Models;

namespace GeekShopping.CartAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>()
                    .ReverseMap();

                config.CreateMap<CartHeaderVO, CartHeader>()
                    .ReverseMap();

                config.CreateMap<CartDetailVO, CartDetail>()
                    .ReverseMap();

                config.CreateMap<CartVO, Cart>()
                    .ReverseMap();
            });
        }
    }
}
