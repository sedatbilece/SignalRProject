﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.MenuTableDtos
{
	public class GetMenuTableDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool Status { get; set; }

		//public List<Basket> Baskets { get; set; }
	}
}