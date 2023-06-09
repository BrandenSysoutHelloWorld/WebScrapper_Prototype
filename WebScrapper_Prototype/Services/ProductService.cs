﻿using CsvHelper;
using System.Text;
using wazaware.co.za.Models.DatabaseModels;
using wazaware.co.za.Mappers;

namespace wazaware.co.za.Services
{
	public class ProductService
	{
		public List<Product> ReadCSVFileSingle(string path)
		{
			Console.WriteLine(path);
			try
			{
				using var reader = new StreamReader(path, Encoding.Default);
				using var csv = new CsvReader(reader);
				csv.Configuration.RegisterClassMap<ProductMapSingle>();
				var rows = csv.GetRecords<Product>().ToList();
				return rows;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		//public List<ProductImageURLs> ReadCSVFileImage(string path)
		//{
		//	Console.WriteLine(path);
		//	try
		//	{
		//		using var reader = new StreamReader(path, Encoding.Default);
		//		using var csv = new CsvReader(reader);
		//		csv.Configuration.RegisterClassMap<ProductMapImages>();
		//		var rows = csv.GetRecords<ProductImageURLs>().ToList();
		//		return rows;
		//	}
		//	catch (Exception e)
		//	{
		//		throw new Exception(e.Message);
		//	}
		//}
		// [DEPRECATED]
		public void SaveCSVFile(string path, List<Product> product)
		{
			using StreamWriter sw = new(path, false, new UTF8Encoding(true));
			using CsvWriter csvw = new(sw);
			csvw.WriteHeader<Product>();
			csvw.NextRecord();
			foreach (Product prod in product)
			{
				csvw.WriteRecord<Product>(prod);
				csvw.NextRecord();
			}
		}
	}
}
