﻿using AutoMapper;
using Biletify.Entity.Concrete;
using Biletify.Shared.ResponseViewModels;
using Biletify.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Business.Mapping
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            CreateMap<Category, AddCategoryViewModel>().ReverseMap();
            CreateMap<Category, EditCategoryViewModel>().ReverseMap();
            CreateMap<Category, InCategoryViewModel>().ReverseMap();

            CreateMap<Product, AddProductViewModel>().ReverseMap();
            CreateMap<Product, EditProductViewModel>().ReverseMap();

            CreateMap<Product, InProductViewModel>().ReverseMap();

            CreateMap<Product, ProductViewModel>()
                .ForMember(pViewModel => pViewModel.CategoryList, options =>
                    options.MapFrom(p => p.ProductCategories.Select(pc => pc.Category)))
                .ReverseMap();

            CreateMap<Category, CategoryViewModel>()
                .ForMember(cViewModel => cViewModel.ProductList, options =>
                    options.MapFrom(c => c.ProductCategories.Select(pc => pc.Product)))
                .ReverseMap();
        }
    }
}
