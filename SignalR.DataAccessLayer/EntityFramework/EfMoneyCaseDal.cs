﻿using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
	{

		private readonly SignalRContext _context;
		public EfMoneyCaseDal(SignalRContext context) : base(context)
		{
			_context = context;
		}

		public decimal TotalMoneyCaseAmount()
		{
			return  _context.MoneyCases.FirstOrDefault().TotalAmount;
		}
	}
}
